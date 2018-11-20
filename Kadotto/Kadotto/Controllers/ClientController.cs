using Common.Core;
using Service.Core;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    [AuthenticationFilter("Admin")]
    public class ClientController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Clients = new ClientService().GetAll();
            return View("~/Views/Client/Index.cshtml");
        }

        public ActionResult Details()
        {
            return PartialView("~/Views/Client/Details.cshtml");
        }

        public long Save(ClientDTO pClientDTO)
        {
            long Result = 0;
            if (pClientDTO.ID != 0)
            {
                Result = new ClientService().Edit(pClientDTO);
            }
            else
            {
                Result = new ClientService().Add(pClientDTO);
            }
            return Result;
        }

        public JsonResult GetByID(long ID)
        {
            var Result = new ClientService().GetByID(ID);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public long Delete(long ID)
        {
            var Result = new ClientService().Delete(ID);
            return Result;
        }
    }
}