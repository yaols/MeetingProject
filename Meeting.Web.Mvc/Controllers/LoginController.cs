using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Meeting.Web.Mvc.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Login() 
        {
            return View();
        }
    }
}
