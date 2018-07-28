using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PetPaw.Models;

namespace PetPaw.Filter
{
    public class RoleFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["user"] as user;
            if (user != null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                        {{"controller", "Home"}, {"action", "Index"}});
            }
            base.OnActionExecuting(filterContext);
        }
    }
}