using Meeting.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Api.Controllers
{
    public class MeetingInfoController : Controller
    {
        //
        // GET: /MeetingInfo/

        public ActionResult Index()
        {
            TitleViewModel model = new TitleViewModel();
            model.TopTitle = "会议详情";
            model.Title = "会议详情";
            return View(model);
        }

        /// <summary>
        /// 获取材料详情
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMaterial() 
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "材料详情";
            model.TopTitle = "材料详情";
            return View(model);
        }


        public ActionResult GetMaterialImage() 
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "材料: b20160305b0098";
            model.TopTitle = "材料: b20160305b0098";
            model.Type = 1;
            return View(model);
        }


    }
}
