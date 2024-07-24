using System;
using Bulky.Models;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Data;


namespace Bulky.DataAccess.Repository
{
	public class ProductRepository: Repository<Product>,IProductRepository
	{
		private ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db):base(db)
		{
			_db = db;
		}
		public void Update(Product obj)
		{
			var objFromDb = _db.Products2.FirstOrDefault(u => u.PId == obj.PId);

			if (objFromDb != null)
			{
				objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Author = obj.Author;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.CategoryID = obj.CategoryID;
				if (obj.ImageUrl != null)
				{
                    objFromDb.ImageUrl = obj.ImageUrl;

                }
				objFromDb.Category = obj.Category;
            }
        }

	}
}

