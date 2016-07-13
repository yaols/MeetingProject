using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Interface
{
    public interface IMuserInterface
    {
        int AddUser(string user, string password, int roleId);

        int AddDepart(string departname);
    }
}
