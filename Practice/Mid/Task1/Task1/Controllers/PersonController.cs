using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class PersonController : Controller
    {
        static List<Person> persons = new List<Person>()
        {
            new Person{Id = 1, Name ="Alvi", Age = 25, Address = "Jssore", Email="live@alvi@gmail.com"}
        };

        public ActionResult Index()
        {
            return View(persons);
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

        [HttpGet]
        public ActionResult Details(int id)
        {
            Person person = persons.Where(x => x.Id == id).First();
            return View(person);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Person person = persons.Where(x => x.Id == id).First();
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(int id, Person p)
        {
            Person personToUpdate = persons.Where(x => x.Id == id).First();
            personToUpdate.Id = id;
            personToUpdate.Name = p.Name;
            p.Age = personToUpdate.Age;
            personToUpdate.Address = personToUpdate.Address;
            personToUpdate.Email = personToUpdate.Email;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person person = persons.Where((x) => x.Id == id).First();
            return View(person);
        }

        [HttpPost]
        public ActionResult Delete(int id, string deletePerson)
        {
            Person personToDelete = persons.Where(x => x.Id == id).First();
            if (personToDelete != null)
                persons.Remove(personToDelete);
            return RedirectToAction("Index");

        }

    }
}