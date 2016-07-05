using Meeting.Dao;
using Meeting.Entity;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.BLL
{
    public class LoginService : ILoginInterface
    {
        public mUser LoginUserInfo(string username, string password,int roleId)
        {
            return LoginDao.LoginUserInfo(username, password, roleId);
        }
    }
}
