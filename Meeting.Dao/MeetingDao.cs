using Meeting.Common;
using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
                                  from ( select ROW_NUMBER() OVER (ORDER BY MeetingCreateDate desc) RowId,MeetingId,
                                  MeetingName,StartDate,EendDate,MeetingType from m_Meeting 
                                  where MeetingType=@meetingType and Type=0) a where a.RowId between @index and @size;
                                  select count(1) from m_Meeting where MeetingType=@meetingType and Type=0";



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
            model.IssueList = new mMeetingIssue();
            //mMeetingIssue issue = null;

            string sql = @"select m.MeetingId,MeetingName,StartDate,EendDate,AddressName,
                                   HostName=(select UserName from m_User u where u.UserId=m.MeetingHost),
                                   SecretaryName=(select UserName from m_User u where u.UserId=m.MeetingSecretary),
                                   peopleName=(select [dbo].[GetMeetingPeople](@meetingId)),m.IssueName,
                                   RepostUser=(select UserName from m_User u where u.UserId=m.RepostUser),
                                   Directory=(select top 1 Directory from m_MeetingResources mr where mr.MeetingIssueId=m.MeetingId),
                                   d.DepartName,m.type  from m_Meeting m 
                                   left join m_Depart d on m.DepartId=d.Id
                                   where m.MeetingId=@meetingId and Type=0";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@meetingId",meetingId),
           };

            SqlDataReader reader = SQLHelper.GetReader(sql, paras);
            while (reader.Read())
            {

                model.IssueList.IssueName = reader["IssueName"].ToString();
                model.IssueList.RepostUser = reader["RepostUser"].ToString();
                model.IssueList.DepartName = reader["DepartName"].ToString();
                //model.IssueList.Id = Tool.ToInt(reader["Id"].ToString());


                model.MeetingId = Tool.ToInt(reader["MeetingId"].ToString());
                model.MeetingName = reader["MeetingName"].ToString();
                model.StartDate = Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd HH:mm");
                model.EendDate = Convert.ToDateTime(reader["EendDate"]).ToString("yyyy-MM-dd HH:mm");
                model.MeetingAddress = reader["AddressName"].ToString();
                model.MeetingHost = reader["HostName"].ToString();
                model.SecretaryName = reader["SecretaryName"].ToString();
                model.PeopleName = reader["PeopleName"].ToString();
                model.Directory = reader["Directory"].ToString();
                model.Type = Tool.ToInt(reader["Type"].ToString());
            }

            return model;
        }


        public static DataSet GetCreateMeeting()
        {
            DataSet dataSet = new DataSet();

            string usersql = "select UserId,UserName from [dbo].[m_User];";
            string addresssql = "select Id,MeetingAddress from [dbo].[m_Address];";
            string departsql = "select Id,DepartName from [dbo].[m_Depart];";

            usersql = usersql + addresssql + departsql;

            dataSet = SQLHelper.GetDataSet(usersql);
            return dataSet;
        }


        public static int SaveMeeting(List<mMeetingResources> resources, List<mMeetingPeople> people, mMeeting meeting)
        {
            int result = 0;

            string meetingsql = string.Format(@"insert into [m_Meeting](MeetingName,StartDate,EendDate,AddressId,
                                   MeetingHost,MeetingDocument,MeetingCreateDate,MeetingType,
                                   MeetingSecretary) values('{0}','{1}',
                                   '{2}','{3}','{4}','{5}','{6}','{7}','{8}');select @@identity", meeting.MeetingName, meeting.StartDate,
                                    meeting.EendDate, meeting.MeetingAddress, meeting.MeetingHost, meeting.MeetingDocument,
                                    DateTime.Now.ToString(),
                                    0, meeting.MeetingSecretary);

            int meetingid = SQLHelper.ExcuteScalarSQL(meetingsql);

            if (meetingid > 0)
            {
                string issuesql = string.Format(@"insert into [m_MeetingIssue](IssueName,RepostUser,DepartId,
                                          MeetingId) values('{0}','{1}','{2}','{3}');select @@identity", meeting.IssueList.IssueName,
                                          meeting.IssueList.RepostUserId, meeting.IssueList.DepartId, meetingid);
                StringBuilder builder = new StringBuilder();
                foreach (var item in people)
                {
                    builder.AppendFormat("insert into [m_MeetingPeople] (MeetingId,UserId,RoleId) values('{0}','{1}','{2}');", meetingid, item.UserId, item.RoleId);
                }

                int issueId = SQLHelper.ExcuteScalarSQL(builder.ToString() + issuesql);

                if (issueId > 0)
                {
                    builder.Clear();
                    foreach (var item in resources)
                    {
                        builder.AppendFormat(@"insert into [m_MeetingResources] (ResourcesName,
                        ResourcesType,MeetingIssueId) values ('{0}','{1}','{2}');", item.ResourcesName, item.ResourcesType, issueId);
                    }

                    result = SQLHelper.ExcuteSQL(builder.ToString());
                }
            }

            return result;
        }

        public static DataSet GetCreteMeetingModel(string meetingId)
        {
            string sql = "select Id,DepartName from m_Depart;select UserId,UserName,UserRoleId from m_User;";

            DataSet data = SQLHelper.GetDataSet(sql);


            return data;
        }

        public static int GetMeetingMaxId()
        {
            string sql = "select ISNULL(max(MeetingId),1) from m_Meeting";

            return SQLHelper.ExcuteScalarSQL(sql);
        }

        public static int InsertCreateMeeting(CreateMeeting model, int userId)
        {

            int result = 0;
            string sql = string.Format(@"insert into m_Meeting (MeetingName,StartDate,EendDate,AddressName,MeetingHost,
            MeetingDocument,MeetingCreateUser,MeetingCreateDate,MeetingType,MeetingSecretary,IssueName,RepostUser,DepartId,Type) values (
            '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}');select @@identity", model.year, model.datetimepicker1, model.datetimepicker2, model.address,
             model.hoseUser, model.wenshu, userId, DateTime.Now, 0, model.secretary, model.issue, model.report, model.depart,0);

            result = SQLHelper.ExcuteScalarSQL(sql);
            if (result > 0)
            {
                string saveUrl = string.Format("{0}{1}", Consts.SaveUrlPath, result);

                if (!Directory.Exists(saveUrl))
                    Directory.CreateDirectory(saveUrl);

                File.Copy(Consts.SaveUrlPath + "会议记录.docx", saveUrl + "\\" + result + ".docx");



                DataTable dt = SQLHelper.GetTableSchema();
                model.people = model.people.Substring(0, model.people.Length - 1);
                string[] arrayString = model.people.Split(',');
                if (arrayString != null)
                {
                    for (int i = 0; i < arrayString.Length; i++)
                    {
                        DataRow row = dt.NewRow();
                        row[1] = result;
                        row[2] = arrayString[i];
                        dt.Rows.Add(row);
                    }
                    result = SQLHelper.BulkToDB(dt, "m_MeetingPeople");
                }
            }

            return result;
        }

        public static int EndMeeting(string meetingId)
        {
            string sql = "update m_Meeting set MeetingType=1 where MeetingId=" + meetingId;

            return SQLHelper.ExcuteSQL(sql);
        }

        public static int UpdateMeeting(string meetingId)
        {
            return SQLHelper.ExcuteProc("pro_Meeting");
        }
    }
}
