using Common.Core;
using Service.Core;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    [AuthenticationFilter("Admin")]
    public class PartitionController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Partitions = new PartitionService().GetAll();
            return View("~/Views/Partition/Index.cshtml");
        }

        public ActionResult Details()
        {
            return PartialView("~/Views/Partition/Details.cshtml");
        }
        public long Save(PartitionDTO pPartitionDTO)
        {
            long Result = 0;
            if (pPartitionDTO.ID != 0)
            {
                Result = new PartitionService().Edit(pPartitionDTO);
            }
            else
            {
                Result = new PartitionService().Add(pPartitionDTO);
            }
            return Result;
        }

        public JsonResult GetByID(long ID)
        {
            var Result = new PartitionService().GetByID(ID);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public long Delete(long ID)
        {
            var Result = new PartitionService().Delete(ID);
            return Result;
        }
    }
}