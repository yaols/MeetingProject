using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting.Web.Api.Models
{
    public class MeetingSearch
    {
        public int ? PageIndex { get; set; }

        public int MeetingType { get; set; }

        public int MeetingId { get; set; }

        public int PageType { get; set; }

        public int Directory { get; set; }

        public string ResourceName { get; set; }

        public string ResourcesType { get; set; }
    }
}