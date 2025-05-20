using CanineKingdom.Infrastructure;
using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CanineKingdom.Services
{
    public class BreedService : IBreedService
    {
        private readonly CanineDbContext _repository;

        public BreedService(CanineDbContext context)
        {
            _repository = context;
        }

        public async Task<List<Breed>> GetAllBreedsAsync()
        {
            return await _repository.Breeds.ToListAsync();
        }

        public async Task<List<Breed>> SearchBreedsByNameAsync(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return await _repository.Breeds.ToListAsync();

            return await _repository.Breeds
                .Where(b => EF.Functions.Like(b.Name.ToLower(), $"%{searchString.ToLower()}%"))
                .ToListAsync();
        }


        public async Task<Breed> GetBreedDetailsAsync(int? id)
        {
            if (id == null)
                return null;

            return await _repository.Breeds.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> CreateBreedAsync(Breed breed)
        {
            _repository.Breeds.Add(breed);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<Breed> GetBreedForEditAsync(int? id)
        {
            if (id == null)
                return null;

            return await _repository.Breeds.FindAsync(id);
        }

        public async Task<bool> UpdateBreedAsync(int id, Breed breed)
        {
            if (id != breed.Id)
                return false;

            try
            {
                _repository.Update(breed);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BreedExistsAsync(breed.Id))
                    return false;
                throw;
            }
        }

        public async Task<Breed> GetBreedForDeleteAsync(int? id)
        {
            if (id == null)
                return null;

            return await _repository.Breeds.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> DeleteBreedAsync(int id)
        {
            var breed = await _repository.Breeds.FindAsync(id);
            if (breed == null)
                return false;

            _repository.Breeds.Remove(breed);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BreedExistsAsync(int id)
        {
            return await _repository.Breeds.AnyAsync(e => e.Id == id);
        }
    }
}
