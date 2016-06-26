using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Api.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/


        [HttpPost]
        public JsonResult Index()
        {
            var date = Request.Form["startTime"];

            var files = Request.Files[0];
            string url = ConfigurationManager.AppSettings["saveurl"].ToString();
            string saveUrl = string.Format("{0}{1}", url, date);

            if (!Directory.Exists(saveUrl))
            {
                Directory.CreateDirectory(saveUrl);
            }

            files.SaveAs(saveUrl + "\\" + files.FileName);
            return Json("上传成功");
        }

    }
}
