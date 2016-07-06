using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Interface
{
    public interface IMeetingResources
    {
        int InsertModel(mMeetingResources model);

        List<mMeetingResources> GetResourcesList(int meetingId,int userId);

        int DelResource(int  id);
    }
}
