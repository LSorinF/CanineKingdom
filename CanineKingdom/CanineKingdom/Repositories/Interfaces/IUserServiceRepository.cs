using CanineKingdom.Models;

public interface IUserServiceRepository
{
    Task<List<ApplicationUser>> GetAllAsync();
    Task<ApplicationUser> GetByIdAsync(int id);
    Task AddAsync(ApplicationUser user);
    Task UpdateAsync(ApplicationUser user);
    Task DeleteAsync(ApplicationUser user);
    Task<bool> ExistsAsync(int id);
    Task<List<ApplicationUser>> SearchByUsernameAsync(string searchString);
}
