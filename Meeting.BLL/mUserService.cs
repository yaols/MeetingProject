using Meeting.Dao;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.BLL
{
    public class mUserService : IMuserInterface
    {

        public int AddUser(string user, string password, int roleId)
        {
            return mUserDao.AddUser(user,password,roleId);
        }


        public int AddDepart(string departname)
        {
            return mUserDao.AddDepart(departname);
        }
    }
}
