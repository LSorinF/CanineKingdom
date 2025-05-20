using CanineKingdom.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
    Task<List<ApplicationUser>> GetAllUsersAsync();
    Task<ApplicationUser> GetUserDetailsAsync(int? id);
    Task<bool> CreateUserAsync(ApplicationUser user);
    Task<ApplicationUser> GetUserForEditAsync(int? id);
    Task<bool> UpdateUserAsync(int id, ApplicationUser user);
    Task<ApplicationUser> GetUserForDeleteAsync(int? id);
    Task<bool> DeleteUserAsync(int id);
    Task<bool> UserExistsAsync(int id);
    Task<List<ApplicationUser>> SearchUsersAsync(string searchString);
}
