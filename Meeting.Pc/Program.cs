using log4net.Config;
using Meeting.Pc.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Meeting.Pc
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\log4net_config.xml";
            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
            log4net.Config.XmlConfigurator.Configure();
            Application.Run(new FrmLogin());
        }
    }
}
