using Service.Core;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.InterestedBoxes = new BoxService().GetAll();
            ViewBag.Clients = new ClientService().GetAll();
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

        public ActionResult NoAccess()
        {
            return View();
        }
    }
}