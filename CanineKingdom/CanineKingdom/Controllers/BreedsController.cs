using CanineKingdom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CanineKingdom.Controllers
{
    public class BreedsController : Controller
    {
        private readonly ILogger<BreedsController> _logger;

        public BreedsController(ILogger<BreedsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
