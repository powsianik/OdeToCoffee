using System;
using System.Collections.Generic;
using OdeToCoffee.Models;

namespace OdeToCoffee.Services
{
    public interface ICoffehouseData
    {
        IEnumerable<Coffeehouse> GetAll();
    }

    public class InMemoryCoffeehouseData : ICoffehouseData
    {
        private readonly IEnumerable<Coffeehouse> coffeehouses = new List<Coffeehouse>()
        {
            new Coffeehouse() {Id = 1, Name = "Biała lokomotywa"},
            new Coffeehouse() {Id = 2, Name = "Parkowa"},
            new Coffeehouse() {Id = 3, Name = "Rycerska"},
            new Coffeehouse() {Id = 4, Name = "Sportowa"},
            new Coffeehouse() {Id = 5, Name = "Ewelina"}
        };

        public IEnumerable<Coffeehouse> GetAll()
        {
            return this.coffeehouses;
        }
    }
}