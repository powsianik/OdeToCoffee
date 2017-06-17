using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OdeToCoffee.Model;
using OdeToCoffee.Models;

namespace OdeToCoffee.Model.Migrations
{
    [DbContext(typeof(OdeToCoffeeDbContext))]
    partial class OdeToCoffeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OdeToCoffee.Models.Coffeehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Style");

                    b.HasKey("Id");

                    b.ToTable("Coffeehouses");
                });
        }
    }
}
