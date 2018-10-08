using Common.Core;
using DataAccess.Context;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public class UserService
    {
        public long Add(UserDTO pUserDTO)
        {
            long UserID = 0;
            using (var Context = new BaseContext())
            {
                var User = new UserModel
                {
                    Name = pUserDTO.Name,
                    Family = pUserDTO.Family,
                    UserName = pUserDTO.UserName,
                    IsAdmin = false
                };
                Context.Users.Add(User);
                Context.SaveChanges();
                UserID = User.ID;
            }
            return UserID;
        }

        public long Edit(UserDTO pUserDTO)
        {
            long UserID = 0;
            using (var Context = new BaseContext())
            {
                var User = Context.Users.FirstOrDefault(a => a.ID == pUserDTO.ID);
                if (User != null)
                {
                    User.Name = pUserDTO.Name;
                    User.Family = pUserDTO.Family;
                    User.UserName = pUserDTO.UserName;
                    //User.Password = pUserDTO.Password;
                    Context.SaveChanges();
                    UserID = User.ID;
                }
            }
            return UserID;
        }

        public long Delete(long ID)
        {
            long UserID = 0;
            using (var Context = new BaseContext())
            {
                var User = Context.Users.FirstOrDefault(a => a.ID == ID);
                if (User != null)
                {
                    //User.Deleted = true;
                    //Context.Useres.Remove(User);
                    Context.SaveChanges();
                    UserID = ID;
                }
            }
            return UserID;
        }

        public UserDTO GetByID(long ID)
        {
            var Result = new UserDTO();
            using (var Context = new BaseContext())
            {
                var User = Context.Users.FirstOrDefault(a => a.ID == ID);
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

        public UserDTO GetCurrentUser()
        {
            var Result = new UserDTO();

            if (System.Web.HttpContext.Current.Session["User"] == null)
            {
                string UserName = System.Web.HttpContext.Current.Session["UserName"]?.ToString();
                Result = GetByUserName(UserName);
                System.Web.HttpContext.Current.Session["User"] = Result;
            }
            else Result = (UserDTO)System.Web.HttpContext.Current.Session["User"];

            return Result;
        }
        
        public UserDTO GetByUserName(string UserName)
        {
            var Result = new UserDTO();
            using (var Context = new BaseContext())
            {
                var User = Context.Users.FirstOrDefault(a => a.UserName == UserName);
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
            if (User.IsAdmin)
                Result = true;
            return Result;
        }

        public bool VerifyUser(UserDTO puserDTO)
        {
            var Result = false;
            using (var Context = new BaseContext())
            {
                var User = Context.Users.FirstOrDefault(a => a.UserName == puserDTO.UserName);
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
