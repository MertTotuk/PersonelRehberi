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
  
    public class DepatmentController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Depatment/
  public JsonResult getDepartment()
        {
            var dbResult = db.DEPARTMENT.ToList();
            var Department = (from department in dbResult
                          select new
                          {
                              department.DepartmentName
                              
                          });
            return Json(Department, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View(db.DEPARTMENT.ToList());
        }

        //
        // GET: /Depatment/Details/5

        public ActionResult Details(int id = 0)
        {
            DEPARTMENT department = db.DEPARTMENT.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        //
        // GET: /Depatment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Depatment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DEPARTMENT department)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTMENT.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        //
        // GET: /Depatment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DEPARTMENT department = db.DEPARTMENT.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        //
        // POST: /Depatment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DEPARTMENT department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        //
        // GET: /Depatment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DEPARTMENT department = db.DEPARTMENT.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        //
        // POST: /Depatment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPARTMENT department = db.DEPARTMENT.Find(id);
            db.DEPARTMENT.Remove(department);
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