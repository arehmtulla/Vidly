using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}