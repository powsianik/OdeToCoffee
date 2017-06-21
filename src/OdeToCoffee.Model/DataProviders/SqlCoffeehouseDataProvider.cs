using System.Collections.Generic;
using System.Linq;
using OdeToCoffee.Model.Entities;

namespace OdeToCoffee.Model.DataProviders
{
    public class SqlCoffeehouseDataProvider : ICoffehouseDataProvider
    {
        private OdeToCoffeeDbContext dbContext;

        public SqlCoffeehouseDataProvider(OdeToCoffeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Coffeehouse> GetAll()
        {
            return this.dbContext.Coffeehouses;
        }

        public Coffeehouse Get(int id)
        {
            return this.dbContext.Coffeehouses.FirstOrDefault(c => c.Id == id);
        }

        public Coffeehouse Add(Coffeehouse newCoffeehouse)
        {
            this.dbContext.Add(newCoffeehouse);
            this.dbContext.SaveChanges();

            return newCoffeehouse;
        }

        public void Update(Coffeehouse coffeehouse)
        {
            this.dbContext.Update(coffeehouse);
            this.dbContext.SaveChanges();
        }
    }
}