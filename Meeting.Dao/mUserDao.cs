using Meeting.Common;
using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Meeting.Dao
{
    public class mUserDao
    {
        public static int AddUser(string user, string password, int roleId)
        {
            string sql = string.Format(@"insert into m_User (UserName,UserRoleId,
                        UserDepartId,Passwrod,CreateDate) values ('{0}','{1}','{2}','{3}','{4}')", user, roleId, 0, password, DateTime.Now.ToString());

            return SQLHelper.ExcuteSQL(sql);
        }


        public static int AddDepart(string departname)
        {
            string sql = string.Format(@"insert into m_Depart (DepartName) values ('{0}')", departname);

            return SQLHelper.ExcuteSQL(sql);
        }

        /// <summary>
        /// 根据角色获取用户信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static List<mUser> GetUserList(int roleId)
        {
            List<mUser> userList = new List<mUser>();
            string sql = "select * from m_User where UserRoleId=@roleId";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@roleId",roleId),
           };

            mUser user = null;
            using (SqlDataReader reader = SQLHelper.GetReader(sql, paras))
            {
                while (reader.Read()) 
                {
                    user = new mUser();
                    user.UserId = Convert.ToInt32(reader["UserId"]);
                    user.UserName = reader["UserName"].ToString();
                    userList.Add(user);
                }
            }

            return userList;
        }

    }
}
