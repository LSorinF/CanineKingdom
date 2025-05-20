using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CanineKingdom.Controllers
{
    public class BreedsController : Controller
    {
        private readonly IBreedService _breedService;

        public BreedsController(IBreedService breedService)
        {
            _breedService = breedService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var breeds = await _breedService.SearchBreedsByNameAsync(searchString);
            return View(breeds);
        }


        public async Task<IActionResult> Details(int? id)
        {
            var breed = await _breedService.GetBreedDetailsAsync(id);
            if (breed == null)
                return NotFound();

            return View(breed);
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Size,Origin,HairSize,Lifespan,Classification,Id")] Breed breed)
        {
            if (ModelState.IsValid)
            {
                await _breedService.CreateBreedAsync(breed);
                return RedirectToAction(nameof(Index));
            }
            return View(breed);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var breed = await _breedService.GetBreedForEditAsync(id);
            if (breed == null)
                return NotFound();

            return View(breed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Size,Origin,HairSize,Lifespan,Classification,Id")] Breed breed)
        {
            if (ModelState.IsValid)
            {
                var updated = await _breedService.UpdateBreedAsync(id, breed);
                if (!updated)
                    return NotFound();

                return RedirectToAction(nameof(Index));
            }
            return View(breed);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var breed = await _breedService.GetBreedForDeleteAsync(id);
            if (breed == null)
                return NotFound();

            return View(breed);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _breedService.DeleteBreedAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
