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
    public class RecoveringsController : Controller
    {
        private CovidDBContext db = new CovidDBContext();

        // GET: Recoverings
        public ActionResult Index()
        {
            return View(db.recoverings.ToList());
        }

        // GET: Recoverings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recovering recovering = db.recoverings.Find(id);
            if (recovering == null)
            {
                return HttpNotFound();
            }
            return View(recovering);
        }

        // GET: Recoverings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recoverings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecoveringId")] Recovering recovering)
        {
            if (ModelState.IsValid)
            {
                db.recoverings.Add(recovering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recovering);
        }

        // GET: Recoverings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recovering recovering = db.recoverings.Find(id);
            if (recovering == null)
            {
                return HttpNotFound();
            }
            return View(recovering);
        }

        // POST: Recoverings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecoveringId")] Recovering recovering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recovering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recovering);
        }

        // GET: Recoverings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recovering recovering = db.recoverings.Find(id);
            if (recovering == null)
            {
                return HttpNotFound();
            }
            return View(recovering);
        }

        // POST: Recoverings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recovering recovering = db.recoverings.Find(id);
            db.recoverings.Remove(recovering);
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
