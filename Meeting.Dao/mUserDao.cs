using Meeting.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Dao
{
    public class mUserDao
    {
        public static int AddUser(string user,string password,int roleId) 
        {
            string sql =string.Format(@"insert into m_User (UserName,UserRoleId,
                        UserDepartId,Passwrod,CreateDate) values ('{0}','{1}','{2}','{3}','{4}')",user,roleId,0,password,DateTime.Now.ToString());

            return SQLHelper.ExcuteSQL(sql);
        }


        public static int AddDepart(string departname) 
        {
            string sql = string.Format(@"insert into m_Depart (DepartName) values ('{0}')",departname);

            return SQLHelper.ExcuteSQL(sql);
        }
    }
}
