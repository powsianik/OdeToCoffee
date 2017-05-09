using System;
using System.Collections.Generic;
using System.Linq;
using OdeToCoffee.Models;

namespace OdeToCoffee.Services
{
    public interface ICoffehouseData
    {
        IEnumerable<Coffeehouse> GetAll();
        Coffeehouse Get(int id);
        Coffeehouse Add(Coffeehouse newCoffeehouse);
    }

    public class InMemoryCoffeehouseData : ICoffehouseData
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
            return coffeehouses.FirstOrDefault(c => c.Id == id);
        }

        public Coffeehouse Add(Coffeehouse newCoffeehouse)
        {
            newCoffeehouse.Id = coffeehouses.Max(c => c.Id) + 1;
            coffeehouses.Add(newCoffeehouse);

            return newCoffeehouse;
        }
    }
}