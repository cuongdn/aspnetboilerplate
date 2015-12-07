using System.Web.Mvc;

namespace ContosoUniversity.Web.Controllers
{
    public class HomeController : ContosoUniversityControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}