using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{
    /// <summary>
    /// 会议记录审核表
    /// </summary>
    public class mMeetingOpinion
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// 审批动作  0未处理  1同意  2不同意
        /// </summary>
        public int OpinionAction { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        public string OpinionMsg { get; set; }


        public string Ctime { get; set; }


        public string Uctime { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Autograph { get; set; }

    }
}
