using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Mvc.Custom
{
    public class CustomError : ActionFilterAttribute, IExceptionFilter 
    {
        protected ILog Logger;

        public CustomError()
        {
            Logger = LogManager.GetLogger(typeof(CustomError));
        }

        public  void OnException(ExceptionContext filterContext) 
        {
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息 
            string Url = HttpContext.Current.Request.RawUrl;//错误发生地址 
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/Show?message="+HttpUtility.UrlEncode(Message)+"&url="+HttpUtility.UrlEncode(Url));//跳转至错误提示页面 
        }
    }
}