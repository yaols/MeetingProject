using Meeting.Common;
using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Meeting.Dao
{
    /// <summary>
    /// 参会委员
    /// </summary>
    public class MeetingPeopleDao
    {

        public static int GetMeetingPeopleUserId(int userId, string meetingId)
        {
            string sql = "select count(1) from m_MeetingPeople where MeetingId=@meetingId and UserId=@userId";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@userId",userId),
               new SqlParameter("@meetingId",meetingId)
           };

            return SQLHelper.ExcuteScalarSQL(sql, paras);

        }


        public static mMeetingOpinion GetMeetingOpinion(int userId, string meetingId)
        {
            string sql = "select * from m_MeetingOpinion where MeetingId=@meetingId and UserId=@userId";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@userId",userId),
               new SqlParameter("@meetingId",meetingId)
           };

            mMeetingOpinion model = new mMeetingOpinion();

            using (SqlDataReader reader = SQLHelper.GetReader(sql, paras))
            {
                if (reader.Read())
                {
                    model.OpinionMsg = reader["OpinionMsg"].ToString();
                    model.Id = Convert.ToInt32(reader["Id"]);
                }
            }

            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="meetingId"></param>
        /// <param name="userId"></param>
        /// <param name="opinionAction"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int InserMeetingOpinion(int Id, string meetingId, int userId, int opinionAction, string msg)
        {
            string sql = @"if(select count(1) from m_MeetingOpinion where MeetingId=@meetingId 
            and UserId=@userId)>0
            begin
            update m_MeetingOpinion set OpinionAction=@opinionAction,
            OpinionMsg=@msg,Uctime=@Uctime where Id=@Id
            end
            else
            begin
            insert into m_MeetingOpinion values(@meetingId,@userId,@opinionAction,@msg,@ctime,@uctime)
            end";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@Id",Id),
               new SqlParameter("@userId",userId),
               new SqlParameter("@meetingId",meetingId),
               new SqlParameter("@opinionAction",opinionAction),
               new SqlParameter("@msg",msg),
               new SqlParameter("@ctime",DateTime.Now.ToString()),
               new SqlParameter("@uctime",DateTime.Now.ToString())
           };

            return SQLHelper.ExcuteSQL(sql, paras);

        }


        public static string GetMeetingRecord(string meetingId)
        {
            string sql = "select MeetingRecorder from m_MeetingRecord where MeetingId=@meetingId";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@meetingId",meetingId)
           };

            var obj = SQLHelper.GetObject(sql, paras);
            if (obj != null)
                return obj.ToString();

            return "";
        }

    }
}
