using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sauemk.web.Attributes
{
    internal class Http403Result : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            // Set the response code to 403.
            context.HttpContext.Response.StatusCode = 403;
        }
    }

    public class RESTAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var was = filterContext.HttpContext.Request.Headers.Get("Authorization");
            var sa = false;
            if (sa)
            {
                return;
            }
            filterContext.Result = new Http403Result();
        }

    }
}