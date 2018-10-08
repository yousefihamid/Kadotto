using Common.Core;
using Service.Core;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    [AuthenticationFilter("Admin")]
    public class BoxController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Boxes = new BoxService().GetAll();
            return View("~/Views/Box/Index.cshtml");
        }

        public ActionResult Details()
        {
            return PartialView("~/Views/Box/Details.cshtml");
        }

        public long Save(BoxDTO pBoxDTO)
        {
            long Result = 0;
            if (pBoxDTO.ID != 0)
            {
                Result = new BoxService().Edit(pBoxDTO);
            }
            else
            {
                Result = new BoxService().Add(pBoxDTO);
            }
            return Result;
        }

        public JsonResult GetByID(long ID)
        {
            var Result = new BoxService().GetByID(ID);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public long Delete(long ID)
        {
            var Result = new BoxService().Delete(ID);
            return Result;
        }
    }
}