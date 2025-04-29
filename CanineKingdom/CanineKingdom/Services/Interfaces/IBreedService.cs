using CanineKingdom.Models;

namespace CanineKingdom.Services.Interfaces
{
    public interface IBreedService
    {
        Task<List<Breed>> GetAllBreedsAsync();
        Task<List<Breed>> SearchBreedsByNameAsync(string searchString);
        Task<Breed> GetBreedDetailsAsync(int? id);
        Task<bool> CreateBreedAsync(Breed breed);
        Task<Breed> GetBreedForEditAsync(int? id);
        Task<bool> UpdateBreedAsync(int id, Breed breed);
        Task<Breed> GetBreedForDeleteAsync(int? id);
        Task<bool> DeleteBreedAsync(int id);
        Task<bool> BreedExistsAsync(int id);
    }
}
