using CanineKingdom.Models;

namespace CanineKingdom.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserDetailsAsync(int? id);

        Task<bool> CreateUserAsync(User user);

        Task<User> GetUserForEditAsync(int? id);

        Task<bool> UpdateUserAsync(int id, User user);

        Task<User> GetUserForDeleteAsync(int? id);

        Task<bool> DeleteUserAsync(int id);

        Task<bool> UserExistsAsync(int id);

        Task<List<User>> SearchUsersAsync(string searchString);

    }
}
