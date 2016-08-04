using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Meeting.Common
{
    public class Helper
    {
        public static string GetImageUrl(string type)
        {
            if (type == ".txt" || type == ".doc" || type == ".docx")
            {
                return "/Images/文本资料.png";
            }
            else if (type == ".png" || type == ".jpg" || type == ".gif" || type == ".bmp"||type==".jpeg")
            {
                return "/Images/图片资料.png";
            }
            else if (type == ".mp4" || type == ".wmv" || type == ".amv")
            {
                return "/Images/视频资料.png";
            }
            else if (type == ".mp3")
            {
                return "/Images/音频资料.png";
            }
            else
            {
                return "/Images/文本资料.png";
            }
        }

        public static int DelFileUrl(string url) 
        {
            if (File.Exists(url)) 
            {
                File.Delete(url);
                return 1;
            }
            return 0;
        }


        public static void DeleteFolder(string dir)
        {
            try
            {
                if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
                {
                    foreach (string d in Directory.GetFileSystemEntries(dir))
                    {
                        if (File.Exists(d))
                            File.Delete(d); //直接删除其中的文件 
                        //else
                        //  DeleteFolder(d); //递归删除子文件夹 
                    }
                    Directory.Delete(dir); //删除已空文件夹 
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
