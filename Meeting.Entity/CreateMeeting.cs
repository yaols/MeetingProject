using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{
    public class CreateMeeting
    {
        public string meetingId { get; set; }
        public string year { get; set; }

        public string count { get; set; }

        public string numcount { get; set; }

        public string datetimepicker1 { get; set; }

        public string datetimepicker2 { get; set; }

        public string address { get; set; }

        public string hoseUser { get; set; }
        /// <summary>
        /// 记录员
        /// </summary>
        public string record { get; set; }
        /// <summary>
        /// 秘书
        /// </summary>
        public string secretary { get; set; }

        /// <summary>
        /// 参会委员
        /// </summary>
        public string people { get; set; }
        /// <summary>
        /// 议题名称
        /// </summary>
        public string issue { get; set; }
        /// <summary>
        /// 申请部门
        /// </summary>
        public string depart { get; set; }
        /// <summary>
        /// 汇报人
        /// </summary>
        public string report { get; set; }
        /// <summary>
        /// 多媒体资料
        /// </summary>
        public string filearray { get; set; }
        /// <summary>
        /// 请假者
        /// </summary>
        public string leavePeople { get; set; }
        /// <summary>
        /// 列席者
        /// </summary>
        public string attendPeople { get; set; }

        /// <summary>
        /// 会议记录富文本框
        /// </summary>
        public string editor { get; set; }
    }
}
