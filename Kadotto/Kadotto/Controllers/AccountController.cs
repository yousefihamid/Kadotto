using System.Web.Mvc;
using Common.Core;
using Service.Core;
using Service.Authentication;
using Common.Authentication;

namespace Kadotto.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SendCode()
        {
            return View();
        }

        public ActionResult VerifyCode()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(CustomerDTO pCustomerDTO)
        {
            var Result = new CustomerService().Add(pCustomerDTO);
            return Json(Result);
        }

        [HttpPost]
        public JsonResult VerifyUser(UserDTO pUserDTO)
        {
            var Result = new UserService().VerifyUser(pUserDTO);
            return Json(Result);
        }

        [HttpPost]
        public void SendMobileCode(string MobileNumber)
        {
            new UserService().SendMobileCode(MobileNumber);
        }

        [HttpPost]
        public JsonResult VerifyMobileCode(string Code)
        {
            var Result = new UserService().VerifyMobileCode(Code);
            return Json(Result);
        }

        [HttpGet]
        public JsonResult GetPhoneNumber()
        {
            var Result = new UserService().GetPhoneNumber();
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCurrentUser()
        {
            var Result = new UserService().GetCurrentUser();
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
    }
}