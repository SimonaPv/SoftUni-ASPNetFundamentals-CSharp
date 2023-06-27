using AspNetCoreIntroduction.Models;
using AspNetCoreIntroduction.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIntroduction.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            this._carService = carService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddCarViewModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(carModel);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
