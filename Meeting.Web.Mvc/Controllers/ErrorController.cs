using Meeting.Web.Mvc.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Meeting.Web.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Show(string message, string url)
        {
            ErrorModelView modelView = new ErrorModelView();
            modelView.Message = HttpUtility.UrlDecode(message);
            modelView.Url = HttpUtility.UrlDecode(url);

            return View(modelView);
        }
    }
}
