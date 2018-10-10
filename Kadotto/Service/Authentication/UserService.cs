using Common.Authentication;
using Common.Core;
using DataAccess.Context;
using System;
using System.Linq;

namespace Service.Authentication
{
    public class UserService
    {
        public UserDTO GetCurrentUser()
        {
            UserDTO Result = null;

            if (System.Web.HttpContext.Current.Session["User"] == null)
            {
                string UserName = System.Web.HttpContext.Current.Session["UserName"]?.ToString();
                if (string.IsNullOrEmpty(UserName) == false)
                {
                    Result = GetByUserName(UserName);
                    System.Web.HttpContext.Current.Session["User"] = Result;
                }
            }
            else Result = (UserDTO)System.Web.HttpContext.Current.Session["User"];

            return Result;
        }
        
        public UserDTO GetByUserName(string UserName)
        {
            var Result = new UserDTO();
            using (var Context = new BaseContext())
            {
                var User = Context.Customers.FirstOrDefault(a => a.UserName == UserName);
                if (User != null)
                {
                    Result.ID = User.ID;
                    Result.Name = User.Name;
                    Result.Family = User.Family;
                    Result.UserName = User.UserName;
                    Result.IsAdmin = User.IsAdmin;
                }
            }
            return Result;
        }

        public bool HasAccess(string ControllerName)
        {
            bool Result = false;
            var User = GetCurrentUser();
            if (User != null)
                Result = User.IsAdmin;
            return Result;
        }

        public bool VerifyUser(UserDTO puserDTO)
        {
            var Result = false;
            using (var Context = new BaseContext())
            {
                var User = Context.Customers.FirstOrDefault(a => a.UserName == puserDTO.UserName);
                if (User != null)
                {
                    Result = User.Password == puserDTO.Password;
                }
            }
            if (Result)
                System.Web.HttpContext.Current.Session["UserName"] = puserDTO.UserName;

            return Result;
        }

        public void SendMobileCode(string MobileNumber)
        {
            var Code =long.Parse(MobileNumber) / (DateTime.Now.Day * DateTime.Now.Hour);
            System.Web.HttpContext.Current.Session["VerifyCode"] = Code;
            System.Web.HttpContext.Current.Session["MobileNumber"] = MobileNumber;
        }

        public bool VerifyMobileCode(string Code)
        {
            var Result = false;
            if (System.Web.HttpContext.Current.Session["VerifyCode"].ToString() == Code)
            {
                System.Web.HttpContext.Current.Session["VerifyCode"] = null;
                Result = true;
            }
            else
            {
                System.Web.HttpContext.Current.Session["MobileNumber"] = null;
            }
            return Result;
        }

        public string GetPhoneNumber()
        {
            return System.Web.HttpContext.Current.Session["MobileNumber"].ToString();
        }
    }
}
