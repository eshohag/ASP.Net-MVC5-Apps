using System.Web.Mvc;
using UniversityApp.Context;

namespace UniversityApp.Controllers
{
    public class RegistrationController : Controller
    {
        StudentDbContext db = new StudentDbContext();

        // GET: Registration
        public ActionResult Index()
        {
            //ViewBag.CourseList = db.Courses.ToList();
            //ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Code");
            return View();
        }
    }
}