using System.Web.Mvc;

namespace GoContributeMe.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [Route("Password")]
        public ActionResult WrongPassword()
        {
            return View();
        }
        [Route("Log-Out")]
        public ActionResult LogOut()
        {
            return View();
        }
        [Route("Email")]
        public ActionResult AlreadyEnterEmail()
        {
            return View();
        }
    }
}