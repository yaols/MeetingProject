using Meeting.BLL;
using Meeting.Common;
using Meeting.Entity.ResultModel;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Api.Controllers
{
    public class UserController : BaseController
    {

        IMuserInterface imuser = new mUserService();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult User(string username, string password, string chkmishu) 
        {
            ResultBase result = new ResultBase();
            if (imuser.AddUser(username, Tool.MD5(password), chkmishu == "checked" ? 1 : 2) > 0)
            {
                result.Result = ResultCode.Ok;
                result.Msg = "添加用户成功";
            }
            else 
            {
                result.Result = ResultCode.ServerError;
                result.Msg = "添加用户失败";
            }

            return Json(result);
        }

        public JsonResult Depart(string departname) 
        {
            ResultBase result = new ResultBase();
            if (imuser.AddDepart(departname) > 0)
            {
                result.Result = ResultCode.Ok;
                result.Msg = "添加部门成功";
            }
            else
            {
                result.Result = ResultCode.ServerError;
                result.Msg = "添加部门失败";
            }

            return Json(result);
        }
    }
}
