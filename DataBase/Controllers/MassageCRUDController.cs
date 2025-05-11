using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBase;
using DataBase.Models;

namespace DataBase.Controllers
{
    public class MassageCRUDController : Controller
    {
        private Massage_SalonEntities db = new Massage_SalonEntities();

        // GET: MassageCRUD
        public ActionResult Index()
        {
            var massages = db.Massage.ToList(); // откуда идут данные
            return View(massages);
        }


        // GET: MassageCRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Massage massage = db.Massage.Find(id);
            if (massage == null)
            {
                return HttpNotFound();
            }
            return View(massage);
        }

        // GET: MassageCRUD/Create
        public ActionResult Create()
        {
            return View("~/Views/MassageCRUD/Create.cshtml");
        }

        // POST: MassageCRUD/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ImageUrl,Price")] Massage massage)
        {
            if (ModelState.IsValid)
            {
                db.Massage.Add(massage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/MassageCRUD/Create.cshtml");
        }


        // GET: MassageCRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Massage massage = db.Massage.Find(id);
            if (massage == null)
            {
                return HttpNotFound();
            }
            return View(massage);
        }

        // POST: MassageCRUD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ImageUrl,Price")] Massage massage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(massage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(massage);
        }

        // GET: MassageCRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Massage massage = db.Massage.Find(id);
            if (massage == null)
            {
                return HttpNotFound();
            }
            return View(massage);
        }

        // POST: MassageCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Massage massage = db.Massage.Find(id);
            db.Massage.Remove(massage);
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
