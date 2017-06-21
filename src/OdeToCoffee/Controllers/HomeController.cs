using Microsoft.AspNetCore.Mvc;
using OdeToCoffee.Model;
using OdeToCoffee.Model.Entities;
using OdeToCoffee.Services;
using OdeToCoffee.ViewModels;

namespace OdeToCoffee.Controllers
{
    public class HomeController : Controller
    {
        private ICoffehouseDataProvider coffeeHousesData;
        private IMessageGetter messageGetter;

        public HomeController(ICoffehouseDataProvider coffeehousesData, IMessageGetter messageGetter)
        {
            this.coffeeHousesData = coffeehousesData;
            this.messageGetter = messageGetter;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Coffeehouses = this.coffeeHousesData.GetAll();
            model.MessageOfTheDay = this.messageGetter.GetMessage();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = this.coffeeHousesData.Get(id);

            if (model == null)
            {
                return RedirectToAction(nameof(this.Index));
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoffeehouseViewModel cooffeeHouse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var newCoffeehouse = new Coffeehouse();
            newCoffeehouse.Name = cooffeeHouse.Name;
            newCoffeehouse.Style = cooffeeHouse.Style;

            this.coffeeHousesData.Add(newCoffeehouse);

            return RedirectToAction(nameof(this.Details), new { id = newCoffeehouse.Id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.coffeeHousesData.Get(id);

            if (model == null)
            {
                return RedirectToAction(nameof(this.Index));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, CoffeehouseViewModel coffeeHouse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var coffeHouseForEdit = this.coffeeHousesData.Get(id);
            coffeHouseForEdit.Name = coffeeHouse.Name;
            coffeHouseForEdit.Style = coffeeHouse.Style;

            this.coffeeHousesData.Update(coffeHouseForEdit);

            return RedirectToAction(nameof(this.Details), new {id = coffeHouseForEdit.Id});
        }
    }
}