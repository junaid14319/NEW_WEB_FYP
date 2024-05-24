using Microsoft.AspNetCore.Mvc;
using NEW_WEB_FYP.Models;
using System.Diagnostics;

namespace NEW_WEB_FYP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Elements()
        {
            return View();
        }

        public IActionResult Latest_news()
        {
            return View();
        }
        public IActionResult SingleBlog()
        {
            return View();
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
