using Microsoft.EntityFrameworkCore;
using Bulky.Models;


namespace Bulky.DataAccess.Data
{

    public class ApplicationDbContext:DbContext
	{
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name="Action", DisplayOrder=1},
                new Category { ID = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { ID = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title="Book of fortune",
                    Author="Bulky Book",
                    Description = "nothing descript",
                    ISBN="S5678678600",
                    ListPrice=99,
                    Price=90,
                    Price50=88,
                    Price100=85,
                },
                 new Product
                 {
                     Id = 2,
                     Title = "Book 2",
                     Author = "Bulky Book",
                     Description = "nothing descript",
                     ISBN = "S5678678600",
                     ListPrice = 99,
                     Price = 90,
                     Price50 = 88,
                     Price100 = 85,
                 },
                  new Product
                  {
                      Id = 1,
                      Title = "Book 3",
                      Author = "Bulky Book",
                      Description = "nothing descript",
                      ISBN = "S5678678600",
                      ListPrice = 99,
                      Price = 90,
                      Price50 = 88,
                      Price100 = 85,
                  }

            ) ;
        }
    }
}

