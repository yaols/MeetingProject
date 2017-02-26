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

        public string AddressName { get; set; }

        public string MeetingHost { get; set; }

        /// <summary>
        /// 记录员
        /// </summary>
        public string MeetingDocument { get; set; }

        public string MeetingCreateUser { get; set; }

        public DateTime MeetingCreateDate { get; set; }

        public int MeetingType { get; set; }

        public int MeetingSecretary { get; set; }

        public string SecretaryName { get; set; }

        public mMeetingIssue IssueList {get;set; }

        /// <summary>
        /// 参会委员
        /// </summary>
        public string PeopleName { get; set; }

        public string Directory { get; set; }

        public int Type { get; set; }

        /// <summary>
        /// 请假者
        /// </summary>
        public string LeavePeople { get; set; }

        /// <summary>
        /// 出席者
        /// </summary>
        public string AttendPeople { get; set; }


        /// <summary>
        /// 议题
        /// </summary>
        public string IssueName { get; set; }

        /// <summary>
        /// 申请部门
        /// </summary>
        public int DepartId { get; set; }

        /// <summary>
        /// 汇报人
        /// </summary>
        public int RepostUser { get; set; }

        public string MeetingHostName { get; set; }

        public string MeetingDocumentName { get; set; }

        public string MeetingSecretaryName { get; set; }

        public string RepostUserName { get; set; }

        public string DepartName { get; set; }
    }
}
