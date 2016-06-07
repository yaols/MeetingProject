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
        public ActionResult MaterialInfo() 
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "材料详情";
            model.TopTitle = "材料详情";
            return View(model);
        }

        /// <summary>
        /// 打开材料图片或者打开视频
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialVide() 
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "材料: b20160305b0098";
            model.TopTitle = "材料: b20160305b0098";
            model.Type = 1;
            return View(model);
        }

        /// <summary>
        /// 获取会议记录
        /// </summary>
        /// <returns></returns>
        public ActionResult MeetingRecord() 
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "材料: b20160305b0098";
            model.TopTitle = "材料: b20160305b0098";
            return View(model);
        }

        /// <summary>
        /// 检委会决定  签字
        /// </summary>
        /// <returns></returns>
        public ActionResult MeetingSign() 
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "检委会决定";
            model.TopTitle = "材料: 议题详情b2016";
            return View(model);
        }

        /// <summary>
        /// 会议创建
        /// </summary>
        /// <returns></returns>
        public ActionResult MeetingCreate()
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "会议创建";
            model.TopTitle = "+会议创建";
            return View(model);
        }
    }
}
