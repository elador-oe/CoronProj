﻿using System;
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
    public class SicksController : Controller
    {
        private CovidDBContext db = new CovidDBContext();

        // GET: Sicks
        public ActionResult Index()
        {
            return View(db.sicks.ToList());
        }

        // GET: Sicks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sick sick = db.sicks.Find(id);
            if (sick == null)
            {
                return HttpNotFound();
            }
            return View(sick);
        }

        // GET: Sicks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sicks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeoplesId,places,Placeid")] Sick sick)
        {
            if (ModelState.IsValid)
            {
                string place = sick.places.City;
                sick.Place = place;
                db.sicks.Add(sick);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sick);
        }

        // GET: Sicks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sick sick = db.sicks.Find(id);
            if (sick == null)
            {
                return HttpNotFound();
            }
            return View(sick);
        }

        // POST: Sicks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SickId,Place")] Sick sick)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sick).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sick);
        }

        // GET: Sicks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sick sick = db.sicks.Find(id);
            if (sick == null)
            {
                return HttpNotFound();
            }
            return View(sick);
        }

        // POST: Sicks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sick sick = db.sicks.Find(id);
            db.sicks.Remove(sick);
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
