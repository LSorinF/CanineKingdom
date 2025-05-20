using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CanineKingdom.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ArticlesController(IArticleService articleService, UserManager<ApplicationUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }

        // GET: /Article
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllAsync();
            return View(articles);
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    var article = await _articleService.GetByIdAsync(id);
        //    //var comments = await _articleService.GetCommentsAsync(id);

        //    //var likeCount = await _articleService.CountReactionsAsync(id, ReactionType.Like);
        //    //var dislikeCount = await _articleService.CountReactionsAsync(id, ReactionType.Dislike);

        //    //var viewModel = new ArticleDetailsViewModel
        //    //{
        //    //    Article = article,
        //    //    ArticleComments = comments,
        //    //    LikeCount = likeCount,
        //    //    DislikeCount = dislikeCount
        //    //};

        //    //return View(viewModel);
        //}

        //// GET: /Article/Create
        //[Authorize(Roles = "Administrator")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: /Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(Article article)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                article.AuthorId = user.Id;
                article.PublishedAt = DateTime.UtcNow;

                await _articleService.CreateAsync(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: /Article/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var article = await _articleService.GetByIdAsync(id);
            if (article == null)
                return NotFound();

            return View(article);
        }

        // POST: /Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, Article article)
        {
            if (id != article.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _articleService.UpdateAsync(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: /Article/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _articleService.GetByIdAsync(id);
            if (article == null)
                return NotFound();

            return View(article);
        }

        // POST: /Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Article/AddComment
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(int articleId, string commentText)
        {
            if (string.IsNullOrWhiteSpace(commentText))
                return RedirectToAction("Details", new { id = articleId });

            // Get the current user (which has an int ID)
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            //int authorId = user.Id;

            //await _articleService.AddCommentAsync(articleId, commentText);

            return RedirectToAction("Details", new { id = articleId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> React(int articleId, ReactionType reaction)
        {
            var userId = _userManager.GetUserId(User);
            await _articleService.ReactToArticleAsync(articleId, userId, reaction);

            return RedirectToAction("Details", new { id = articleId });
        }
    }
}
