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
    public class HealtiesController : Controller
    {
        private CovidDBContext db = new CovidDBContext();

        // GET: Healties
        public ActionResult Index()
        {
            return View(db.healties.ToList());
        }

        // GET: Healties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Healty healty = db.healties.Find(id);
            if (healty == null)
            {
                return HttpNotFound();
            }
            return View(healty);
        }

        // GET: Healties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Healties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HealthyId")] Healty healty)
        {
            if (ModelState.IsValid)
            {
                db.healties.Add(healty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(healty);
        }

        // GET: Healties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Healty healty = db.healties.Find(id);
            if (healty == null)
            {
                return HttpNotFound();
            }
            return View(healty);
        }

        // POST: Healties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HealthyId")] Healty healty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(healty);
        }

        // GET: Healties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Healty healty = db.healties.Find(id);
            if (healty == null)
            {
                return HttpNotFound();
            }
            return View(healty);
        }

        // POST: Healties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Healty healty = db.healties.Find(id);
            db.healties.Remove(healty);
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
