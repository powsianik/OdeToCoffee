using Microsoft.AspNetCore.Mvc;
using OdeToCoffee.Models;
using OdeToCoffee.Services;

namespace OdeToCoffee.Controllers
{
    public class HomeController : Controller
    {
        private ICoffehouseData coffeeHousesData;

        public HomeController(ICoffehouseData coffeehousesData)
        {
            this.coffeeHousesData = coffeehousesData;
        }

        public IActionResult Index()
        {
            var model = this.coffeeHousesData.GetAll();

            return View(model);
        }
    }
}