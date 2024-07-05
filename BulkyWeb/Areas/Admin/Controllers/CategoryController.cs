using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky.DataAccess.Repository.IRepository;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitofWork;
        public CategoryController(IUnitOfWork db)
        {
            _unitofWork = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitofWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        //To add data in database using a form post method
        [HttpPost]
        public IActionResult Create(Category obj) // here obj will catch the data inserted
        {
            if(obj.Name== obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display Error Must not be same");
            }
            if (ModelState.IsValid)
            {
                _unitofWork.Category.Add(obj); // it will add the obj data to the database
                _unitofWork.Save();  // it will save chnage the data base
                TempData["success"] = "Created SuccessFully";
                return RedirectToAction("Index", "Category");
            }
            return View();
             // second one is for controller
        }

        //edit page
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0){

                    return NotFound();
                    }
            Category? objCategory = _unitofWork.Category.Get(u=>u.ID==id);
            //Category? objCategory1 = _db.Categories.FirstOrDefault(u=>u.ID==id);
            //Category? objCategory2 = _db.Categories.Where(u=>u.ID==id).FirstOrDefault();

            if (objCategory == null){

                return NotFound();
            }
            return View(objCategory);
        }
 
        [HttpPost]
        public IActionResult Edit(Category obj) 
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Category.Update(obj);
                _unitofWork.Save();
                TempData["success"] = "Updated SuccessFully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        
        }
        //Delete Page
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();
            }
            Category? objCategory = _unitofWork.Category.Get(u => u.ID == id);

            if (objCategory == null)
            {

                return NotFound();
            }
            return View(objCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _unitofWork.Category.Get(u => u.ID == id);

            if (obj == null)
            {

                return NotFound();
            }
            _unitofWork.Category.Remove(obj);
            _unitofWork.Save();
            TempData["success"] = "Deleted SuccessFully";
            return RedirectToAction("Index", "Category");

        }
    }
}