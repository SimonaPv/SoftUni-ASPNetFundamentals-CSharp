using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models;
using System.Diagnostics;

namespace MVCIntroDemo.Controllers
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
            //How to pass data from controller to the view
            // 1. Using model -> Large structured data, usually forms and details pages
            // 2. Using ViewBag -> Random data, using dynamic object
            // 3. Using VIewData -> Random data, using dictionary

            ViewBag.Message = "Hello World from ViewBag!";
            ViewData["Msg"] = "Hello world from ViewData!";

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        //How to create a page
        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC app.";

            return this.View();
        }

        public IActionResult Numbers()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult NumbersFrom1ToN()
        {
            ViewData["Count"] = -1;
            return this.View();
        }

        [HttpPost]
        public IActionResult NumbersFrom1ToN(int count = -1)
        {
            ViewData["Count"] = count;
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}