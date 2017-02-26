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
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        ILoginInterface ilogin = new LoginService();
        ILog log = LogHelper.GetLog("LoginController");

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(UserViewModel model)
        {
            mUser umodel = new mUser();
            ResultBase result = new ResultBase();
            try
            {
                model.UserName = HttpUtility.UrlDecode(model.UserName);
                model.UserPass =Tool.MD5(HttpUtility.UrlDecode(model.UserPass));
                umodel = ilogin.LoginUserInfo(model.UserName, model.UserPass,Consts.SecretaryType);

                if (umodel.PassWord == model.UserPass && umodel.UserName == model.UserName)
                {
                    if (umodel.UserRoleId == 2)
                    {
                        HttpContext.Session["LoginUser"] = umodel;
                        result.Msg = "登陆成功";
                        result.Result = ResultCode.Ok;
                    }
                    else 
                    {
                        result.Msg = "此账号没有权限登录议员版本";
                        result.Result = ResultCode.ClientError;
                    }
                }
                else
                {
                    result.Msg = "用户名和密码错误";
                    result.Result = ResultCode.ClientError;
                }
            }
            catch (Exception ex)
            {
                result.Msg = "服务器错误";
                result.Result = ResultCode.ServerError;
                LogHelper.Error("UserLogin-" + DateTime.Now.ToString(), ex);
            }

            return Json(result);
        }


        public ActionResult Signout() 
        {
            HttpContext.Session["LoginUser"] = null;
            return RedirectToAction("Index");
        }
    }
}
