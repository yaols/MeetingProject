using Meeting.Common;
using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Meeting.Dao
{
    public class MeetingResourcesDao
    {
        public static int InsertModel(mMeetingResources model)
        {
            string sql = string.Format(@"insert into m_MeetingResources(ResourcesName,ResourcesType,MeetingIssueId,Directory)
                                  values('{0}','{1}','{2}','{3}')", model.ResourcesName, model.ResourcesType, model.Directory, model.Directory);
            return SQLHelper.ExcuteSQL(sql);
        }


        public static List<mMeetingResources> GetResourcesList(int meetingId, int userId)
        {
            List<mMeetingResources> list = new List<mMeetingResources>();
            mMeetingResources model = null;
            string sql = @"select Id,ResourcesName,ResourcesType,MeetingIssueId,Directory from 
            m_MeetingResources where MeetingIssueId=@meetingId";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@meetingId",meetingId)
           };

            SqlDataReader reader = SQLHelper.GetReader(sql, paras);

            while (reader.Read())
            {
                model = new mMeetingResources();
                model.Id = Tool.ToInt(reader["Id"].ToString());
                model.ResourcesName = reader["ResourcesName"].ToString();
                model.ResourcesType = reader["ResourcesType"].ToString();
                model.MeetingIssueId = Tool.ToInt(reader["MeetingIssueId"].ToString());
                model.Directory = reader["Directory"].ToString();
                list.Add(model);
            }

            return list;
        }


        public static int DelResource(int id)
        {
            string sql = "delete from [m_MeetingResources] where Id=@Id";
            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@Id",id)
           };

            return SQLHelper.ExcuteSQL(sql, paras);

        }
    }
}
