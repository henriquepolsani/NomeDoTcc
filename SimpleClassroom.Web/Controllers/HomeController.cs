using System.Web.Mvc;

namespace SimpleClassroom.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}