using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting.Entity
{
    public class CreateMeetingModel
    {
        public List<Depart> DepartList { get; set; }

        public List<User> UserList { get; set; }
    }

    public class Depart 
    {
        public int Id { get; set; }

        public string DepartName { get; set; }
    }

    public class User 
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public int RoleId { get; set; }
    }
}