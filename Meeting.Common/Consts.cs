using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Meeting.Common
{
    public class Consts
    {
        public static readonly string SaveUrlPath = ConfigurationManager.AppSettings["saveurl"];

        public static readonly string DwonUrlPath = ConfigurationManager.AppSettings["downurl"];

        public static readonly string UrlPath = ConfigurationManager.AppSettings["url"];

        public static readonly string PcUrlPath = ConfigurationManager.AppSettings["pcurl"];

        public static readonly string TemporaryPath = ConfigurationManager.AppSettings["temporary"];
    }
}
