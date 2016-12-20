using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegisterMVC.Models;

namespace RegisterMVC.Controllers
{
    public class SClassesController : Controller
    {
        private RegisterContext db = new RegisterContext();

        // GET: SClasses
        public ActionResult Index()
        {
            var sClasses = db.SClasses.Include(s => s.Teacher);
            return View(sClasses.ToList());
        }

        // GET: SClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SClass sClass = db.SClasses.Find(id);
            if (sClass == null)
            {
                return HttpNotFound();
            }
            return View(sClass);
        }

        // GET: SClasses/Create
        public ActionResult Create()
        {
            ViewBag.SClassID = new SelectList(db.Teachers, "TeacherID", "Name");
            return View();
        }

        // POST: SClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SClassID,Name,TeacherID")] SClass sClass)
        {
            if (ModelState.IsValid)
            {
                db.SClasses.Add(sClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SClassID = new SelectList(db.Teachers, "TeacherID", "Name", sClass.SClassID);
            return View(sClass);
        }

        // GET: SClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SClass sClass = db.SClasses.Find(id);
            if (sClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.SClassID = new SelectList(db.Teachers, "TeacherID", "Name", sClass.SClassID);
            return View(sClass);
        }

        // POST: SClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SClassID,Name,TeacherID")] SClass sClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SClassID = new SelectList(db.Teachers, "TeacherID", "Name", sClass.SClassID);
            return View(sClass);
        }

        // GET: SClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SClass sClass = db.SClasses.Find(id);
            if (sClass == null)
            {
                return HttpNotFound();
            }
            return View(sClass);
        }

        // POST: SClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SClass sClass = db.SClasses.Find(id);
            db.SClasses.Remove(sClass);
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
