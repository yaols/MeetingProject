using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Meeting.Common.BLL
{
    /// <summary>
    /// 业务处理
    /// </summary>
    public class MeetingRecordBLL
    {
        public  MeetingRecord GetMeetingRecord(DataSet dataSet)
        {
            MeetingRecord model = new MeetingRecord();
            if (dataSet != null) 
            {
                if (dataSet.Tables[0] != null && dataSet.Tables[0].Rows.Count > 0) 
                {
                    var meeting = ModelHandler.GetEntity<mMeeting>(dataSet.Tables[0]);
                    GetMeetingRecordModel(meeting,model);
                }

                if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0) 
                {

                    foreach (DataRow item in dataSet.Tables[1].Rows)
                    {
                        model.PeopleName =model.PeopleName + item["UserId"].ToString()+",";
                        model.PeopleNickName = model.PeopleNickName + item["UserName"].ToString() + ",";
                    }
                    model.PeopleName = model.PeopleName.Substring(0, model.PeopleName.Length-1);
                    model.PeopleNickName = model.PeopleNickName.Substring(0, model.PeopleNickName.Length - 1);
                }

                if (dataSet.Tables[2] != null && dataSet.Tables[2].Rows.Count > 0)
                {

                    foreach (DataRow item in dataSet.Tables[2].Rows)
                    {
                        if (item["UserType"].ToString() == "2") 
                        {
                            model.AttendPeople = model.AttendPeople + item["UserId"].ToString() + ",";
                            model.AttendNickName = model.AttendNickName + item["UserName"].ToString() + ",";
                        }
                        else if (item["UserType"].ToString() == "1") 
                        {
                            model.LeavePeople = model.LeavePeople + item["UserId"].ToString() + ",";
                            model.LeaveNickName = model.LeaveNickName + item["UserName"].ToString() + ",";
                        }
                        
                    }


                    if (!string.IsNullOrEmpty(model.AttendPeople)&& model.AttendPeople.Length > 0)
                    {
                        model.AttendPeople = model.AttendPeople.Substring(0, model.AttendPeople.Length - 1);
                        model.AttendNickName = model.AttendNickName.Substring(0, model.AttendNickName.Length - 1);
                    }


                    if (!string.IsNullOrEmpty(model.LeavePeople)&&model.LeaveNickName.Length > 0)
                    {
                        model.LeaveNickName = model.LeaveNickName.Substring(0, model.LeaveNickName.Length - 1);
                        model.LeavePeople = model.LeavePeople.Substring(0, model.LeavePeople.Length - 1);
                    }
                                       
                }

                if (dataSet.Tables[3] != null && dataSet.Tables[3].Rows.Count > 0) 
                {
                    model.MeetingOpinion = ModelHandler.GetEntities<mMeetingOpinion>(dataSet.Tables[3]);
                }


                if (dataSet.Tables[4] != null && dataSet.Tables[4].Rows.Count > 0)
                {
                    model.MeetingRecordInfo = ModelHandler.GetEntity<MeetingRecordInfo>(dataSet.Tables[4]);
                }

            }


            return model;
        }

        /// <summary>
        /// 实体转换
        /// </summary>
        /// <param name="meeting"></param>
        /// <param name="model"></param>
        private void GetMeetingRecordModel(mMeeting meeting, MeetingRecord model) 
        {
            string[] array = GetstringSpilit(meeting.MeetingName);
            if (array.Length > 0) 
            {
                model.Year = GetStringToNum(array[0]);
                model.Num = GetStringToNum(array[2]);
                model.TotalNum = GetStringToNum(array[4]);
            }

            model.MeetingId = meeting.MeetingId;
            model.StartDate =Convert.ToDateTime(meeting.StartDate).ToString("yyyy-MM-dd HH:mm");
            model.EendDate = Convert.ToDateTime(meeting.EendDate).ToString("yyyy-MM-dd HH:mm");
            model.MeetingAddress = meeting.AddressName;
            model.MeetingHost =Convert.ToInt32(meeting.MeetingHost);
            model.MeetingSecretary = meeting.MeetingSecretary;
            model.MeetingDocument =Convert.ToInt32(meeting.MeetingDocument);
            model.DepartId = meeting.DepartId;
            model.IssueName = meeting.IssueName;
            model.RepostUser = meeting.RepostUser;
            model.MeetingName = meeting.MeetingName;
            model.MeetingHostName = meeting.MeetingHostName;
            model.MeetingDocumentName = meeting.MeetingDocumentName;
            model.MeetingSecretaryName = meeting.MeetingSecretaryName;
            model.RepostUserName = meeting.RepostUserName;
            //model.DepartName = meeting.DepartName;
            model.DepartName = meeting.newDepartName;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string[] GetstringSpilit(string str) 
        {
            if (!string.IsNullOrEmpty(str)) 
            {
               return str.Split(' ');
            }

            return new string[0];
        }


        /// <summary>
        /// 字符串提取数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetStringToNum(string str) 
        {
            return System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
        }
    }
}
