using Microsoft.EntityFrameworkCore;
using OdeToCoffee.Model.Entities;

namespace OdeToCoffee.Model
{
    public class OdeToCoffeeDbContext : DbContext
    {
        public OdeToCoffeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Coffeehouse> Coffeehouses { get; set; }
    }
}
