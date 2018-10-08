using Common.Core;
using Service.Core;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    [AuthenticationFilter("Admin")]
    public class ProductCategoryController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ProductCategories = new ProductCategoryService().GetAll();
            return View("~/Views/ProductCategory/Index.cshtml");
        }

        public ActionResult Details()
        {
            ViewBag.ProductCategories = new ProductCategoryService().GetAll();
            return PartialView("~/Views/ProductCategory/Details.cshtml");
        }
        public long Save(ProductCategoryDTO pProductCategoryDTO)
        {
            long Result = 0;
            if (pProductCategoryDTO.ID != 0)
            {
                Result = new ProductCategoryService().Edit(pProductCategoryDTO);
            }
            else
            {
                Result = new ProductCategoryService().Add(pProductCategoryDTO);
            }
            return Result;
        }

        public JsonResult GetByID(long ID)
        {
            var Result = new ProductCategoryService().GetByID(ID);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public long Delete(long ID)
        {
            var Result = new ProductCategoryService().Delete(ID);
            return Result;
        }
    }
}