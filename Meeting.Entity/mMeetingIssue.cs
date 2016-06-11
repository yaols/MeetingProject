using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{
   public class mMeetingIssue
    {
        public int Id { get; set; }

        public string IssueName { get; set; }

        public int RepostUserId { get; set; }

        public string RepostUser { get; set; }

        public int DepartId { get; set; }

        public int MeetingId { get; set; }

        public string DepartName { get; set; }
    }
}
