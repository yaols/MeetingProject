using Meeting.Dao;
using Meeting.Entity;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Meeting.BLL
{
    public class MeetingService : IMeetingInterface
    {

        public DataSet GetMeetingList(int meetingType, int pageindex, int pagesize)
        {
            return MeetingDao.GetMeetingList(meetingType, pageindex, pagesize);
        }


        public mMeeting GetMeetingModel(int meetingId)
        {
            return MeetingDao.GetMeetingModel(meetingId);
        }

        public DataSet GetCreateMeeting()
        {
            return MeetingDao.GetCreateMeeting();
        }


        public int SaveMeeting(List<mMeetingResources> resources, List<mMeetingPeople> people, mMeeting meeting)
        {
            return MeetingDao.SaveMeeting(resources, people, meeting);
        }


        public CreateMeetingModel GetCreteMeetingModel(string meetingId) 
        {
            DataSet dataSet = MeetingDao.GetCreteMeetingModel(meetingId);
            CreateMeetingModel model = new CreateMeetingModel();
            if (dataSet != null) 
            {
                model.DepartList = new List<Depart>();
                SetDeparList(model.DepartList, dataSet.Tables[0]);
                model.UserList = new List<User>();
                SetUserList(model.UserList,dataSet.Tables[1]);
            }
            return model;
        }

        private void SetDeparList(List<Depart> departList, DataTable dataTable) 
        {
            Depart depart = null;
            if (dataTable != null && dataTable.Rows.Count > 0) 
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    depart = new Depart();
                    depart.Id = Convert.ToInt32(item["Id"]);
                    depart.DepartName = item["DepartName"].ToString();
                    departList.Add(depart);
                }
            }
        }


        private void SetUserList(List<User> departList, DataTable dataTable) 
        {
            User user = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    user = new User();
                    user.Id = Convert.ToInt32(item["UserId"]);
                    user.NickName = item["UserName"].ToString();
                    user.RoleId = Convert.ToInt32(item["UserRoleId"]);
                    departList.Add(user);
                }
            }
        }

        public int GetMeetingMaxId() 
        {
            return MeetingDao.GetMeetingMaxId();
        }

        public int InsertCreateMeeting(CreateMeeting model, int userId) 
        {
            model.year = "检委会" + model.year + "年  第" + model.count + "次  总" + model.numcount + "次会议";
            return MeetingDao.InsertCreateMeeting(model,userId);
        }

        public int EndMeeting(string meetingId) 
        {
            return MeetingDao.EndMeeting(meetingId);
        }
    }
}
