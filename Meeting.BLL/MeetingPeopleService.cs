using Meeting.Dao;
using Meeting.Entity;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.BLL
{
    public class MeetingPeopleService : IMeetingPeople
    {
        public int GetMeetingPeopleUserId(int userId, string meetingId) 
        {
            return MeetingPeopleDao.GetMeetingPeopleUserId(userId,meetingId);
        }

        public mMeetingOpinion GetMeetingOpinion(int userId, string meetingId) 
        {
            return MeetingPeopleDao.GetMeetingOpinion(userId,meetingId);
        }

        public int InserMeetingOpinion(int Id, string meetingId, int userId, int opinionAction, string msg) 
        {
            return MeetingPeopleDao.InserMeetingOpinion(Id,meetingId,userId,opinionAction,msg);
        }


        public  string GetMeetingRecord(string meetingId) 
        {
            return MeetingPeopleDao.GetMeetingRecord(meetingId);
        }

    }
}
