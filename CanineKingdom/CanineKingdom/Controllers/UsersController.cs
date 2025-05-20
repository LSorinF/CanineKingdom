using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CanineKingdom.Services;
using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;

namespace CanineKingdom.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchString)
        {
            var users = await _userService.SearchUsersAsync(searchString);
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userService.GetUserDetailsAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser appUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(appUser);
                if (result)
                    return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userService.GetUserForEditAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicationUser appUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(id, appUser);
                if (result)
                    return RedirectToAction(nameof(Index));
                else
                    return NotFound();
            }
            return View(appUser);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userService.GetUserForDeleteAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
