using log4net;
using Meeting.BLL;
using Meeting.Common;
using Meeting.Entity;
using Meeting.Entity.ResultModel;
using Meeting.Interface;
using Meeting.Web.Api.Models;
using Newtonsoft.Json;
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
        IMeetingResources iresources = new MeetingResourcesService();
        ILog log = LogHelper.GetLog("MeetingInfoController");

        public ActionResult Index(MeetingSearch search)
        {
            TitleViewModel model = new TitleViewModel();
            mMeeting meetingModel = null;

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
                log.Error("Index-" + DateTime.Now.ToString(), ex);
            }

            return View(meetingModel);
        }

        /// <summary>
        /// 获取材料详情
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialInfo(MeetingSearch search)
        {
            ResourcesView view = new ResourcesView();

            view.TitleModel = new TitleViewModel();
            view.TitleModel.Title = "材料详情";
            view.TitleModel.TopTitle = "材料详情";
            view.TitleModel.RerurnButton = "/MeetingInfo/Index?MeetingId=" + search.MeetingId;
            view.TitleModel.RerurnHomeButton = "/Home/Index?pageindex=" + 1;

            List<mMeetingResources> listModel = iresources.GetResourcesList(search.MeetingId, UserSession.UserId);
            view.Text = listModel.Where(m => m.ResourcesType == ".txt" || m.ResourcesType == ".doc" || m.ResourcesType == ".docx").ToList();
            view.Vide = listModel;
            foreach (var item in view.Text)
            {
                view.Vide.Remove(item);
            }

            ViewBag.TitleViewModel = view.TitleModel;

            return View(view);
        }

        /// <summary>
        /// 打开材料图片或者打开视频
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialVide(MeetingSearch search)
        {
            TitleViewModel model = new TitleViewModel();
            model.Title = "材料: " + search.ResourceName;
            model.TopTitle = "材料: " + search.ResourceName;
            model.RerurnButton = "/MeetingInfo/MaterialInfo?MeetingId=" + search.MeetingId;
            model.RerurnHomeButton = "/Home/Index?pageindex=" + 1;
            model.Type = 1;
            ViewBag.TitleViewModel = model;
            string message = "";
            string url = string.Format("{0}{1}/{2}", Consts.DwonUrlPath,search.Directory,search.ResourceName);
            WordHelper.Word2HtmlFromFileSaveFileHtml(url,Consts.SaveUrlPath + "1.html", out message);


            //Tuple<int, string> tuple=GetTypeUrl(search.ResourcesType,url);
            Tuple<int, string> tuple = GetTypeUrl(search.ResourcesType,Consts.DwonUrlPath + "1.html",url);
            return View(tuple);
        }


        private Tuple<int, string> GetTypeUrl(string type,string filename,string url) 
        {
            Tuple<int, string> tuple = new Tuple<int, string>(0,"");

            if (type == ".txt" || type == ".doc" || type == ".docx")
            {
                tuple = new Tuple<int, string>(1, filename);
            }
            else if (type == ".png" || type == ".jpg" || type == ".gif" || type == ".gif")
            {
                tuple = new Tuple<int, string>(2, url);
            }
            else if (type == ".mp4" || type == ".wmv" || type == ".amv")
            {
                tuple = new Tuple<int, string>(3, url);
            }
            else if (type == ".mp3")
            {
                tuple = new Tuple<int, string>(4, url);
            }
            else
            {
                tuple = new Tuple<int, string>(1, url);
            }

            return tuple;
        }



        /// <summary>
        /// 获取会议记录
        /// </summary>
        /// <returns></returns>
        public ActionResult MeetingRecord(MeetingSearch search)
        {
            TitleViewModel model = new TitleViewModel();
            //mMeeting meetingModel = imeeting.GetMeetingModel(search.MeetingId);
            string message = "";
            mMeeting meetingModel = new mMeeting();
            meetingModel.MeetingId = search.MeetingId;
            model.Title = "材料: 会议记录";
            model.TopTitle = "材料: 会议记录";
            model.RerurnButton = "/MeetingInfo/Index?MeetingId=" + search.MeetingId;
            ViewBag.TitleViewModel = model;
            //model.RerurnHomeButton = Consts.UrlPath+"/Upload/SaveWord?directory="+search.MeetingId;
            meetingModel.Directory = string.Format("{0}{1}/{2}", Consts.DwonUrlPath,search.MeetingId, search.MeetingId + ".docx");
            WordHelper.Word2HtmlFromFileSaveFileHtml(meetingModel.Directory,Consts.SaveUrlPath+"1.html", out message);
            meetingModel.Directory = string.Format("{0}{1}", Consts.DwonUrlPath, "1.html");

            return View(meetingModel);
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
            CreateMeetingModel model = new CreateMeetingModel();
            model = imeeting.GetCreteMeetingModel("0");
            return View(model);
        }

        public JsonResult GetUserJurisdiction(int roleId)
        {
            ResultBase result = new ResultBase();
            mUser user = (mUser)Session["LoginUser"];

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

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MeetingCreate(string json)
        {
            ResultBase result = new ResultBase();
            CreateMeeting model = JsonConvert.DeserializeObject<CreateMeeting>(json);
            if (imeeting.InsertCreateMeeting(model, UserSession.UserId) > 0)
            {
                result.Result = ResultCode.Ok;
                result.Msg = "保存会议成功";
            }
            else
            {
                result.Result = ResultCode.ServerError;
                result.Msg = "保存会议失败";
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult EndMeeting(string meetingId)
        {
            ResultBase result = new ResultBase();

            if (imeeting.EndMeeting(meetingId) > 0)
            {
                result.Result = ResultCode.Ok;
                result.Msg = "结束会议成功";
            }
            else
            {
                result.Result = ResultCode.ServerError;
                result.Msg = "结束会议失败";
            }

            return Json(result);
        }


        public void ExportWord(string fileName) 
        {
            string url = string.Format(@"{0}{1}\{2}", Consts.SaveUrlPath,fileName, fileName+".docx");
            //输出word
            System.IO.FileInfo file = new System.IO.FileInfo(url);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Charset = "GB2312";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名 
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode("会议记录.docx", System.Text.Encoding.UTF8));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度 
            System.Web.HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());

            // 指定返回的是一个不能被客户端读取的流，必须被下载 
            System.Web.HttpContext.Current.Response.ContentType = "application/ms-word";

            // 把文件流发送到客户端 
            System.Web.HttpContext.Current.Response.WriteFile(file.FullName);
            // 停止页面的执行 
            //HttpContext.Current.ApplicationInstance.CompleteRequest
            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
        }


        public JsonResult DelMeeting(string meetingId) 
        {
            ResultBase result = new ResultBase();
            if (imeeting.UpdateMeeting(meetingId) > 0)
            {
                result.Result = ResultCode.Ok;
                result.Msg = "隐藏会议成功";
            }
            else
            {
                result.Result = ResultCode.ServerError;
                result.Msg = "隐藏会议失败";
            }

            return Json(result);
        }



        public JsonResult DelResource(int Id, string Directory, string filename)
        {
            ResultBase result = new ResultBase();

            if (iresources.DelResource(Id) > 0) 
            {
                string url = string.Format("{0}{1}\\{2}",Consts.SaveUrlPath,Directory,filename);
                if (Helper.DelFileUrl(url) > 0)
                {
                    result.Result = ResultCode.Ok;
                    result.Msg = "删除文件" + filename + "成功";
                }
                else 
                {
                    result.Result = ResultCode.Ok;
                    result.Msg = "删除文件" + filename + "失败";
                }
            }

            return Json(result);
        }


        public JsonResult DelCeate(string filename)
        {
            ResultBase result = new ResultBase();
            //string directory=(imeeting.GetMeetingMaxId() + 1).ToString();

            //if (iresources.DelResource(Id) > 0)
            //{
            //    string url = string.Format("{0}{1}\\{2}", Consts.SaveUrlPath, Directory, filename);
            //    if (Helper.DelFileUrl(url) > 0)
            //    {
            //        result.Result = ResultCode.Ok;
            //        result.Msg = "删除文件" + filename + "成功";
            //    }
            //    else
            //    {
            //        result.Result = ResultCode.Ok;
            //        result.Msg = "删除文件" + filename + "失败";
            //    }
            //}

            return Json(result);
        }
    }
}
