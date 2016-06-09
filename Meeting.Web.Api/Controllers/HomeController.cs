using Meeting.Common;
using Meeting.Entity;
using Meeting.Entity.Pager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Meeting.Web.Api.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int ? pageindex)
        {

            int count = 20;




            PageOption pageOption = new PageOption()
            {
                PageIndex = 1,
                PageSize =Convert.ToInt32(count / PageSize)+1,
                PageCount = count
            };

            ViewBag.pageOption = pageOption;

            return View();
        }


        public int GetDataSetCount(DataTable dataTable) 
        {
            return 0;
        }

        public List<mMeeting> GetDataSetList(DataTable dataTable) 
        {
            List<mMeeting> modeList = new List<mMeeting>();
            mMeeting model = null;


            return modeList;
        }
    }
}
