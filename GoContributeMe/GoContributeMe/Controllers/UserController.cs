using GoContributeMe.BLL;
using GoContributeMe.Gateway;
using GoContributeMe.Models.Model;
using GoContributeMe.Models.ViewModel;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;


namespace GoContributeMe.Controllers
{
    public class UserController : Controller
    {
        UserManager aUserManager = new UserManager();
        UserGateway aUserGateway = new UserGateway();
        // GET: Account
        //[Route("Account")]
        public ActionResult Account()
        {

            return View();

        }
        //[HttpPost]
        //public ActionResult Account(ViewModelCampaign searchKey)
        //{
        //    TempData["searchKey"] = searchKey.Campaign.Tittle;

        //    return RedirectToAction("Search");

        //}

        public ActionResult Search(ViewModelCampaign searchKey)
        {

            List<ViewAllDataInfo> campaign = aUserManager.SearchKey(searchKey.Campaign.Tittle);
            ViewBag.Campaign = campaign;
            return View();

        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        // GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Index(ContactUsUserViewModel aUser)
        {
            if (aUser.User.UserName != null && aUser.User.Password != null)
            {
                User aUserOne = aUserManager.IsExisting(aUser.User);
                ModelState.Clear();   //Clear model such as User
                if (aUserOne != null)
                {
                    int ID = aUserOne.UserID;
                    ViewBag.UserID = ID;
                    ViewBag.Name = aUserOne.Name;
                    return View();
                }
                else
                {
                    return RedirectToAction("AlreadyEnterEmail", "Error");
                }
            }
            return RedirectToAction("WrongPassword", "Error");
        }




        //public ActionResult Register()
        //{
        //    return View();
        //}
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(ContactUsUserViewModel aUser)
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LeWPBMUAAAAAJX6n331lNia69xKYn7o2ODCP8DJ";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
            if (ModelState.IsValid && status == true)
            {
                string aUserOne = aUserManager.SaveUserInfo(aUser.User);
                if (aUserOne == "Success")
                {
                    string UserName = aUser.User.UserName;
                    string Password = aUser.User.Password;
                    ModelState.Clear();    //Clear model such as User
                    User anUser = new User();
                    anUser.UserName = UserName;
                    anUser.Password = Password;

                    User anOneUser = aUserManager.IsExisting(anUser);


                    ViewBag.UserID = anOneUser.UserID;
                    ViewBag.Name = anOneUser.Name;
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }

        public ActionResult All()
        {

            ViewBag.All = aUserGateway.AllData();
            return View();
        }
    }
}