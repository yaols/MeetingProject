using Meeting.Dao;
using Meeting.Entity;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.BLL
{
    public class MeetingIssue : IMeetingIssue
    {
        public mMeeting GetMeetingInfo(int meetingId) 
        {
            return MeetingIssueDao.GetMeetingInfo(meetingId);
        }


        public List<mMeetingResources> GetMeetingResources(int issueid) 
        {
            return MeetingIssueDao.GetMeetingResources(issueid);
        }
    }
}
