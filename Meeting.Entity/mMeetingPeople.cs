using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{
   public class mMeetingPeople
    {
        public int Id { get; set; }

        public int MeetingId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}
