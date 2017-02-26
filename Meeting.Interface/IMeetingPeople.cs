using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Interface
{
     public interface IMeetingPeople
    {
         int GetMeetingPeopleUserId(int userId, string meetingId);

         mMeetingOpinion GetMeetingOpinion(int userId, string meetingId);

         int InserMeetingOpinion(int Id, string meetingId, int userId, int opinionAction, string msg);

         string GetMeetingRecord(string meetingId);

    }
}
