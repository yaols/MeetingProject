using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace Meeting.Web.Api.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取当前登录用户的ID值。
        /// </summary>
        public Session UserSession
        {
            get
            {
                if (HttpContext.Session != null)
                    return (Session)HttpContext.Session["LoginUser"];
                return null;
            }
            set
            {
                HttpContext.Session["LoginUser"] = value;
            }
        }

    }
}
