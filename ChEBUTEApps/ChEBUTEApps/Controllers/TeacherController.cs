using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChEBUTEApps.Models;

namespace ChEBUTEApps.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTeacher(Teacher aTeacher)
        {

            //FireBase Connect
            ViewBag.Message = "Under Processing...";
            return View();
        }
    }
}