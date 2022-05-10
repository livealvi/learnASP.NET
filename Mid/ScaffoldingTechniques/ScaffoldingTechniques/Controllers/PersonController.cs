using ScaffoldingTechniques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScaffoldingTechniques.Controllers
{
    public class PersonController : Controller
    {
        static List<Person> persons = new List<Person>()
       {
           new Person{Id=1, Name="Alvi", Email="livealvi@gmail.com", Salary=2000},
           new Person{Id=2, Name="Hasan", Email="hasani@gmail.com", Salary=3000},
           new Person{Id=3, Name="Rhaim", Email="rhaim@gmail.com", Salary=56000},
           new Person{Id=4, Name="Karim", Email="karim@gmail.com", Salary=7000}
       };
        public ActionResult Index()
        {
            return View(persons);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Person p = persons.Where(x => x.Id == id).First();
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(int id,Person p)
        {
            Person personToUpdate = persons.Where(x => x.Id == id).First();
            personToUpdate.Id = id;
            personToUpdate.Name = p.Name;
            personToUpdate.Email = p.Email;
            personToUpdate.Salary = p.Salary;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person p)
        {
            persons.Add(p);
            return RedirectToAction("Index");
        }
    }
}