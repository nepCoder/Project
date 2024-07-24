using System;
using Microsoft.EntityFrameworkCore;
using Bulky.Models;
namespace Bulky.DataAccess.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Action", DisplayOrder = 1 },
                new Category { ID = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { ID = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    PId=1,
                    Title="Ranger",
                    Author="John Doe",
                    Description="Action related",
                    ISBN="SJFK46546F",
                    ListPrice=99,
                    Price=95,
                    Price50=90,
                    Price100=85,
                    CategoryID=1,
                    ImageUrl = ""


                },
                 new Product
                 {
                     PId = 2,
                     Title = "Book of Gangster",
                     Author = "Roman Reigns",
                     Description = "Thriller",
                     ISBN = "SJFK46546F",
                     ListPrice= 99,
                     Price= 95,
                     Price50= 90,
                     Price100= 85,
                     CategoryID=1,
                     ImageUrl = ""

                 },
                  new Product
                  {
                      PId = 3,
                      Title = "Book of Fortune",
                      Author = "John Cena",
                      Description = "Fortune of your",
                      ISBN = "SJFK46546F",
                      ListPrice = 99,
                      Price = 95,
                      Price50 = 90,
                      Price100 = 85,
                      CategoryID=1,
                      ImageUrl=""
                  }
                );
        }
    }

	
}

