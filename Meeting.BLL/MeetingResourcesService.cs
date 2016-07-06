using Meeting.Dao;
using Meeting.Entity;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.BLL
{
    public class MeetingResourcesService : IMeetingResources
    {
        public int InsertModel(mMeetingResources model) 
        {
            return MeetingResourcesDao.InsertModel(model);
        }

        public List<mMeetingResources> GetResourcesList(int meetingId,int userId) 
        {
            return MeetingResourcesDao.GetResourcesList(meetingId,userId);
        }

        public int DelResource(int id) 
        {
            return MeetingResourcesDao.DelResource(id);
        }
    }
}
