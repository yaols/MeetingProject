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


        public static DataSet GetMeetingList(int meetingType,int userId,int pageindex, int pagesize)
        {
            int index = (pageindex - 1) * pagesize + 1;
            int size = pageindex * pagesize;

            DataSet dataSet = new DataSet();

            string sql = @"select RowId,MeetingId,MeetingName,StartDate,EendDate,MeetingType
                                  from ( select ROW_NUMBER() OVER (ORDER BY MeetingCreateDate desc) RowId,m.MeetingId,
                                  MeetingName,StartDate,EendDate,MeetingType from m_Meeting m
                                  join m_MeetingPeople p on m.MeetingId=p.MeetingId
                                  where MeetingType=@meetingType and Type=0 and p.UserId=@userId) a where a.RowId between @index and @size;
                                  select count(1) from m_Meeting m
                                  join m_MeetingPeople p on m.MeetingId=p.MeetingId
                                  where MeetingType=@meetingType and Type=0  and p.UserId=@userId";



            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@index",index),
               new SqlParameter("@size",size),
               new SqlParameter("@meetingType",meetingType),
               new SqlParameter("@userId",userId)
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
                                   MeetingDocument=(select UserName from m_User u where u.UserId=m.MeetingDocument),
                                   peopleName=(select [dbo].[GetMeetingPeople](@meetingId)),m.IssueName,
								   LeavePeople=(select [dbo].[GetMeetingPeopleOther](@meetingId,1)),
								   AttendPeople=(select [dbo].[GetMeetingPeopleOther](@meetingId,2)),
                                   RepostUser=(select UserName from m_User u where u.UserId=m.RepostUser),
                                   Directory=(select top 1 Directory from m_MeetingResources mr where mr.MeetingIssueId=m.MeetingId),
                                   d.DepartName,m.type,m.MeetingType,newDepartName  from m_Meeting m 
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
                //model.IssueList.DepartName = reader["DepartName"].ToString();
                model.IssueList.DepartName = reader["newDepartName"].ToString();
                //model.IssueList.Id = Tool.ToInt(reader["Id"].ToString());


                model.MeetingId = Tool.ToInt(reader["MeetingId"].ToString());
                model.MeetingName = reader["MeetingName"].ToString();
                model.StartDate = Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd HH:mm");
                model.EendDate = Convert.ToDateTime(reader["EendDate"]).ToString("yyyy-MM-dd HH:mm");
                model.AddressName = reader["AddressName"].ToString();
                model.MeetingHost = reader["HostName"].ToString();
                model.SecretaryName = reader["SecretaryName"].ToString();
                model.MeetingDocument = reader["MeetingDocument"].ToString();
                model.PeopleName = reader["PeopleName"].ToString();
                model.LeavePeople = reader["LeavePeople"].ToString();
                model.AttendPeople = reader["AttendPeople"].ToString();
                model.Directory = reader["Directory"].ToString();
                model.Type = Tool.ToInt(reader["Type"].ToString());
                model.MeetingType = Tool.ToInt(reader["MeetingType"].ToString());
            }

            return model;
        }


        public static DataSet GetCreateMeeting()
        {
            DataSet dataSet = new DataSet();

            string sql = @"select UserId,UserName from [dbo].[m_User];
            select Id,MeetingAddress from [dbo].[m_Address];
            select Id,DepartName from [dbo].[m_Depart];";

            return SQLHelper.GetDataSet(sql);
        }


        public static int SaveMeeting(List<mMeetingResources> resources, List<mMeetingPeople> people, mMeeting meeting)
        {
            int result = 0;

            string meetingsql = string.Format(@"insert into [m_Meeting](MeetingName,StartDate,EendDate,AddressId,
                                   MeetingHost,MeetingDocument,MeetingCreateDate,MeetingType,
                                   MeetingSecretary) values('{0}','{1}',
                                   '{2}','{3}','{4}','{5}','{6}','{7}','{8}');select @@identity", meeting.MeetingName, meeting.StartDate,
                                    meeting.EendDate, meeting.AddressName, meeting.MeetingHost, meeting.MeetingDocument,
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

        //        public static int InsertCreateMeeting(CreateMeeting model, int userId)
        //        {

        //            int result = 0;
        //            string sql = string.Format(@"insert into m_Meeting (MeetingName,StartDate,EendDate,AddressName,MeetingHost,
        //            MeetingDocument,MeetingCreateUser,MeetingCreateDate,MeetingType,MeetingSecretary,IssueName,RepostUser,DepartId,Type) values (
        //            '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}');select @@identity", model.year, model.datetimepicker1, model.datetimepicker2, model.address,
        //             model.hoseUser, model.wenshu, userId, DateTime.Now, 0, model.secretary, model.issue, model.report, model.depart,0);

        //            result = SQLHelper.ExcuteScalarSQL(sql);
        //            if (result > 0)
        //            {
        //                string saveUrl = string.Format("{0}{1}", Consts.SaveUrlPath, result);

        //                if (!Directory.Exists(saveUrl))
        //                    Directory.CreateDirectory(saveUrl);

        //                File.Copy(Consts.SaveUrlPath + "会议记录.docx", saveUrl + "\\" + result + ".docx");



        //                DataTable dt = SQLHelper.GetTableSchema();
        //                model.people = model.people.Substring(0, model.people.Length - 1);
        //                string[] arrayString = model.people.Split(',');
        //                if (arrayString != null)
        //                {
        //                    for (int i = 0; i < arrayString.Length; i++)
        //                    {
        //                        DataRow row = dt.NewRow();
        //                        row[1] = result;
        //                        row[2] = arrayString[i];
        //                        dt.Rows.Add(row);
        //                    }
        //                    result = SQLHelper.BulkToDB(dt, "m_MeetingPeople");
        //                }
        //            }

        //            return result;
        //        }


        public static int InsertCreateMeeting(CreateMeeting model, int userId)
        {

            int result = 0;
            string sql = string.Format(@"insert into m_Meeting (MeetingName,StartDate,EendDate,AddressName,MeetingHost,
            MeetingDocument,MeetingCreateUser,MeetingCreateDate,MeetingType,MeetingSecretary,IssueName,RepostUser,DepartId,Type,newDepartName) values (
            '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}');select @@identity", model.year, model.datetimepicker1, model.datetimepicker2, model.address,
             model.hoseUser, model.record, userId, DateTime.Now, 0, model.secretary, model.issue, model.report, "999", 0,model.newDepartName);

            result = SQLHelper.ExcuteScalarSQL(sql);
            if (result > 0)
            {
                //20170224 yaols会议记录不采用word
                string saveUrl = string.Format("{0}{1}", Consts.SaveUrlPath, result);
                if (!Directory.Exists(saveUrl))
                    Directory.CreateDirectory(saveUrl);
                //File.Copy(Consts.SaveUrlPath + "会议记录.docx", saveUrl + "\\" + result + ".docx");

                //多媒体资料
                DataTable resources = SQLHelper.GetTableResources();
                if (!string.IsNullOrEmpty(model.filearray))
                {
                    model.filearray = model.filearray.Substring(0, model.filearray.Length - 1);
                    string[] fileArray = model.filearray.Split(',');
                    if (fileArray != null)
                    {
                        for (int i = 0; i < fileArray.Length; i++)
                        {
                            DataRow row = resources.NewRow();
                            row[1] = Path.GetFileNameWithoutExtension(fileArray[i]);
                            row[2] = Path.GetExtension(fileArray[i]);
                            row[3] = result;
                            row[4] = result;
                            resources.Rows.Add(row);


                            try //20170224 yaols会议记录不采用word
                            {
                                File.Copy(Consts.TemporaryPath + fileArray[i], saveUrl + "\\" + fileArray[i]);
                                File.Delete(Consts.TemporaryPath + fileArray[i]);
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }

                        SQLHelper.BulkToDB(resources, "m_MeetingResources");
                    }
                }

                //参会委员
                DataTable dt = SQLHelper.GetTableSchema();
                string[] arrayString = Helper.GetStringToArray(model.people);
                if (arrayString != null)
                {
                    for (int i = 0; i < arrayString.Length; i++)
                    {
                        DataRow row = dt.NewRow();
                        row[1] = result;
                        row[2] = arrayString[i];
                        dt.Rows.Add(row);
                    }
                    SQLHelper.BulkToDB(dt, "m_MeetingPeople");
                }

                //议会其他人员
                GetMeetingPeopleOther(model.leavePeople, result, 1);
                GetMeetingPeopleOther(model.attendPeople, result, 2);
            }

            return result;
        }

        /// <summary>
        /// 议会其他人员
        /// </summary>
        /// <param name="str"></param>
        /// <param name="meetingId"></param>
        /// <param name="userType">1请假者  2列席者</param>
        private static void GetMeetingPeopleOther(string str, int meetingId, int userType)
        {
            DataTable other = SQLHelper.GetTableMeetingPeopleOther();
            string[] otherArray = Helper.GetStringToArray(str);
            if (otherArray != null)
            {
                for (int i = 0; i < otherArray.Length; i++)
                {
                    DataRow row = other.NewRow();
                    row[1] = meetingId;
                    row[2] = otherArray[i];
                    row[3] = userType;
                    other.Rows.Add(row);
                }
                SQLHelper.BulkToDB(other, "m_MeetingPeopleOther");
            }
        }



        public static int EndMeeting(string meetingId)
        {
            string sql = "update m_Meeting set MeetingType=1 where MeetingId=" + meetingId;

            return SQLHelper.ExcuteSQL(sql);
        }

        public static int UpdateMeeting(string meetingId)
        {
            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@meetingId",meetingId),
           };

            return SQLHelper.ExcuteProc("pro_Meeting", paras);
        }

        /// <summary>
        /// 会议记录
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public static DataSet GetMeetingRecord(int meetingId)
        {
            string sql = @"select *, 
            MeetingHostName=(select UserName from m_User u where m.MeetingHost=u.UserId), 
            MeetingDocumentName=(select UserName from m_User u where m.MeetingDocument=u.UserId), 
            MeetingSecretaryName=(select UserName from m_User u where m.MeetingSecretary=u.UserId), 
            RepostUserName=(select UserName from m_User u where m.RepostUser=u.UserId), 
            DepartName=(select DepartName from m_Depart d where m.DepartId=d.Id)
            from m_Meeting m
            where meetingId=@meetingId and Type=0;
            select * from m_MeetingPeople p
            join m_User u on p.UserId=u.UserId
            where meetingId=@meetingId;
            select * from m_MeetingPeopleOther p
            join m_User u on p.UserId=u.UserId
            where meetingId=@meetingId;
            select p.Id,p.MeetingId,p.UserId,u.UserName,u.Autograph,
            Isnull(m.OpinionAction,0) OpinionAction,m.OpinionMsg from m_MeetingPeople p    
            left join m_MeetingOpinion  m on p.MeetingId=m.MeetingId and p.UserId=m.UserId
            join m_User u on p.UserId=u.UserId where p.MeetingId=@meetingId;
            select * from m_MeetingRecord where MeetingId=@meetingId;";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@meetingId",meetingId),
           };

            return SQLHelper.GetDataSet(sql, paras);
        }

        /// <summary>
        /// 获取评审意见
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public static List<mMeetingOpinion> GetMeetingOpinion(string meetingId) 
        {
            List<mMeetingOpinion> list = new List<mMeetingOpinion>();
           

            string sql = @"select p.Id,p.MeetingId,p.UserId,u.UserName,u.Autograph,
            Isnull(m.OpinionAction,0) OpinionAction,m.OpinionMsg from m_MeetingPeople p    
            left join m_MeetingOpinion  m on p.MeetingId=m.MeetingId and p.UserId=m.UserId
            join m_User u on p.UserId=u.UserId where p.MeetingId=@meetingId;";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@meetingId",meetingId),
           };

            using (SqlDataReader reader = SQLHelper.GetReader(sql, paras)) 
            {
                 mMeetingOpinion model = null;
                while (reader.Read()) 
                {
                    model = new mMeetingOpinion();
                    model.Id =Convert.ToInt32(reader["Id"]);
                    model.OpinionAction = Convert.ToInt32(reader["OpinionAction"]);
                    model.OpinionMsg = reader["OpinionMsg"].ToString();
                    model.Autograph = reader["Autograph"].ToString();
                    model.UserName = reader["UserName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }


        /// <summary>
        /// 会议记录修改数据
        /// </summary>
        /// <param name="loginUserId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateMeetingRecord(int loginUserId, CreateMeeting model)
        {
            using (SqlConnection conn = new SqlConnection(SQLHelper.strConn))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); //开启事务
                try
                {
                    // MeetingCreateUser=@loginUserId,MeetingCreateDate=@MeetingCreateDate,
                    //修改会议基本数据
                    string sql = @"update m_Meeting set MeetingName=@MeetingName,StartDate=@StartDate,
                EendDate=@EendDate,AddressName=@address,MeetingHost=@hoseUser,MeetingDocument=@record,
                MeetingCreateUser=@loginUserId,
                MeetingSecretary=@secretary,
                DepartId=@depart,IssueName=@issue,newDepartName=@newDepartName,
                RepostUser=@report  where MeetingId=@meetingId";


                    SqlParameter[] paras = new SqlParameter[]
                    {
                        new SqlParameter("@MeetingName",model.year), //会议名称year+count+numcount拼接
                        new SqlParameter("@StartDate",model.datetimepicker1),
                        new SqlParameter("@EendDate",model.datetimepicker2),
                        new SqlParameter("@address",model.address),
                        new SqlParameter("@hoseUser",model.hoseUser),
                        new SqlParameter("@record",model.record),
                        new SqlParameter("@loginUserId",loginUserId),
                        //new SqlParameter("@MeetingCreateDate",DateTime.Now.ToString()),
                        new SqlParameter("@secretary",model.secretary),
                        //new SqlParameter("@depart",model.depart),
                        new SqlParameter("@depart","998"),
                        new SqlParameter("@issue",model.issue),
                        new SqlParameter("@report",model.report),
                        new SqlParameter("@meetingId",model.meetingId),
                        new SqlParameter("@newDepartName",model.newDepartName)

                    };

                    SQLHelper.ExcuteSQL(sql, paras);


                    //参会委员
                    sql = "delete from m_MeetingPeople where meetingId=@meetingId";
                    paras = new SqlParameter[]
                    {
                        new SqlParameter("@meetingId",model.meetingId)

                    };
                    SQLHelper.ExcuteSQL(sql, paras);
                    DataTable dt = SQLHelper.GetTableSchema();
                    string[] arrayString = Helper.GetStringToArray(model.people);
                    if (arrayString != null)
                    {
                        for (int i = 0; i < arrayString.Length; i++)
                        {
                            DataRow row = dt.NewRow();
                            row[1] = model.meetingId;
                            row[2] = arrayString[i];
                            dt.Rows.Add(row);
                        }
                        SQLHelper.BulkToDB(dt, "m_MeetingPeople");
                    }


                    //议会其他人员
                    sql = "delete from m_MeetingPeopleOther where meetingId=@meetingId";
                    paras = new SqlParameter[]
                    {
                        new SqlParameter("@meetingId",model.meetingId)

                    };
                    SQLHelper.ExcuteSQL(sql, paras);
                    GetMeetingPeopleOther(model.leavePeople, Convert.ToInt32(model.meetingId), 1);
                    GetMeetingPeopleOther(model.attendPeople, Convert.ToInt32(model.meetingId), 2);


                    //会议记录表新增数据
                    sql = @"if(select count(1) from m_MeetingRecord where MeetingId=@meetingId)>0
                    begin
                    update m_MeetingRecord set MeetingRecorder=@MeetingRecorder,LoginUserId=@LoginUserId,
                    uctime=@uctime where MeetingId=@meetingId
                    end
                    else
                    begin
                    insert into m_MeetingRecord values(@meetingId,@MeetingRecorder,
                    @ctime,@LoginUserId,@uctime)
                    end";
                    paras = new SqlParameter[]
                    {
                        new SqlParameter("@meetingId",model.meetingId),
                        new SqlParameter("@MeetingRecorder",model.editor),
                        new SqlParameter("@LoginUserId",loginUserId),
                        new SqlParameter("@uctime",DateTime.Now.ToString()),
                        new SqlParameter("@ctime",DateTime.Now.ToString()),
                    };
                    SQLHelper.ExcuteSQL(sql, paras);


                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// 重载方法
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public static mMeeting GetMeetingModel(string meetingId)
        {
            mMeeting model = new mMeeting();
            model.IssueList = new mMeetingIssue();
            //mMeetingIssue issue = null;

            string sql = @"select m.MeetingId,MeetingName,StartDate,EendDate,AddressName,IssueName,
                                   HostName=(select UserName from m_User u where u.UserId=m.MeetingHost),
                                   SecretaryName=(select UserName from m_User u where u.UserId=m.MeetingSecretary),
                                   MeetingDocument=(select UserName from m_User u where u.UserId=m.MeetingDocument),                                                                   
                                   peopleName=(select [dbo].[GetMeetingPeople](@meetingId)),m.IssueName,
								   LeavePeople=(select [dbo].[GetMeetingPeopleOther](@meetingId,1)),
								   AttendPeople=(select [dbo].[GetMeetingPeopleOther](@meetingId,2)),
                                   RepostUser=(select UserName from m_User u where u.UserId=m.RepostUser),
                                   Directory=(select top 1 Directory from m_MeetingResources mr where mr.MeetingIssueId=m.MeetingId),                                 
                                   d.DepartName,m.type,m.MeetingType,newDepartName  from m_Meeting m 
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
                //model.IssueList.DepartName = reader["DepartName"].ToString();
                model.IssueList.DepartName = reader["newDepartName"].ToString();
                //model.IssueList.Id = Tool.ToInt(reader["Id"].ToString());


                model.MeetingId = Tool.ToInt(reader["MeetingId"].ToString());
                model.MeetingName = reader["MeetingName"].ToString();
                model.StartDate = Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd HH:mm");
                model.EendDate = Convert.ToDateTime(reader["EendDate"]).ToString("yyyy-MM-dd HH:mm");
                model.AddressName = reader["AddressName"].ToString();

                model.MeetingHost = reader["HostName"].ToString();
                model.SecretaryName = reader["SecretaryName"].ToString();
                model.MeetingDocument = reader["MeetingDocument"].ToString();


                model.PeopleName = reader["PeopleName"].ToString();
                model.LeavePeople = reader["LeavePeople"].ToString();
                model.AttendPeople = reader["AttendPeople"].ToString();
                model.Directory = reader["Directory"].ToString();
                model.Type = Tool.ToInt(reader["Type"].ToString());
                model.MeetingType = Tool.ToInt(reader["MeetingType"].ToString());
            }

            return model;
        }
    }
}
