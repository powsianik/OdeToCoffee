using System.Collections.Generic;
using OdeToCoffee.Models;

namespace OdeToCoffee.Model
{
    public interface ICoffehouseDataProvider
    {
        IEnumerable<Coffeehouse> GetAll();
        Coffeehouse Get(int id);
        Coffeehouse Add(Coffeehouse newCoffeehouse);
    }
}