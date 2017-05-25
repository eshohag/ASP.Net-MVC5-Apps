using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationProcess.BLL;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Controllers
{
    public class HomeController : Controller
    {
        DepartmentManager aDepartmentManager=new DepartmentManager();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveDept()
        {                
            return View();
        }

        [HttpPost]
        public ActionResult SaveDept(Department aDepartment)
        {
            
            ViewBag.SaveMessage = aDepartmentManager.Save(aDepartment);
          
            return View();
        }


        public ActionResult ViewAll()
        {
            List<Department>AllDepartments=aDepartmentManager.GetAllDepartments();
            ViewBag.GetAllDepartments = AllDepartments;
            ViewBag.TotalCountRow = AllDepartments.Count;
            return View();
        }
    }
}