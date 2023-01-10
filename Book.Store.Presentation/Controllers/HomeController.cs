using Book.Store.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Book.Store.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepo _bookRepo;
        public HomeController(ILogger<HomeController> logger,
            IBookRepo bookRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;

        }

        public IActionResult Index()
        {
            var result=_bookRepo.getAll();
            return View(result);
        }

        public IActionResult Privacy()
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