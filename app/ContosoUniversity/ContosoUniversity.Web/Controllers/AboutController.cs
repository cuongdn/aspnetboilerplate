using System.Web.Mvc;

namespace ContosoUniversity.Web.Controllers
{
    public class AboutController : ContosoUniversityControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}