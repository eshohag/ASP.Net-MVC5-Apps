using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChEBUTEApps.Models;

namespace ChEBUTEApps.Controllers
{
    public class NoticeBoardController : Controller
    {
        // GET: NoticeBoard
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Notice aNotice)
        {
            
            //FireBase Connect



            ViewBag.Message = "Under Processing...";
            return View();
        }

        public ActionResult News()
        {
            return View();
        }
    }
}