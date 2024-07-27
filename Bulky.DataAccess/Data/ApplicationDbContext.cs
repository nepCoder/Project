using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Bulky.Models;
namespace Bulky.DataAccess.Data
{
	public class ApplicationDbContext: IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CategoryID = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { CategoryID = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    PId = 1,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Description = " A novel about the serious issues of rape and racial inequality",
                    ISBN = "SJFK46546F",
                    ListPrice = 99,
                    Price = 95,
                    Price50 = 90,
                    Price100 = 85,
                    CategoryID = 2,
                    ImageUrl = ""


                },
                 new Product
                 {
                     PId = 2,
                     Title = "Pride and Prejudice",
                     Author = "RJane Austen",
                     Description = "A romantic novel",
                     ISBN = "SJFK46546F",
                     ListPrice = 90,
                     Price = 85,
                     Price50 = 80,
                     Price100 = 75,
                     CategoryID = 3,
                     ImageUrl = ""

                 },
                  new Product
                  {
                      PId = 3,
                      Title = "The Hunger Games",
                      Author = "Suzanne Collins",
                      Description = "teenagers are selected to compete in a televised death match",
                      ISBN = "SJHBFHJN567",
                      ListPrice = 70,
                      Price = 65,
                      Price50 = 60,
                      Price100 = 56,
                      CategoryID = 1,
                      ImageUrl = ""
                  }
                );
        }
    }

	
}

