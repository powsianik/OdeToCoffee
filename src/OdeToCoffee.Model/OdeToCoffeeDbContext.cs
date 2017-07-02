using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdeToCoffee.Model.Entities;

namespace OdeToCoffee.Model
{
    public class OdeToCoffeeDbContext : IdentityDbContext<User>
    {
        public OdeToCoffeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Coffeehouse> Coffeehouses { get; set; }
    }
}
