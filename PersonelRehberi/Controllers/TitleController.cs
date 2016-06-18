using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelRehberi.Models;

namespace PersonelRehberi.Controllers
{
    public class TitleController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Title/

        public ActionResult Index()
        {
            return View(db.TITLE.ToList());
        }

        //
        // GET: /Title/Details/5

        public ActionResult Details(int id = 0)
        {
            TITLE title = db.TITLE.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // GET: /Title/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Title/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TITLE title)
        {
            if (ModelState.IsValid)
            {
                db.TITLE.Add(title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(title);
        }

        //
        // GET: /Title/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TITLE title = db.TITLE.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // POST: /Title/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TITLE title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(title);
        }

        //
        // GET: /Title/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TITLE title = db.TITLE.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // POST: /Title/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TITLE title = db.TITLE.Find(id);
            db.TITLE.Remove(title);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}