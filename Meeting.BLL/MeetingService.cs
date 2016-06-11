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
    }
}
