using CanineKingdom.Infrastructure;
using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanineKingdom.Services
{
    public class UserService : IUserService
    {
        private readonly CanineDbContext _context;

        public UserService(CanineDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserDetailsAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (user == null)
                return false;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserForEditAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            if (id != user.Id)
                return false;

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExistsAsync(user.Id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<User> GetUserForDeleteAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<List<User>> SearchUsersAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return await _context.Users.ToListAsync();
            }

            return await _context.Users
                .Where(u => u.Username.ToLower().Contains(searchString.ToLower()))
                .ToListAsync();
        }

    }
}
