using log4net.Config;
using Meeting.Pc.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Meeting.Pc
{
    static class Program
    {

        //static IntPtr m_pDll;
        //private delegate bool m_GainPrivileges();
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

            //m_pDll = Win32API.LoadLibrary(".\\InkAnnotations.dll");
            //if (m_pDll != null)
            //{
            //    IntPtr pAddOfFunToCall = Win32API.GetProcAddress(m_pDll, "GainPrivileges");
            //    m_GainPrivileges GainPrivileges = (m_GainPrivileges)Marshal.GetDelegateForFunctionPointer(
            //                                                                                         pAddOfFunToCall,
            //                                                                                       typeof(m_GainPrivileges));


            //    bool flag = GainPrivileges();  //获取权限，打开Word前调用，只需执行一次
            //}


            Application.Run(new FrmLogin());
        }
    }
}
