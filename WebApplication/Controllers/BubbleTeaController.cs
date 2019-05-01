using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BubbleTeaController : Controller
    {
        private CS4PEEntities db = new CS4PEEntities();

        // GET: /BubbleTea/
        public ActionResult Index()
        {
            var model = db.BubleTea.ToList();
            return View(model);
        }

        // GET: /BubbleTea/Details/5
        public ActionResult Details(int id)
        {
            BubleTea bubletea = db.BubleTea.Find(id);
            if (bubletea == null)
            {
                return HttpNotFound();
            }
            return View(bubletea);
        }

        // GET: /BubbleTea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BubbleTea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BubleTea model)
        {
            if (ModelState.IsValid)
            {
                db.BubleTea.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /BubbleTea/Edit/5
        public ActionResult Edit(int id)
        {
            BubleTea bubletea = db.BubleTea.Find(id);
            if (bubletea == null)
            {
                return HttpNotFound();
            }
            return View(bubletea);
        }

        // POST: /BubbleTea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BubleTea model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /BubbleTea/Delete/5
        public ActionResult Delete(int id)
        {
            BubleTea bubletea = db.BubleTea.Find(id);
            if (bubletea == null)
            {
                return HttpNotFound();
            }
            return View(bubletea);
        }

        // POST: /BubbleTea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = db.BubleTea.Find(id);
            db.BubleTea.Remove(model);
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
