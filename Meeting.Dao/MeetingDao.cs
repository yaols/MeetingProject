using Meeting.Common;
using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Meeting.Dao
{
    public class MeetingDao
    {
        public static DataSet GetMeetingList(int meetingType, int pageindex, int pagesize)
        {
            int index = (pageindex - 1) * pagesize + 1;
            int size = pageindex * pagesize;

            DataSet dataSet = new DataSet();

            string sql = @"select RowId,MeetingId,MeetingName,StartDate,EendDate,MeetingType
                                  from ( select ROW_NUMBER() OVER (ORDER BY StartDate desc) RowId,MeetingId,
                                  MeetingName,StartDate,EendDate,MeetingType from m_Meeting 
                                  where MeetingType=@meetingType ) a where a.RowId between @index and @size;
                                  select count(1) from m_Meeting where MeetingType=@meetingType";



            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@index",index),
               new SqlParameter("@size",size),
               new SqlParameter("@meetingType",meetingType)
           };

            dataSet = SQLHelper.GetDataSet(sql, paras);

            return dataSet;
        }


        public static mMeeting GetMeetingModel(int meetingId) 
        {
            mMeeting model = new mMeeting();
            model.IssueList=new List<mMeetingIssue>();
            mMeetingIssue issue = null;

            string sql = @"select m.MeetingId,MeetingName,StartDate,EendDate,MeetingAddress,
                                   HostName=(select UserName from m_User u where u.UserId=m.MeetingHost),
                                   SecretaryName=(select UserName from m_User u where u.UserId=m.MeetingSecretary),
                                   peopleName=(select [dbo].[GetMeetingPeople](1)),mi.IssueName,mi.Id,
                                   RepostUser=(select UserName from m_User u where u.UserId=mi.RepostUser),
                                   DepartName=(select DepartName from m_Depart m where m.Id=mi.DepartId)
                                   from m_Meeting m  left join m_MeetingIssue mi on m.MeetingId=mi.MeetingId
                                   where m.MeetingId=@meetingId";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@meetingId",meetingId),
           };

            SqlDataReader reader = SQLHelper.GetReader(sql,paras);
            while (reader.Read()) 
            {
                issue = new mMeetingIssue();
                issue.IssueName = reader["IssueName"].ToString();
                issue.RepostUser = reader["RepostUser"].ToString();
                issue.DepartName = reader["DepartName"].ToString();
                issue.Id =Tool.ToInt(reader["Id"].ToString());
                model.IssueList.Add(issue);

                model.MeetingId = Tool.ToInt(reader["MeetingId"].ToString());
                model.MeetingName = reader["MeetingName"].ToString();
                model.StartDate =Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd HH:mm");
                model.EendDate = Convert.ToDateTime(reader["EendDate"]).ToString("yyyy-MM-dd HH:mm");
                model.MeetingAddress = reader["MeetingAddress"].ToString();
                model.MeetingHost = reader["HostName"].ToString();
                model.SecretaryName = reader["SecretaryName"].ToString();
                model.PeopleName = reader["PeopleName"].ToString();
            }

            return model;
        }
    }
}
