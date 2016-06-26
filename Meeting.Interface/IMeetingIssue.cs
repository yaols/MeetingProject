using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Interface
{
    public interface IMeetingIssue
    {
        mMeeting GetMeetingInfo(int meetingId);

        List<mMeetingResources> GetMeetingResources(int issueid);
    }
}
