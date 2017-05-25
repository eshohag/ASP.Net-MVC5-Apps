using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationProcess.BLL;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager aSemesterManager = new SemesterManager();
        CourseManager aCourseManager = new CourseManager();
        TeacherManager aTeacherManager = new TeacherManager();
        ViewCourseStaticsManager aCourseStaticsManager = new ViewCourseStaticsManager();
        StudentManager aStudentManager = new StudentManager();
        ViewStudentDepartmentManager aStudentDepartmentManager = new ViewStudentDepartmentManager();
        // GET: Course
        public ActionResult SaveCourse()
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");

            List<Semester> AllSemester = aSemesterManager.GetAllSemesters();
            ViewBag.Semesters = new SelectList(AllSemester, "SemesterId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SaveMessage = aCourseManager.Save(aCourse);
            }
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");
            List<Semester> AllSemester = aSemesterManager.GetAllSemesters();
            ViewBag.Semesters = new SelectList(AllSemester, "SemesterId", "Name");
            return View();
        }
        public ActionResult AssignTeacher()
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            //ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");
            ViewBag.AllDepartment = AllDepartment;

            return View();
        }
        [HttpPost]
        public ActionResult AssignTeacher(AssignTeacher assignTeacher)
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ////ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");
            ViewBag.AllDepartment = AllDepartment;
            ViewBag.SaveMessage = aCourseManager.SaveAssignCourseToTeacher(assignTeacher);

            return View();
        }
        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var allTeacher = aTeacherManager.AllTeachers();
            var teacherList = allTeacher.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var allCourse = aCourseManager.GetAllCourses();
            var teacherList = allCourse.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTeacherById(int teacherId)
        {
            var aTeacher = aTeacherManager.AllTeachers();
            var teachers = aTeacher.Where(a => a.TeacherId == teacherId).ToList();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseById(int courseId)
        {
            var course = aCourseManager.GetAllCourses();
            var courseList = course.Where(a => a.CourseId == courseId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewStatics()
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            //ViewBag.Departments = AllDepartment;
            ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");
            List<ViewCourseStatics> AllCourse = aCourseStaticsManager.AllCourseStatics();
            ViewBag.AllCourse = AllCourse;

            return View();
        }
        [HttpPost]
        public ActionResult ViewStatics(Department aDepartment)
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            //ViewBag.Departments = AllDepartment;
            ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");
            List<ViewCourseStatics> AllCourse = aCourseStaticsManager.AllCourseStatics();
            ViewBag.AllCourse = AllCourse;
            return View();
        }
        public JsonResult GetCourseSemesterByDepartmentId(int deptId)
        {
            var allCourse = aCourseStaticsManager.AllCourseStatics();
            var Course = allCourse.Where(a => a.DeptId == deptId).ToList();
            return Json(Course, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Enroll()
        {
            //ViewBag.StudentInfo = aStudentManager.AllStudentInfo();
            List<ViewStudentDepartment> AllStudents = aStudentDepartmentManager.AllStudentDepartments();
            //ViewBag.StudentDepartment = new SelectList(AllStudents, "DepartmentId", "RegNo");
            ViewBag.StudentDepartment = AllStudents;




            return View();
        }
        [HttpPost]
        public ActionResult Enroll(ViewStudentDepartment aStudentDepartment)
        {
            //ViewBag.StudentInfo = aStudentManager.AllStudentInfo();
            List<ViewStudentDepartment> AllStudents = aStudentDepartmentManager.AllStudentDepartments();
            //ViewBag.StudentDepartment = new SelectList(AllStudents, "DepartmentId", "RegNo");
            ViewBag.StudentDepartment = AllStudents;


            ViewBag.EnrollSaveMessage = aStudentDepartmentManager.Save(aStudentDepartment);

            return View();
        }
        public JsonResult GetDepartmentByStudents(int rregNo)
        {
            var allTeacher = aStudentDepartmentManager.AllStudentDepartments();
            var teacherList = allTeacher.Where(a => a.StudentId == rregNo).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursesJsonResultById(int departmentId)
        {
            var course = aCourseManager.GetAllCourses();
            var courseList = course.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Unassign()
        {
            return View();
        }
    }
}