using Common.Core;
using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kadotto.Controllers
{
    [AuthenticationFilter("Admin")]
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Customers = new CustomerService().GetAll();
            return View("~/Views/Customer/Index.cshtml");
        }

        public ActionResult Details()
        {
            return PartialView("~/Views/Customer/Details.cshtml");
        }

        public long Save(CustomerDTO pCustomerDTO)
        {
            long Result = 0;
            if (pCustomerDTO.ID != 0)
            {
                Result = new CustomerService().Edit(pCustomerDTO);
            }
            else
            {
                Result = new CustomerService().Add(pCustomerDTO);
            }
            return Result;
        }

        public JsonResult GetByID(long ID)
        {
            var Result = new CustomerService().GetByID(ID);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public long Delete(long ID)
        {
            var Result = new CustomerService().Delete(ID);
            return Result;
        }
    }
}