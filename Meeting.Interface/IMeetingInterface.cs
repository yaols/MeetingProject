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
    }
}
