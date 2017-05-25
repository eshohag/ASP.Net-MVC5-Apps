using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChEBUTEApps.BBL;
using ChEBUTEApps.Models;

namespace ChEBUTEApps.Controllers
{
    public class StudentCornerController : Controller
    {
        BatchManager aBatchManager=new BatchManager();



        // GET: StudentCorner
        public ActionResult Info()
        {
            return View();
        }

        public ActionResult File()
        {
           // ViewBag.BatchList=aBatchManager.GetBatchList();
            return View();

        }

        [HttpPost]
        public ActionResult File(Upload model)
        {
            //FireBase Connect
           // ViewBag.BatchList = aBatchManager.GetBatchList();
            ViewBag.Message = "Under Processing...";

            return View();
        }









        public ActionResult QuestionBank()
        {
            return View();
        }

        public ActionResult Library()
        {
            return View();
        }

        public ActionResult ModifyUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ModifyUpload(NewUpload aNewUpload)
        {
            //FireBase Connect here

            ViewBag.Message = "Under Processing...";
            return View();
        }

    }

}