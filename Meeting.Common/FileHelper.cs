using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Meeting.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 将String文本信息-Text文件
        /// </summary>
        /// <param name="fileFullPath">保存的文件绝对路径</param>
        /// <param name="content">String文本信息</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool String2File(string fileFullPath, string content, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            try
            {
                using (var sw = new StreamWriter(fileFullPath, false, Encoding.UTF8))
                {
                    sw.Write(content);
                }
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        /// <summary>
        /// 将 byte[] 转成 Stream
        /// </summary>
        /// <param name="bytes">传入的bytes</param>
        /// <param name="stream">返回的stream</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Bytes2Stream(byte[] bytes, out Stream stream, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            stream = new MemoryStream();
            try
            {
                stream = new MemoryStream(bytes);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        /// <summary>
        /// 将 Stream 转成 byte[]
        /// </summary>
        /// <param name="stream">传入的stream</param>
        /// <param name="bytes">返回的bytes</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Stream2Bytes(Stream stream, out  byte[] bytes, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            bytes = new byte[0];
            try
            {
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Seek(0, SeekOrigin.Begin);   // 设置当前流的位置为流的开始 
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        ///  <summary>
        /// 将 Stream 写入文件
        ///  </summary>
        ///  <param name="stream">读取的stream</param>
        ///  <param name="fileFullPath">存文件的绝对路径</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        public static bool Stream2File(Stream stream, string fileFullPath, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            try
            {
                //把 Stream 转换成 byte[] 
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                // 设置当前流的位置为流的开始 
                stream.Seek(0, SeekOrigin.Begin);
                // 把 byte[] 写入文件 
                using (var fs = new FileStream(fileFullPath, FileMode.Create))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        bw.Write(bytes);
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        /// <summary>
        /// 从文件读取Stream
        /// </summary>
        /// <param name="fileFullPath">读取文件的绝对路径</param>
        /// <param name="stream">返回的stream</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool File2Stream(string fileFullPath, out Stream stream, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            stream = new MemoryStream();
            try
            {
                using (var fileStream = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read, FileShare.Read)) // 打开文件 
                {
                    //读取文件的 byte[] 
                    var bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, bytes.Length);
                    //把 byte[] 转换成 Stream 
                    stream = new MemoryStream(bytes);
                }
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        /// <summary>
        /// byte[]转string
        /// </summary>
        /// <param name="bytes">传入byte[]</param>
        /// <param name="converter">new System.Text .UTF8Encoding()/UnicodeEncoding()(默认应该是传UTF8)</param>
        /// <param name="outputString">返回的string</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Bytes2String(byte[] bytes, Encoding converter, out  string outputString, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            outputString = string.Empty;
            try
            {
                outputString = converter.GetString(bytes);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        /// <summary>
        /// string转byte[]
        /// </summary>
        /// <param name="inputString">传入string</param>
        /// <param name="outputBytes">返回的byte[]</param>
        /// <param name="converter">new System.Text .UTF8Encoding()/UnicodeEncoding()(默认应该是传UTF8)</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool String2Bytes(string inputString, out byte[] outputBytes, Encoding converter, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            outputBytes = new byte[0];
            try
            {
                outputBytes = converter.GetBytes(inputString);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        /// <summary>
        /// byte[]转base64String(为了给TrsFullText1使用)
        /// </summary>
        /// <param name="bytes">传入byte[]</param>
        /// <param name="outputBase64String">返回的base64String</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Bytes2Base64String(byte[] bytes, out string outputBase64String, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            outputBase64String = string.Empty;
            try
            {
                outputBase64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        /// <summary>
        /// base64String转byte[](为了给TrsFullText1使用)
        /// </summary>
        /// <param name="base64String">传入base64String</param>
        /// <param name="outputBytes">返回的byte[]</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Base64String2Bytes(string base64String, out byte[] outputBytes, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            outputBytes = new byte[0];
            try
            {
                outputBytes = Convert.FromBase64String(base64String);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        /// <summary>
        /// content追加到已经存在的文件中
        /// </summary>
        /// <param name="txtFileFullPath">txt的文件绝对路径</param>
        /// <param name="content">需要保存的内容</param>
        /// <returns></returns>
        public static bool WriteMessageAppendText(string txtFileFullPath, string content)
        {
            //这里应该有个判断当前text文本是否写满的策略
            var returnResult = true;
            try
            {
                using (var fs = new FileStream(txtFileFullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        var dt = DateTime.Now;
                        sw.WriteLine(string.Format("{0}-{1}", dt, "Begin↓"));
                        sw.WriteLine(content);
                        sw.WriteLine(string.Format("{0}-{1}", dt, "End↑"));
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = false;
            }
            return returnResult;
        }
    }
}