using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrchardDNT.Web.CustomFilters
{
    public class UserIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = HttpContext.Current.User;
            if (user != null)
            {
                int id;
                filterContext.ActionParameters["id"] = 1;
            }
            base.OnActionExecuting(filterContext);
        }
    }

}