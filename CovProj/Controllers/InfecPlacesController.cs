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
    public class InfecPlacesController : Controller
    {
        private CovidDBContext db = new CovidDBContext();

        // GET: InfecPlaces
        public ActionResult Index()
        {
            return View(db.infectedlaces.ToList());
        }

        // GET: InfecPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfecPlaces infecPlaces = db.infectedlaces.Find(id);
            if (infecPlaces == null)
            {
                return HttpNotFound();
            }
            return View(infecPlaces);
        }

        // GET: InfecPlaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InfecPlaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceId,City")] InfecPlaces infecPlaces)
        {
            if (ModelState.IsValid)
            {
                db.infectedlaces.Add(infecPlaces);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infecPlaces);
        }

        // GET: InfecPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfecPlaces infecPlaces = db.infectedlaces.Find(id);
            if (infecPlaces == null)
            {
                return HttpNotFound();
            }
            return View(infecPlaces);
        }

        // POST: InfecPlaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceId,City")] InfecPlaces infecPlaces)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infecPlaces).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infecPlaces);
        }

        // GET: InfecPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfecPlaces infecPlaces = db.infectedlaces.Find(id);
            if (infecPlaces == null)
            {
                return HttpNotFound();
            }
            return View(infecPlaces);
        }

        // POST: InfecPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfecPlaces infecPlaces = db.infectedlaces.Find(id);
            db.infectedlaces.Remove(infecPlaces);
            db.SaveChanges();
            return RedirectToAction("Index");
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
