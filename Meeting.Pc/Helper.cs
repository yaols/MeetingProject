using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Meeting.Pc
{
   public class Helper
    {
       public static void KillProcess()
       {
           Process[] tProcess = Process.GetProcessesByName("WINWORD");
           foreach (var pid in tProcess)
           {
               Process ps = Process.GetProcessById(pid.Id);
               ps.Kill();
           }
       }
    }
}
