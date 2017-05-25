using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationProcess.BLL;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        StudentManager aStudentManager=new StudentManager();
        CourseManager aCourseManager=new CourseManager();
        RoomManager aRoomManager=new RoomManager();
        DaysManager aDaysManager=new DaysManager();
        ClassRoomManager aClassRoomManager=new ClassRoomManager();      
        GradeManager aGradeManager=new GradeManager();
        ResultManager aResultManager=new ResultManager();
        ViewResultManager aViewResultManager=new ViewResultManager();
        ViewStudentDepartmentManager aStudentDepartmentManager=new ViewStudentDepartmentManager();
        ViewAllocatedClassRoomManager allocatedClassRoomManager=new ViewAllocatedClassRoomManager();
        // GET: Student
        public ActionResult Register()
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = new SelectList(AllDepartment, "DeptCode", "DeptName");

            return View();
        }
        [HttpPost]
        public ActionResult Register(Student aStudent)
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = new SelectList(AllDepartment, "DeptCode", "DeptName");

            string regno = aStudent.DepartmentCode + "-";
            regno += aStudent.Date.Year.ToString("000");
            regno += "-";
            int regNoId = aStudentManager.GetRowCount(regno);
            if (regNoId == 0)
            {
                regno += "00" + 1;
            }
            else
            {
                if (regNoId >= 1 && regNoId <= 9)
                {
                    int temp = regNoId + 1;
                    regno += "00" + temp;
                }
                else if (regNoId >= 10 && regNoId <= 99)
                {
                    int temp = regNoId + 1;
                    regno += "0" + temp;
                }
                else
                {
                    regno += "" + regNoId + 1;
                }
            }
            aStudent.RegNo = regno;



            if (ModelState.IsValid)
            {
                ViewBag.StudentsSaveMessage = aStudentManager.Save(aStudent);
            }
          
            return View();
        }

        public ActionResult ClassRoom()
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = AllDepartment;
            List<Room> AllRoom = aRoomManager.GetRooms();
            ViewBag.Rooms = AllRoom;

            List<Day> AllDay = aDaysManager.AllDays();
            ViewBag.Days = AllDay;

            return View();
        }
        [HttpPost]
        public ActionResult ClassRoom(AllocateClassRoom allocateClassRoom)
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = AllDepartment;


            List<Room> AllRoom = aRoomManager.GetRooms();
            ViewBag.Rooms = AllRoom;

            List<Day> AllDay = aDaysManager.AllDays();
            ViewBag.Days = AllDay;
 
            if (ModelState.IsValid)
            {
                ViewBag.SaveMessage = aClassRoomManager.Save(allocateClassRoom);
            }

            return View();
        }

        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var allCourse = aCourseManager.GetAllCourses();
            var teacherList = allCourse.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult ClassSchedualRoom()
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");
            return View();
        }
       
        public JsonResult GetAllocatedRoomViewByDepartmentId(int departmentId)
        {
            var aViewAllocatedClassRooms = allocatedClassRoomManager.GetAllViewAllocatedClassRoom();
            var seletedViewAllocatedClassRooms = aViewAllocatedClassRooms.Where(a => a.DeptId == departmentId).ToList();
            return Json(seletedViewAllocatedClassRooms, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult SaveResult()
        {
            List<ViewStudentDepartment> AllStudents = aStudentDepartmentManager.AllStudentDepartments();
            //ViewBag.StudentDepartment = new SelectList(AllStudents, "DepartmentId", "RegNo");
            ViewBag.StudentDepartment = AllStudents;

            ViewBag.AllGrades = aGradeManager.AllGrades();
            return View();
        }
        [HttpPost]
        public ActionResult SaveResult(Result aResult)
        {
            List<ViewStudentDepartment> AllStudents = aStudentDepartmentManager.AllStudentDepartments();
            //ViewBag.StudentDepartment = new SelectList(AllStudents, "DepartmentId", "RegNo");
            ViewBag.StudentDepartment = AllStudents;

            ViewBag.AllGrades = aGradeManager.AllGrades();


            ViewBag.ResultSave = aResultManager.Save(aResult);
            return View();
        }
        public JsonResult GetDepartmentByStudents(int rregNo)
        {
            var allTeacher = aStudentDepartmentManager.AllStudentDepartments();
            var teacherList = allTeacher.Where(a => a.StudentId == rregNo).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEnrollCourseByStdId(int studentIdforCourse)
        {
            var aViewEnrollCourses = aResultManager.GetAllEnrolledCourse();
            var aViewEnrollCoursesList = aViewEnrollCourses.Where(a => a.StudentId == studentIdforCourse).ToList();
            return Json(aViewEnrollCoursesList, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DisplayResult()
        {
            List<ViewStudentDepartment> AllStudents = aStudentDepartmentManager.AllStudentDepartments();
            //ViewBag.StudentDepartment = new SelectList(AllStudents, "DepartmentId", "RegNo");
            ViewBag.StudentDepartment = AllStudents;

            ViewBag.AllResult = aViewResultManager.GetAllResults();
            return View();
        }

        [HttpPost]
        public ActionResult DisplayResult(ViewResultStudent aStudent)
        {
            List<ViewStudentDepartment> AllStudents = aStudentDepartmentManager.AllStudentDepartments();
            //ViewBag.StudentDepartment = new SelectList(AllStudents, "DepartmentId", "RegNo");
            ViewBag.StudentDepartment = AllStudents;
            ViewBag.AllResult = aViewResultManager.GetAllResults();
            return View();
        }
        public ActionResult GeneratePdf()
        {
            return new Rotativa.ActionAsPdf("DisplayResult");
        }
        public JsonResult ViewResultByStudentId(int studentId)
        {
            var aViewEnrollCourses = aViewResultManager.GetAllResults();
            var aViewEnrollCoursesList = aViewEnrollCourses.Where(a => a.StudentId == studentId).ToList();
            return Json(aViewEnrollCoursesList, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UnallocatedRoom()
        {
            return View();
        }
    }
}