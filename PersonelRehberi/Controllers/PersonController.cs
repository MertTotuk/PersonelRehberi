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

    public class PersonController : Controller
    {

        private DBEntities db = new DBEntities();
        public JsonResult getPerson()
        {
            var dbResult = db.PERSON.ToList();
            var Person = (from person in dbResult
                          select new
                          {
                              person.Identity,
                              person.PersonName,
                              person.PersonSurname,
                              person.Birthdate,
                              person.Email,
                              person.PhoneNumber1,
                              person.PhoneNumber2,
                              person.HireDate,
                              person.TITLE.TitleName,
                              person.DEPARTMENT.DepartmentName,
                              person.Picture
                              
                             // Picture = person.Picture != null ? Convert.ToBase64String(person.Picture) : null
                          });
            return Json(Person, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getTitle()
        
        {
            var dbResult = db.TITLE.ToList();
            var Title = (from title in dbResult
                         select new
                         {
                             title.TitleId,
                             title.TitleName,
                             title.TitleDescription
                         });
            return Json(Title, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getDepartment()
        {
            var dbResult = db.DEPARTMENT.ToList();
            var Department = (from department in dbResult
                         select new
                         {
                             department.DepartmentId,
                             department.DepartmentName,
                             department.DepartmentDescription


                         });
            return Json(Department, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Person/

        public ActionResult Index()
        {
            var person = db.PERSON.Include(p => p.DEPARTMENT).Include(p => p.TITLE);
            return View(person.ToList());
        }

        //
        // GET: /Person/Details/5

        public ActionResult Details(int id = 0)
        {
            PERSON person = db.PERSON.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.DEPARTMENT, "DepartmentId", "DepartmentName");
            ViewBag.TitleId = new SelectList(db.TITLE, "TitleId", "TitleName");
            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(PERSON person)
        {
            //Byte[] imgByte = null;
            //HttpPostedFile File = (HttpPostedFile)file;
            //imgByte = new Byte[File.ContentLength];
            //File.InputStream.Read(imgByte, 0, File.ContentLength);

            if (ModelState.IsValid)
            {
                db.PERSON.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.DEPARTMENT, "DepartmentId", "DepartmentName", person.DepartmentId);
            ViewBag.TitleId = new SelectList(db.TITLE, "TitleId", "TitleName", person.TitleId);
            return View(person);
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(DEPARTMENT department)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTMENT.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }
        [HttpPost]
        public ActionResult CreateTitle(TITLE title)
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
        // GET: /Person/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PERSON person = db.PERSON.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.DEPARTMENT, "DepartmentId", "DepartmentName", person.DepartmentId);
            ViewBag.TitleId = new SelectList(db.TITLE, "TitleId", "TitleName", person.TitleId);
            return View(person);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PERSON person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.DEPARTMENT, "DepartmentId", "DepartmentName", person.DepartmentId);
            ViewBag.TitleId = new SelectList(db.TITLE, "TitleId", "TitleName", person.TitleId);
            return View(person);
        }

        //
        // GET: /Person/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    PERSON person = db.PERSON.Find(id);
        //    if (person == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(person);
        //}

        ////
        //// POST: /Person/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PERSON person = db.PERSON.Find(id);
        //    db.PERSON.Remove(person);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int? id)
        {
            PERSON person = db.PERSON.Find(id);
            db.PERSON.Remove(person);
            db.SaveChanges();
            return Json("true");
        }
        public ActionResult DeleteTitle(int? id)
        {
            TITLE title = db.TITLE.Find(id);
            db.TITLE.Remove(title);
            db.SaveChanges();
            return Json("true");
        }
        public ActionResult DeleteDepartment(int? id)
        {
            DEPARTMENT department = db.DEPARTMENT.Find(id);
            db.DEPARTMENT.Remove(department);
            db.SaveChanges();
            return Json("true");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [HttpPost]
        public JsonResult saveData(PERSON person)
        {
            PERSON personDb = db.PERSON.First<PERSON>(x => x.Identity == person.Identity);
            //person.DEPARTMENT = personDb.DEPARTMENT;
            person.DepartmentId = personDb.DepartmentId;
            person.TitleId = personDb.TitleId;
            person.TITLE = new TITLE { TitleId = person.TitleId };
            person.DEPARTMENT = new DEPARTMENT { DepartmentId = person.DepartmentId };

            if (ModelState.IsValid)
            {
                db.Entry(personDb).CurrentValues.SetValues(person);  

               // db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
               
            }
            //ViewBag.DepartmentId = new SelectList(db.DEPARTMENT, "DepartmentId", "DepartmentName", person.DepartmentId);
            //ViewBag.TitleId = new SelectList(db.TITLE, "TitleId", "TitleName", person.TitleId);
            return new JsonResult() { Data = string.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult saveDataTitle(TITLE title)
        {
            TITLE titledb = db.TITLE.First<TITLE>(x => x.TitleId == title.TitleId);
            title.TitleId = titledb.TitleId;
            if (ModelState.IsValid)
            {
                db.Entry(titledb).CurrentValues.SetValues(title);

                // db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();

            }
            return new JsonResult() { Data = string.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }
        [HttpPost]
        public JsonResult saveDataDepartment(DEPARTMENT department)
        {
            DEPARTMENT departmentdb = db.DEPARTMENT.First<DEPARTMENT>(x => x.DepartmentId == department.DepartmentId);
            department.DepartmentId = departmentdb.DepartmentId;
            if (ModelState.IsValid)
            {
                db.Entry(departmentdb).CurrentValues.SetValues(department);

                // db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();

            }
            return new JsonResult() { Data = string.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }
    }
}