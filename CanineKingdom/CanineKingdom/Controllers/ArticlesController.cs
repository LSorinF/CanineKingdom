using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CanineKingdom.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService; // For SelectList of Users

        public ArticlesController(IArticleService articleService, IUserService userService)
        {
            _articleService = articleService;
            _userService = userService;
        }

        // GET: Articles
        // GET: Articles
        public async Task<IActionResult> Index(string searchString)
        {
            var articles = await _articleService.SearchArticlesByTitleAsync(searchString);
            return View(articles);
        }


        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var article = await _articleService.GetArticleDetailsAsync(id);
            if (article == null)
                return NotFound();

            return View(article);
        }

        // GET: Articles/Create
        public async Task<IActionResult> Create()
        {
            ViewData["UserId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id");
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Title,Content,Id")] Article article)
        {
            if (ModelState.IsValid)
            {
                await _articleService.CreateArticleAsync(article);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id", article.UserId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var article = await _articleService.GetArticleForEditAsync(id);
            if (article == null)
                return NotFound();

            ViewData["UserId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id", article.UserId);
            return View(article);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Title,Content,PublishedAt,Id")] Article article)
        {
            if (!await _articleService.UpdateArticleAsync(id, article))
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var article = await _articleService.GetArticleForDeleteAsync(id);
            if (article == null)
                return NotFound();

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleService.DeleteArticleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
