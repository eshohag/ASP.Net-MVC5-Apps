using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationProcess.BLL;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        DesignationManager aDesignationManager=new DesignationManager();
        TeacherManager aTeacherManager=new TeacherManager();

        // GET: Teacher
        public ActionResult SaveTeacher()
        {
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");

            List<Designation> AllDesignation = aDesignationManager.AllDesignations();
            ViewBag.Designations = new SelectList(AllDesignation, "DesignationId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            aTeacher.RemainingCredit = aTeacher.CreditToBeTaken;
            if (ModelState.IsValid)
            {
                ViewBag.SaveTeacherMessage = aTeacherManager.Save(aTeacher);
            }
            List<Department> AllDepartment = aDepartmentManager.GetAllDepartments();
            ViewBag.Departments = new SelectList(AllDepartment, "DeptId", "DeptName");

            List<Designation> AllDesignation = aDesignationManager.AllDesignations();
            ViewBag.Designations = new SelectList(AllDesignation, "DesignationId", "Name");
            return View();
        }
        
    }
}