using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Api.Filters
{
    public class MyAuthorization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["LoginUser"]==null)
            {
                filterContext.HttpContext.Response.Write("<script>parent.window.location = '/login';</script>");
                filterContext.HttpContext.Response.End();
            }
        }
    }
}