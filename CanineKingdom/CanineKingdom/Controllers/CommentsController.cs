using CanineKingdom.Models;
using CanineKingdom.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CanineKingdom.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return View(comments);
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var comment = await _commentService.GetCommentDetailsAsync(id);
            if (comment == null)
                return NotFound();

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,CommentText")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                await _commentService.CreateCommentAsync(comment);
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var comment = await _commentService.GetCommentForEditAsync(id);
            if (comment == null)
                return NotFound();

            return View(comment);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,ArticleId,CommentText,CreatedAt,Id")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.UpdateCommentAsync(id, comment);
                if (!result)
                    return NotFound();

                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var comment = await _commentService.GetCommentForDeleteAsync(id);
            if (comment == null)
                return NotFound();

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
