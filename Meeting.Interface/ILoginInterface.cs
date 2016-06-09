using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Interface
{
    public interface ILoginInterface
    {
        mUser LoginUserInfo(string username,string password);
    }
}
