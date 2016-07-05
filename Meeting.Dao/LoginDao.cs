using Meeting.Common;
using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Meeting.Dao
{
    public class LoginDao
    {


        public static mUser LoginUserInfo(string username, string password,int roleId)
        {
            mUser model = new mUser();

            string sql = @"select UserId,UserName,UserRoleId,ur.RoleName,UserDepartId,
                                    Passwrod,CreateDate,d.DepartName  from m_User u
                                    left join m_UserRole  ur on u.UserRoleId=ur.Id 
                                     left join m_Depart d  on u.UserDepartId=d.Id
                                    where  UserName=@userName and Passwrod=@passwrod";

            SqlParameter[] paras = new SqlParameter[]
           {
               new SqlParameter("@userName",username),
               new SqlParameter("@passwrod",password)
           };

            SqlDataReader reade = SQLHelper.GetReader(sql, paras);
            if (reade.Read()) 
            {
                model.UserId = Tool.ToInt(reade["UserId"].ToString());
                model.UserName = reade["UserName"].ToString();
                model.UserRoleId = Tool.ToInt(reade["UserRoleId"].ToString());
                model.UserRoleName = reade["RoleName"].ToString();
                model.UserDepartId = Tool.ToInt(reade["UserRoleId"].ToString());
                model.UserDepartName = reade["DepartName"].ToString();
                model.PassWord = reade["Passwrod"].ToString();
            }


            return model;
        }
    }
}
