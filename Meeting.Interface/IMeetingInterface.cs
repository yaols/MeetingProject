using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Meeting.Interface
{
    public interface IMeetingInterface
    {
        DataSet GetMeetingList(int meetingType, int pageindex, int pagesize);

        mMeeting GetMeetingModel(int meetingId);

        DataSet GetCreateMeeting();

        int SaveMeeting(List<mMeetingResources> resources,List<mMeetingPeople> people,mMeeting meeting);

        CreateMeetingModel GetCreteMeetingModel(string meetingId);

        int GetMeetingMaxId();

        int InsertCreateMeeting(CreateMeeting model,int userId);

        int EndMeeting(string meetingId);
    }
}
