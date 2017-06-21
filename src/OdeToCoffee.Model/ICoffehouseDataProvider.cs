using System.Collections.Generic;
using OdeToCoffee.Model.Entities;

namespace OdeToCoffee.Model
{
    public interface ICoffehouseDataProvider
    {
        IEnumerable<Coffeehouse> GetAll();
        Coffeehouse Get(int id);
        Coffeehouse Add(Coffeehouse newCoffeehouse);
        void Update(Coffeehouse coffeehouse);
    }
}