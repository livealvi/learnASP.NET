using Inventory_Management_System_with_ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System_with_ADO.NET.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductDataAccess pda = new ProductDataAccess();
            return View(pda.GetAllProducts());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CategoryDataAccess cda = new CategoryDataAccess();
            ViewData["cats"] = cda.GetAllCategories();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product pros)
        {
            ProductDataAccess pro = new ProductDataAccess();
            int i = pro.InsertProduct(pros);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductDataAccess pro = new ProductDataAccess();

            return View(pro.GetProductById(id));
        }

        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            ProductDataAccess pro = new ProductDataAccess();
            int i = pro.UpdateProduct(prod);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}