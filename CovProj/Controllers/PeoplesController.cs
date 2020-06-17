using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CovProj.Models;

namespace CovProj.Controllers
{
    public class PeoplesController : Controller
    {
        private CovidDBContext db = new CovidDBContext();

        // GET: Peoples
        public ActionResult Index()
        {
            return View(db.peoples.ToList());
        }

        // GET: Peoples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peoples peoples = db.peoples.Find(id);
            if (peoples == null)
            {
                return HttpNotFound();
            }
            return View(peoples);
        }

        // GET: Peoples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peoples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeoplesId,FirstName,LastName,Identification,PhoneNumber,Address,Email,City,BirthDate,IsAdmin")] Peoples peoples)
        //Password field removed
        {
            if (ModelState.IsValid)
            {
                db.peoples.Add(peoples);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peoples);
        }

        // GET: Peoples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peoples peoples = db.peoples.Find(id);
            if (peoples == null)
            {
                return HttpNotFound();
            }
            return View(peoples);
        }

        // POST: Peoples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeoplesId,FirstName,LastName,Identification,PhoneNumber,Address,Email,City,BirthDate,IsAdmin")] Peoples peoples)
            //Password field removed
        {
            if (ModelState.IsValid)
            {
                db.Entry(peoples).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peoples);
        }

        // GET: Peoples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peoples peoples = db.peoples.Find(id);
            if (peoples == null)
            {
                return HttpNotFound();
            }
            return View(peoples);
        }

        // POST: Peoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peoples peoples = db.peoples.Find(id);
            db.peoples.Remove(peoples);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SearchPerson(Peoples person)
        {
            if (person.City == null)
                person.City = "null";

            if (person.Address == null)
                person.Address = "null";

            if (person.PhoneNumber == null)
                person.PhoneNumber = "null";

            List<Peoples> Persons = db.peoples.Where(p => p.City.Contains(person.City) &&
                                                  p.Address.Contains(person.Address) &&
                                                  p.PhoneNumber.Contains(person.PhoneNumber)).ToList();

            if (Persons.Count == 0 || person == null)
                return View("NoResults");

            return View(Persons);
        }
        public ActionResult NoResults()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
