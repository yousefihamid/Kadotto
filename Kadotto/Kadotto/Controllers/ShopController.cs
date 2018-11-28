using DataAccess.Shop;
using Service.Core;
using Service.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    public class ShopController : Controller
    {
        #region Page

        public ActionResult Index()
        {
            ViewBag.Boxes = new BoxService().GetAll();
            ViewBag.Products = new ProductService().GetAll();
            return View();
        }

        public ActionResult ShoppingCart()
        {
            ViewBag.PackagedBoxes = new PackagedBoxService().GetCard();
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        #endregion

        #region Service

        [HttpPost]
        public JsonResult AddToCard(PackagedBoxDTO pPackagedBoxDTO)
        {
            var Result = new PackagedBoxService().AddToCard(pPackagedBoxDTO);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCard()
        {
            var Result = new PackagedBoxService().GetCard();
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveFromCard(PackagedBoxDTO pPackagedBoxDTO)
        {
            var Result = new PackagedBoxService().RemoveFromCard(pPackagedBoxDTO);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
