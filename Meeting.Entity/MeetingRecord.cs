using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{
    
    /// <summary>
    /// 会议记录
    /// </summary>
    public class MeetingRecord
    {
        public int MeetingId { get; set; }


        public string MeetingName { get; set;}

        /// <summary>
        /// 检委会xxxx年
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// 第x次
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// 总第x次会议
        /// </summary>
        public string TotalNum { get; set; }


        public string StartDate { get; set; }

        public string EendDate { get; set; }

        /// <summary>
        /// 会议地点
        /// </summary>
        public string MeetingAddress { get; set; }


        /// <summary>
        /// 会议主持人
        /// </summary>
        public int MeetingHost { get; set; }

        /// <summary>
        /// 会议秘书
        /// </summary>
        public int MeetingSecretary { get; set; }

        /// <summary>
        /// 记录员
        /// </summary>
        public int MeetingDocument { get; set; }

        /// <summary>
        /// 参会委员
        /// </summary>
        public string PeopleName { get; set; }

        /// <summary>
        /// 请假者
        /// </summary>
        public string LeavePeople { get; set; }
        /// <summary>
        /// 列席者
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

        /// <summary>
        /// 委员审批意见表
        /// </summary>
        public List<mMeetingOpinion> MeetingOpinion { get; set; }


        public List<User> UserList;

        public List<Depart> DepartList { get; set; }

        /// <summary>
        /// 会议记录信息表
        /// </summary>
        public MeetingRecordInfo MeetingRecordInfo { get; set; }


        /// <summary>
        /// 参会委员
        /// </summary>
        public string PeopleNickName { get; set; }

        /// <summary>
        /// 请假者
        /// </summary>
        public string LeaveNickName { get; set; }
        /// <summary>
        /// 列席者
        /// </summary>
        public string AttendNickName { get; set; }

        /// <summary>
        /// 主持名称
        /// </summary>
        public string MeetingHostName { get; set; }

        /// <summary>
        /// 记录名称
        /// </summary>
        public string MeetingDocumentName { get; set; }

        /// <summary>
        /// 秘书名称
        /// </summary>
        public string MeetingSecretaryName { get; set; }

        /// <summary>
        /// 汇报人名称
        /// </summary>
        public string RepostUserName { get; set; }

        /// <summary>
        ///  申请部门名称
        /// </summary>
        public string DepartName { get; set; }

    }
}
