using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using CanineKingdom.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserServiceRepository _repository;

    public UserService(IUserServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ApplicationUser>> GetAllUsersAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ApplicationUser> GetUserDetailsAsync(int? id)
    {
        if (id == null) return null;
        return await _repository.GetByIdAsync(id.Value);
    }

    public async Task<bool> CreateUserAsync(ApplicationUser user)
    {
        if (user == null) return false;
        await _repository.AddAsync(user);
        return true;
    }

    public async Task<ApplicationUser> GetUserForEditAsync(int? id)
    {
        if (id == null) return null;
        return await _repository.GetByIdAsync(id.Value);
    }

    public async Task<bool> UpdateUserAsync(int id, ApplicationUser user)
    {
        if (id != user.Id) return false;

        if (!await _repository.ExistsAsync(id))
            return false;

        await _repository.UpdateAsync(user);
        return true;
    }

    public async Task<ApplicationUser> GetUserForDeleteAsync(int? id)
    {
        if (id == null) return null;
        return await _repository.GetByIdAsync(id.Value);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return false;

        await _repository.DeleteAsync(user);
        return true;
    }

    public async Task<bool> UserExistsAsync(int id)
    {
        return await _repository.ExistsAsync(id);
    }

    public async Task<List<ApplicationUser>> SearchUsersAsync(string searchString)
    {
        return await _repository.SearchByUsernameAsync(searchString);
    }
}
