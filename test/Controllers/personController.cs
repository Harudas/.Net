using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class personController : Controller
    {
        // GET: person

       Database1Entities db = new Database1Entities();


        public ActionResult Index()
        {
            var data = db.person.OrderByDescending(m => m.Id).ToList();
           
            return View(data);
        }

        // GET: person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: person/Create
        [HttpPost]
        public ActionResult Create(person id)
        {
            try
            {
                // TODO: Add insert logic here
                db.person.Add(id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: person/Edit/5
        public ActionResult Edit(int id)
        {
            var person_id = db.person.Where(m => m.Id == id).FirstOrDefault();
            return View(person_id);
        }

        // POST: person/Edit/5
        [HttpPost]
        public ActionResult Edit(person updata, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var person_id = db.person.Where(m => m.Id == updata.Id).FirstOrDefault();
                person_id.name = updata.name;
                person_id.phone = updata.phone;
                person_id.addr = updata.addr;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: person/Delete/5
        public ActionResult Delete(int id)
        {
            var person_id = db.person.Where(m => m.Id == id).FirstOrDefault();
            return View(person_id);
        }

        // POST: person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var person_id = db.person.Where(m => m.Id == id).FirstOrDefault();
                db.person.Remove(person_id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
