using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGeekAcademy.Models;

namespace MvcGeekAcademy.Controllers
{
    public class studentsController : Controller
    {
        private MvcGeeksDbContext db = new MvcGeeksDbContext();

        // GET: students
        [HttpGet]
        public ActionResult Index(string search,string sortByName = "asc")
        {
            IEnumerable<student> studentList = db.students;
            if (search != null)
            {
                studentList = db.students.Where(e => e.FullNAme.Contains(search));
            }



            if (sortByName == "desc")
                studentList = studentList.OrderByDescending(i => i.FullNAme).ToList();//.ToPagedList(page ?? 1, 5);             
            else
                studentList = studentList.OrderBy(i => i.FullNAme).ToList();//.ToPagedList(page ?? 1, 5);


            // iPagedList = iList.ToPagedList(page ?? 1, 5);

            // return View(iList);
            return View(studentList);
           // return View(db.students.ToList());
        }
        //[HttpPost]
        //public ActionResult Index(string search)
        //{

        //}

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FullNAme,Gender,ContactNo,Email,DateOfBirth,FinalMarks")] student student)
        {
            

            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FullNAme,Gender,ContactNo,Email,DateOfBirth,FinalMarks")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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
