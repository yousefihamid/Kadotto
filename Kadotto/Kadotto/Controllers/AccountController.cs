using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Kadotto.Models;
using Common.Core;
using Service.Core;

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
        public JsonResult Add(UserDTO pUserDTO)
        {
            var Result = new UserService().Add(pUserDTO);
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
            return Json(Result);
        }
    }
}