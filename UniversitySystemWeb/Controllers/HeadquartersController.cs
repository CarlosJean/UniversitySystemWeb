using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversitySystemWeb.Models;

namespace UniversitySystemWeb.Controllers
{
    public class HeadquartersController : Controller
    {
        private UniversityDb db = new UniversityDb();

        // GET: Headquarters
        public ActionResult Index()
        {
            return View(db.Headquarters.ToList());
        }

        // GET: Headquarters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headquarter headquarter = db.Headquarters.Find(id);
            if (headquarter == null)
            {
                return HttpNotFound();
            }
            return View(headquarter);
        }

        // GET: Headquarters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Headquarters/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeadquartersId,Name,Address,Phone")] Headquarter headquarter)
        {
            if (ModelState.IsValid)
            {
                db.Headquarters.Add(headquarter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(headquarter);
        }

        // GET: Headquarters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headquarter headquarter = db.Headquarters.Find(id);
            if (headquarter == null)
            {
                return HttpNotFound();
            }
            return View(headquarter);
        }

        // POST: Headquarters/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeadquartersId,Name,Address,Phone")] Headquarter headquarter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headquarter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headquarter);
        }

        // GET: Headquarters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headquarter headquarter = db.Headquarters.Find(id);
            if (headquarter == null)
            {
                return HttpNotFound();
            }
            return View(headquarter);
        }

        // POST: Headquarters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Headquarter headquarter = db.Headquarters.Find(id);
            db.Headquarters.Remove(headquarter);
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
