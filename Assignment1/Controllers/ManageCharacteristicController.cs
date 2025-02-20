﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class ManageCharacteristicController : Controller
    {
        private asp9Entities db = new asp9Entities();

        // GET: ManageCharacteristic
        public ActionResult Index()
        {
            return View(db.CHARACTERISTICs.ToList());
        }

        // GET: ManageCharacteristic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHARACTERISTIC cHARACTERISTIC = db.CHARACTERISTICs.Find(id);
            if (cHARACTERISTIC == null)
            {
                return HttpNotFound();
            }
            return View(cHARACTERISTIC);
        }

        // GET: ManageCharacteristic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageCharacteristic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CHAR_ID,CHAR_DESC")] CHARACTERISTIC cHARACTERISTIC)
        {
            if (ModelState.IsValid)
            {
                db.CHARACTERISTICs.Add(cHARACTERISTIC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHARACTERISTIC);
        }

        // GET: ManageCharacteristic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHARACTERISTIC cHARACTERISTIC = db.CHARACTERISTICs.Find(id);
            if (cHARACTERISTIC == null)
            {
                return HttpNotFound();
            }
            return View(cHARACTERISTIC);
        }

        // POST: ManageCharacteristic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CHAR_ID,CHAR_DESC")] CHARACTERISTIC cHARACTERISTIC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHARACTERISTIC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHARACTERISTIC);
        }

        // GET: ManageCharacteristic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHARACTERISTIC cHARACTERISTIC = db.CHARACTERISTICs.Find(id);
            if (cHARACTERISTIC == null)
            {
                return HttpNotFound();
            }
            return View(cHARACTERISTIC);
        }

        // POST: ManageCharacteristic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHARACTERISTIC cHARACTERISTIC = db.CHARACTERISTICs.Find(id);
            db.CHARACTERISTICs.Remove(cHARACTERISTIC);
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
