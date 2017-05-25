using GoContributeMe.BLL;
using GoContributeMe.Gateway;
using GoContributeMe.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GoContributeMe.Controllers
{
    public class HomeController : Controller
    {
        UserManager aUserManager = new UserManager();
        UserGateway aUserGateway = new UserGateway();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(ContactUsUserViewModel aUser)
        {
            if (ModelState.IsValid)
            {
                var dateAndTime = DateTime.Now;
                var date = dateAndTime.Date;
                aUser.ContactUs.Date = date;
                aUserManager.ContactInfoCustomer(aUser.ContactUs);
                ModelState.Clear();                                        //Clear model such as ContactUs            
            }
            return View();
        }


        public ActionResult About()
        {

            return View();
        }
        [HttpPost]
        public ActionResult About(ContactUsUserViewModel email)
        {
            if (ModelState.IsValid)
            {
                aUserGateway.Subscriber(email.Subscriber.Email);
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Search(ViewModelCampaign searchKey)
        {

            List<ViewAllDataInfo> campaign = aUserManager.SearchKey(searchKey.Campaign.Tittle);
            ViewBag.Campaign = campaign;
            return View();

        }

        public ActionResult All()
        {

            ViewBag.All = aUserGateway.AllData();

            return View();
        }
    }
}