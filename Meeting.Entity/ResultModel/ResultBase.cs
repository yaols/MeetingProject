using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity.ResultModel
{
    public class ResultBase
    {
        public ResultCode Result { get; set; }

        public string Msg { get; set; }
    }
}
