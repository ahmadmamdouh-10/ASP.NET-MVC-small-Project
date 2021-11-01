using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Filters
{
    public class CheckUserIdentity
        : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
                filterContext.Result =
                    new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                    {
                        {"controller","User" },
                        {"action","Login" }
                    });
        }
    }
}