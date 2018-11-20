using Newtonsoft.Json;
using Service.Authentication;
using Service.Core;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Kadotto
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        string groupAccess;
        public AuthenticationFilterAttribute(string GroupAccess)
        {
            groupAccess = GroupAccess;
        }
        public AuthenticationFilterAttribute()
        {
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool Result = true; //new UserService().HasAccess(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
            if (Result == false)
                filterContext.HttpContext.Response.Redirect("/Home/NoAccess", true);
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}