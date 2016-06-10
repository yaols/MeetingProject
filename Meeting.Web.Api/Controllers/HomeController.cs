using log4net;
using Meeting.BLL;
using Meeting.Common;
using Meeting.Entity;
using Meeting.Entity.Pager;
using Meeting.Interface;
using Meeting.Web.Api.Models;
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
        IMeetingInterface imeeting = new MeetingService();
        ILog log = LogHelper.GetLog("HomeController");


        public ActionResult Index(MeetingSearch search)
        {
            var dataSet = imeeting.GetMeetingList(search.MeetingType, search.PageIndex??1, PageSize);
            List<mMeeting> modeList = null;

            try
            {

                if (dataSet != null)
                {
                    int count = GetDataSetCount(dataSet.Tables[1]);
                    modeList = GetDataSetList(dataSet.Tables[0]);

                    PageOption pageOption = new PageOption()
                    {
                        PageIndex =Convert.ToInt32(search.PageIndex),
                        PageSize = (count + PageSize -1) / PageSize,
                        PageCount = count,
                        PageType=search.PageType
                    };

                    ViewBag.pageOption = pageOption;
                }
            }
            catch (Exception ex)
            {
                log.Error("Index-" + DateTime.Now.ToString(), ex);
            }

            if (search.PageType == 1)
                return PartialView("Table", modeList);
            return View(modeList);
        }


        public int GetDataSetCount(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
                return Tool.ToInt(dataTable.Rows[0][0].ToString());
            return 0;
        }

        public List<mMeeting> GetDataSetList(DataTable dataTable)
        {
            List<mMeeting> modeList = new List<mMeeting>();
            mMeeting model = null;

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    model = new mMeeting();
                    model.RowId = Tool.ToInt(item["RowId"].ToString());
                    model.MeetingId = Tool.ToInt(item["MeetingId"].ToString());
                    model.MeetingName = item["MeetingName"].ToString();
                    model.StartDate = Convert.ToDateTime(item["StartDate"]).ToString("yyyy-MM-dd HH:mm");
                    model.EendDate = Convert.ToDateTime(item["EendDate"]).ToString("yyyy-MM-dd HH:mm");
                    modeList.Add(model);
                }
            }
            return modeList;
        }
    }
}
