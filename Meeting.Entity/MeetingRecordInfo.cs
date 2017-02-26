using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{
    /// <summary>
    /// 秘书会议记录信息表
    /// </summary>
    public class MeetingRecordInfo
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }

        public string MeetingRecorder { get; set; }

        public string ctime { get; set; }

        public int LoginUserId { get; set; }

        public string uctime { get; set; }

    }
}
