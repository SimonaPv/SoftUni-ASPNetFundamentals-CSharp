using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.ViewModels.Product;
using Newtonsoft.Json;
using System.Text.Json;
using static MVCIntroDemo.Seeding.ProductsData;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult All()
        {
            return this.View(Products);
        }

        public IActionResult ProductById(string id) //zaradi Guid
        {
            ProductViewModel? product = Products
                .FirstOrDefault(p => p.Id.ToString().Equals(id));
            if (product == null)
            {
                return this.RedirectToAction("All");
            }

            return this.View(product);
        }

        public IActionResult ReturnAsJson()
        {
            //string jsonText = JsonConvert
            //    .SerializeObject(Products, Formatting.Indented);

            //return Json(jsonText);

            return Json(Products, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
