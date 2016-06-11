using log4net;
using Meeting.BLL;
using Meeting.Common;
using Meeting.Entity;
using Meeting.Entity.ResultModel;
using Meeting.Interface;
using Meeting.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Api.Controllers
{
    public class MeetingInfoController : BaseController
    {
        //
        // GET: /MeetingInfo/

        IMeetingInterface imeeting = new MeetingService();
        ILog log = LogHelper.GetLog("MeetingInfoController");

        public ActionResult Index(MeetingSearch search)
        {
            TitleViewModel model = new TitleViewModel();
            mMeeting meetingModel =null;

            try
            {
                model.TopTitle = "会议详情";
                model.Title = "会议详情";
                model.RerurnButton = "/Home/Index?pageindex=" + 1;
                model.RerurnHomeButton = "/Home/Index?pageindex=" + 1;
                ViewBag.TitleViewModel = model;

                meetingModel = imeeting.GetMeetingModel(search.MeetingId);

            }
            catch (Exception ex)
            {
                log.Error("Index-"+DateTime.Now.ToString(),ex);
            }

            return View(meetingModel);
        }

        /// <summary>
        /// 获取材料详情
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialInfo(MeetingSearch search) 
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "材料详情";
            model.TopTitle = "材料详情";
            model.RerurnButton = "/MeetingInfo/Index?MeetingId=" + search.MeetingId;
            model.RerurnHomeButton = "/Home/Index?pageindex=" + 1;
            ViewBag.TitleViewModel = model;

            return View(model);
        }

        /// <summary>
        /// 打开材料图片或者打开视频
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialVide(MeetingSearch search) 
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
        public ActionResult MeetingRecord(MeetingSearch search) 
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
        public ActionResult MeetingSign(MeetingSearch search) 
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


        public JsonResult GetUserJurisdiction(int roleId) 
        {
            ResultBase result = new ResultBase();
            mUser user =(mUser)Session["LoginUser"];

            if (user != null)
            {
                if (user.UserRoleId == roleId)
                {
                    result.Result = ResultCode.Ok;
                }
                else
                {
                    result.Result = ResultCode.ClientError;
                    result.Msg = "对不起，您没有此模块权限!";
                }
            }
            else 
            {
                result.Result = ResultCode.ServerError;
                result.Msg = "请您重新登录，您已经掉线!";
            }

            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}
