using System.Collections.Generic;
using System.Linq;
using OdeToCoffee.Models;

namespace OdeToCoffee.Model.DataProviders
{
    public class InMemoryCoffeehouseDataProviderProvider : ICoffehouseDataProvider
    {
        private static List<Coffeehouse> coffeehouses = new List<Coffeehouse>()
        {
            new Coffeehouse() {Id = 1, Name = "Biała lokomotywa"},
            new Coffeehouse() {Id = 2, Name = "Parkowa"},
            new Coffeehouse() {Id = 3, Name = "Rycerska"},
            new Coffeehouse() {Id = 4, Name = "Sportowa"},
            new Coffeehouse() {Id = 5, Name = "Ewelina"}
        };

        public IEnumerable<Coffeehouse> GetAll()
        {
            return coffeehouses;
        }

        public Coffeehouse Get(int id)
        {
            return Enumerable.FirstOrDefault<Coffeehouse>(coffeehouses, c => c.Id == id);
        }

        public Coffeehouse Add(Coffeehouse newCoffeehouse)
        {
            newCoffeehouse.Id = Enumerable.Max<Coffeehouse>(coffeehouses, c => c.Id) + 1;
            coffeehouses.Add(newCoffeehouse);

            return newCoffeehouse;
        }
    }
}