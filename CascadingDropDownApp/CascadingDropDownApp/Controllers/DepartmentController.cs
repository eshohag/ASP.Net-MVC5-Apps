using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Departments = GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Index(int departmentId, int studentId)
        {
            ViewBag.Departments = GetDepartments();
            return View();
        }

        public JsonResult GetStudentsByDepartmentId(int departmentId)
        {
            var students = GetStudents();
            var studentList = students.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }

        private List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>
            {
                new Department {DepartmentId = 1, Name = "Computer Science & Engineering"},
                new Department {DepartmentId = 2, Name = "Electrical & Electronics Engineering"},
                new Department {DepartmentId = 3, Name = "Information Technology"}
            };
            return departments;
        }

        private List<Student> GetStudents()
        {
            List<Student> students = new List<Student>
            {
                 new Student{StudentId = 1,Name = "Soyeb",DepartmentId = 1},
                 new Student{StudentId = 2,Name = "Shohag",DepartmentId = 2},
                 new Student{StudentId = 3,Name = "Saiful",DepartmentId = 3},
                 new Student{StudentId = 4,Name = "Tonmoy",DepartmentId = 3},
                 new Student{StudentId = 5,Name = "Sourave",DepartmentId = 1},
                 new Student{StudentId = 6,Name = "Shawon",DepartmentId = 2}
            };
            return students;
        }
    }
}