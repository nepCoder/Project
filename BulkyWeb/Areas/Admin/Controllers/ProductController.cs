using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/

        private readonly IUnitOfWork _unitOfWork;
        //webhost environment is used for saving image
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            List<Product> objProductsList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
            return View(objProductsList);
        }
        public IActionResult Upsert(int? id)
        {
     
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;

            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryID.ToString()
                }),
                Product = new Product()
        };
            if(id == 0 || id == null)
            {
                //create
            return View(productVM);

            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.Get(u => u.PId == id);
                return View(productVM);
            }
        }

        [HttpPost]

        public IActionResult Upsert(ProductVM productVm, IFormFile? file)
        {
            
            if(ModelState.IsValid)
            {
                //for image to be added in the root folder and save
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    //for giving an random name to the image
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    //to navigate to images and product
                    string productPath = Path.Combine(wwwRootPath, @"images/product");

                    //for handling the image in  update
                    if (!string.IsNullOrEmpty(productVm.Product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVm.Product.ImageUrl.TrimStart());
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    //to save the file

                    using( var filestream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    productVm.Product.ImageUrl = @"/images/product/" + fileName;
                }

                if (productVm.Product.PId == 0)
                {
                _unitOfWork.Product.Add(productVm.Product);

                }
                else
                {
                    _unitOfWork.Product.Update(productVm.Product);

                }

                _unitOfWork.Save();
            TempData["Success"] = "Created Succesfully";
            return RedirectToAction("Index", "Product");
            }
            else
            {

                productVm.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryID.ToString()
                });
              
            }
            return View(productVm);

        }

        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    Product? objProduct = _unitOfWork.Product.Get(u => u.PId == id);

        //    if (objProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(objProduct);
        //}

        //[HttpPost]

        //public IActionResult Edit(Product obj)
        //{
        //    _unitOfWork.Product.Add(obj);
        //    _unitOfWork.Save();
        //    TempData["Succes"] = "Edited Succesfully";

        //    return View();
        //}

        //public IActionResult Delete(int? id)
        //{
        //    if(id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product? objProduct = _unitOfWork.Product.Get(u => u.PId == id);

        //    if (objProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(objProduct);
        //}

        //[HttpPost, ActionName("Delete")]

        //public IActionResult DeletePost(int? id)
        //{
        //    Product? objProduct = _unitOfWork.Product.Get(u => u.PId == id);

        //    if (objProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Product.Remove(objProduct);
        //    _unitOfWork.Save();
        //    TempData["Success"] = "Deleted Succesfully";

        //    return RedirectToAction("Index", "Product");
        //}


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductsList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return  Json(new {data=objProductsList });
        }
        [HttpDelete]

        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.PId == id);
            if (productToBeDeleted==null)
            {
                return Json(new { success = false, message="Error while deleting" }); ;
            }
            var oldImagePath = Path.Combine( _webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart());
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success=true, message="Deleted Succesfully" });
        }
        #endregion
    }
}

