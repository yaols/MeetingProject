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
            var files = Request.Files[0];
            string url = ConfigurationManager.AppSettings["saveurl"].ToString();
            string saveUrl = string.Format("{0}{1}", url, DateTime.Now.ToString("yyyyMMddHHmmsss"));

            if (!Directory.Exists(saveUrl))
            {
                Directory.CreateDirectory(saveUrl);
            }

            files.SaveAs(saveUrl + "\\"+files.FileName);

            //var file = Request.Files;

            //if (file != null && file.Count > 0) 
            //{
            //    for (int i = 0; i < file.Count; i++)
            //    {
            //        string url = ConfigurationManager.AppSettings["saveurl"].ToString();
            //        DateTime date = new DateTime();
            //        string saveUrl = string.Format("{0}{1}\\{2}", url, date.Date.ToString("yyyyMMddHHmmsss"), file[i].FileName);

            //        if (!Directory.Exists(saveUrl))
            //        {
            //            Directory.CreateDirectory(saveUrl);
            //        }

            //        file[i].SaveAs(saveUrl);
            //    }
            //}
            return Json("上传成功");
            //return View();
        }

    }
}
