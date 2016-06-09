using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meeting.Entity.Pager
{
    public class PageOption 
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int PageCount { get; set; }
    }
}