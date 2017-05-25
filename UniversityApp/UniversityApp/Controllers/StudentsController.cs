using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UniversityApp.Context;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    public class StudentsController : Controller
    {
        private StudentDbContext db = new StudentDbContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Address);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Addresses, "StudentID", "District");
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Code");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Addresses, "StudentID", "District", student.StudentID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Code", student.DepartmentID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Addresses, "StudentID", "District", student.StudentID);

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Code", student.DepartmentID);

            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                Student aStudent = new Student()
                {
                    Email = student.Email,
                    DepartmentID = student.DepartmentID,
                    Name = student.Name,
                    StudentID = student.StudentID

                };
                db.Entry(aStudent).State = EntityState.Modified;


                Address anAddress = new Address()
                {
                    StudentID = student.StudentID,
                    District = student.Address.District
                };
                db.Entry(anAddress).State = EntityState.Modified;

                db.SaveChanges();


                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Addresses, "StudentID", "District", student.StudentID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Code", student.DepartmentID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);   //Remove Student Table Data only one id

            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);  //Remove Address Table Data only one id
            db.SaveChanges();              //Database save Change

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
