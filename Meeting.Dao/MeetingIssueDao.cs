using Meeting.Common;
using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Meeting.Dao
{
    public class MeetingIssueDao
    {
        public static mMeeting GetMeetingInfo(int meetingId)
        {
            return null;
        }


        public static List<mMeetingResources> GetMeetingResources(int issueid)
        {
            List<mMeetingResources> list = new List<mMeetingResources>();
            mMeetingResources model = null;

            string sql = string.Format(@"select Id,ResourcesName,ResourcesType,MeetingIssueId 
                              from [dbo].[m_MeetingResources] where MeetingIssueId='{0}'", issueid);

            SqlDataReader reader = SQLHelper.GetReader(sql);

            while (reader.Read()) 
            {
                model = new mMeetingResources();
                model.Id = Convert.ToInt32(reader["Id"]);
                model.ResourcesName = reader["ResourcesName"].ToString();
                model.ResourcesType = Convert.ToInt32(reader["ResourcesType"]);
                model.MeetingIssueId = Convert.ToInt32(reader["MeetingIssueId"]);
                list.Add(model);
            }

            return list;
        }
    }
}
