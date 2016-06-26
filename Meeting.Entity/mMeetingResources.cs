using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{
    public class mMeetingResources
    {
        public int Id { get; set; }

        public string ResourcesName { get; set; }

        public int ResourcesType { get; set; }

        public int MeetingIssueId { get; set; }

        public string ResourcesUrl { get; set; }

        public string Directory { get; set; }
    }
}
