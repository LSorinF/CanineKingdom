using CanineKingdom.Infrastructure;
using CanineKingdom.Models;
using CanineKingdom.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserServiceRepository : IUserServiceRepository
{
    private readonly CanineDbContext _context;

    public UserServiceRepository(CanineDbContext context)
    {
        _context = context;
    }

    public async Task<List<ApplicationUser>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<ApplicationUser> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddAsync(ApplicationUser user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ApplicationUser user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ApplicationUser user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Users.AnyAsync(u => u.Id == id);
    }

    public async Task<List<ApplicationUser>> SearchByUsernameAsync(string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return await _context.Users.ToListAsync();

        return await _context.Users
            .Where(u => u.UserName.ToLower().Contains(searchString.ToLower()))
            .ToListAsync();
    }
}
