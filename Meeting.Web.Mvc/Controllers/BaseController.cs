using Meeting.Web.Mvc.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Mvc.Controllers
{
    [CustomError]
    public class BaseController : Controller
    {
        public BaseController() 
        {
 
        }
    }
}
