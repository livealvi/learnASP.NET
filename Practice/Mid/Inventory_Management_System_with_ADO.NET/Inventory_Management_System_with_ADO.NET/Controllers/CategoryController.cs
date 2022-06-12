using Inventory_Management_System_with_ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System_with_ADO.NET.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            CategoryDataAccess cda = new CategoryDataAccess(); 
            return View(cda.GetAllCategories());
        }


        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cate)
        {
            CategoryDataAccess cda = new CategoryDataAccess();
            int i = cda.InsertCategory(cate);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CategoryDataAccess cda = new CategoryDataAccess();
            return View(cda.GetCategoryById(id));
        }

        [HttpPost]
        public ActionResult Edit(Category cate)
        {
            CategoryDataAccess cda = new CategoryDataAccess();
            int i = cda.UpdateCategory(cate);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CategoryDataAccess cda = new CategoryDataAccess();
            return View(cda.GetCategoryById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            CategoryDataAccess cda = new CategoryDataAccess();
            int i = cda.DeleteCategory(id);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}