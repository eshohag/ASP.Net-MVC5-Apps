using System.Web.Mvc;

namespace GoContributeMe.Controllers
{
    public class ContributeController : Controller
    {
        // GET: Contribute
        [Route("Contribute/User")]
        public ActionResult User()
        {
            return View();
        }
        [Route("Contribute")]
        public ActionResult Public()
        {
            return View();
        }
    }
}