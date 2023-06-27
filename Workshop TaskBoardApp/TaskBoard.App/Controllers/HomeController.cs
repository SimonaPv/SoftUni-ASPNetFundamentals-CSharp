using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoard.App.Models;

namespace TaskBoard.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}