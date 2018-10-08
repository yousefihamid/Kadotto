using Common.Core;
using Service.Core;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    [AuthenticationFilter("Admin")]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Products = new ProductService().GetAll();
            return View("~/Views/Product/Index.cshtml");
        }

        public ActionResult Details()
        {
            ViewBag.ProductCategories = new ProductCategoryService().GetAll();
            return PartialView("~/Views/Product/Details.cshtml");
        }
        public long Save(ProductDTO pProductDTO)
        {
            long Result = 0;
            if (pProductDTO.ID != 0)
            {
                Result = new ProductService().Edit(pProductDTO);
            }
            else
            {
                Result = new ProductService().Add(pProductDTO);
            }
            return Result;
        }

        public JsonResult GetByID(long ID)
        {
            var Result = new ProductService().GetByID(ID);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public long Delete(long ID)
        {
            var Result = new ProductService().Delete(ID);
            return Result;
        }
    }
}