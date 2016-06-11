using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{
    public class mMeeting
    {
        public int RowId { get; set; }

        public int MeetingId { get; set; }

        public string MeetingName { get; set; }

        public string StartDate { get; set; }

        public string EendDate { get; set; }

        public string MeetingAddress { get; set; }

        public string MeetingHost { get; set; }

        public string MeetingDocument { get; set; }

        public string MeetingCreateUser { get; set; }

        public DateTime MeetingCreateDate { get; set; }

        public int MeetingType { get; set; }

        public int MeetingSecretary { get; set; }

        public string SecretaryName { get; set; }

        public List<mMeetingIssue> IssueList {get;set; }

        public string PeopleName { get; set; }
    }
}
