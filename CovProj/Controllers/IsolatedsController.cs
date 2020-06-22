using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using CovProj.Models;

namespace CovProj.Controllers
{
    public class IsolatedsController : Controller
    {
        private CovidDBContext db = new CovidDBContext();

        // GET: Isolateds
        public ActionResult Index()
        {
            return View(db.isolateds.ToList());
        }

        // GET: Isolateds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Isolated isolated = db.isolateds.Find(id);
            if (isolated == null)
            {
                return HttpNotFound();
            }
            return View(isolated);
        }

        // GET: Isolateds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Isolateds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IsolatedId,PlaceOfIsolation")] Isolated isolated)
        {
            if (ModelState.IsValid)
            {
                db.isolateds.Add(isolated);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(isolated);
        }

        // GET: Isolateds/Edit/5'
 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Isolated isolated = db.isolateds.Find(id);
            if (isolated == null)
            {
                return HttpNotFound();
            }
            return View(isolated);
        }
        [HttpPost]
        public ActionResult CheckId(int? id)
        {
            if (id == null)
                return View("IdNotFound");
            long count = db.peoples.LongCount(u => u.Identification == id);
            if (count != 0)
            {
                return View("Create");
            }
            return View("IdNotFound");
        }
        // POST: Isolateds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IsolatedId,PlaceOfIsolation")] Isolated isolated)
        {
            if (ModelState.IsValid)
            {
                db.Entry(isolated).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(isolated);
        }

        // GET: Isolateds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Isolated isolated = db.isolateds.Find(id);
            if (isolated == null)
            {
                return HttpNotFound();
            }
            return View(isolated);
        }

        // POST: Isolateds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Isolated isolated = db.isolateds.Find(id);
            db.isolateds.Remove(isolated);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IdChecker()
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
