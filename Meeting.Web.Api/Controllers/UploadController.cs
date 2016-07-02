using Meeting.BLL;
using Meeting.Common;
using Meeting.Entity;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Api.Controllers
{
    public class UploadController : BaseController
    {
        //
        // GET: /Upload/
        IMeetingInterface iMeeting = new MeetingService();
        IMeetingResources iResources = new MeetingResourcesService();


        [HttpPost]
        public JsonResult Index()
        {
            mMeetingResources model = new mMeetingResources();
            model.Directory = (iMeeting.GetMeetingMaxId()+1).ToString();

            string msg = "";

            var files = Request.Files[0];
            if (files != null) 
            {
                string saveUrl = string.Format("{0}\\{1}",Consts.SaveUrlPath, model.Directory);
                model.ResourcesType = Path.GetExtension(files.FileName);  
                model.ResourcesName=DateTime.Now.ToString("yyyyMMddHHmmsss");

                if (!Directory.Exists(saveUrl))
                {
                    Directory.CreateDirectory(saveUrl);
                }

                files.SaveAs(saveUrl + "\\" + model.ResourcesName + model.ResourcesType);
                
                if (iResources.InsertModel(model) > 0)
                {
                    msg = "上传成功";
                }
                else 
                {
                    msg = "上传失败";
                }
            }
            return Json(msg);
        }

        [HttpPost]
        public JsonResult Upload()
        {
            var directory = Request.Form["Directory"];
            var files = Request.Files[0];
            if (files != null) 
            {
                string saveUrl = string.Format("{0}\\{1}", Consts.SaveUrlPath,directory);
                files.SaveAs(saveUrl + "\\" +files.FileName);
            } 


            return Json("保存成功");
        }



        [HttpPost]
        public JsonResult SaveWord(string directory)
        {
            var files = Request.Files[0];
            if (files != null) 
            {
                string saveUrl = string.Format(@"{0}\{1}\{2}", Consts.SaveUrlPath, UserSession.UserId,directory);

                if (!Directory.Exists(saveUrl))
                {
                    Directory.CreateDirectory(saveUrl);
                }

                files.SaveAs(saveUrl + "\\" +"1.docx");
            }

            return Json("上传成功");
        }
    }
}
