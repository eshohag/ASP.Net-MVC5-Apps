using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChEBUTEApps.Models;

namespace ChEBUTEApps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Faculty()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Staff()
        {
            return View();
        }

        public ActionResult Login( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login aLogin)
        {
            if (aLogin.UserName=="Shohag")
            {

                return View("Index");
            }
            ViewBag.Messagae = "Wrong User Name or Password";
            return View();
        }
    }
}