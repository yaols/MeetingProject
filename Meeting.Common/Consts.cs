using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Meeting.Common
{
    public class Consts
    {
        /// <summary>
        /// 服务器文件上传地址
        /// </summary>
        public static readonly string SaveUrlPath = ConfigurationManager.AppSettings["saveurl"];
        /// <summary>
        ///服务器上传文件下载地址
        /// </summary>
        public static readonly string DwonUrlPath = ConfigurationManager.AppSettings["downurl"];
        /// <summary>
        /// word转html读取地址
        /// </summary>
        public static readonly string UrlPath = ConfigurationManager.AppSettings["url"];
        /// <summary>
        /// PC服务器存取资源
        /// </summary>
        public static readonly string PcUrlPath = ConfigurationManager.AppSettings["pcurl"];
        /// <summary>
        /// 上传临时文件地址
        /// </summary>
        public static readonly string TemporaryPath = ConfigurationManager.AppSettings["temporary"];

        /// <summary>
        /// 秘书
        /// </summary>
        public static readonly int SecretaryType = 2;

        /// <summary>
        /// 委员
        /// </summary>
        public static readonly int CommitteeMember=1;

    }
}
