using Meeting.Entity.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity
{

    public class mUser : ResultBase
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }

        public int UserDepartId { get; set; }

        public string UserDepartName { get; set; }

        public string PassWord { get; set; }

        public DateTime CreateDate { get; set; }


        public DateTime LoginDate { get; set; }
    }
}
