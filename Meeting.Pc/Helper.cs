using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="requesturl"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string UploadFileHttpRequest(string fileName, string requesturl, string directory)
        {
            string output = string.Empty;
            MemoryStream postStream = null;
            BinaryWriter postWriter = null;
            HttpWebResponse response = null;
            StreamReader responseStream = null;

            const string CONTENT_BOUNDARY = "----------ae0cH2cH2GI3Ef1KM7GI3Ij5cH2gL6";
            const string CONTENT_BOUNDARY_PREFIX = "--";

            try
            {
                UriBuilder uriBuilder = new UriBuilder(requesturl);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; Maxthon; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.Timeout = 300000;
                request.ContentType = "multipart/form-data; boundary=" + CONTENT_BOUNDARY;
                postStream = new MemoryStream();
                postWriter = new BinaryWriter(postStream);
                //-- 参数
                //param['startTime']
                postWriter.Write(Encoding.GetEncoding("gb2312").GetBytes(CONTENT_BOUNDARY_PREFIX + CONTENT_BOUNDARY + "\r\n" +
"Content-Disposition: form-data; name=\"Directory\" \r\n\r\n"));
                postWriter.Write(Encoding.GetEncoding("gb2312").GetBytes(directory));
                postWriter.Write(Encoding.GetEncoding("gb2312").GetBytes("\r\n"));

                //uploadFiles
                postWriter.Write(Encoding.GetEncoding("utf-8").GetBytes(CONTENT_BOUNDARY_PREFIX + CONTENT_BOUNDARY + "\r\n" +
                "Content-Disposition: form-data; name=\"uploadFiles\" \r\n\r\n"));
                postWriter.Write(Encoding.GetEncoding("utf-8").GetBytes(fileName));
                postWriter.Write(Encoding.GetEncoding("utf-8").GetBytes("\r\n"));
                byte[] fileContent = File.ReadAllBytes(fileName);
                postWriter.Write(Encoding.GetEncoding("utf-8").GetBytes(CONTENT_BOUNDARY_PREFIX + CONTENT_BOUNDARY + "\r\n" +
                "Content-Disposition: form-data; name=\"FileContent\" " +
                "filename=\"" + Path.GetFileName(fileName) + "\"\r\n\r\n"));
                postWriter.Write(fileContent);
                postWriter.Write(Encoding.GetEncoding("utf-8").GetBytes("\r\n"));
                postWriter.Write(Encoding.GetEncoding("utf-8").GetBytes(CONTENT_BOUNDARY_PREFIX + CONTENT_BOUNDARY + "--"));

                request.ContentLength = postStream.Length;
                request.Method = "POST";
                Stream requestStream = request.GetRequestStream();
                postStream.WriteTo(requestStream);
                response = (HttpWebResponse)request.GetResponse();

                for (int i = 0; i < response.Headers.Count; i++)
                {
                    output += response.Headers.Keys[i] + ": " + response.GetResponseHeader(response.Headers.Keys[i]) + "\r\n";
                }
                Encoding enc = Encoding.GetEncoding("gb2312");

                try
                {
                    if (response.ContentEncoding.Length > 0) enc = Encoding.GetEncoding(response.ContentEncoding);
                }
                catch { }
                responseStream = new StreamReader(response.GetResponseStream(), enc);
                output += "\r\n\r\n\r\n" + responseStream.ReadToEnd();
            }
            finally
            {
                if (postWriter != null) postWriter.Close();
                if (postStream != null)
                {
                    postStream.Close();
                    postStream.Dispose();
                }
                if (response != null) response.Close();
                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();
                }
            }
            return output;
        }

        static WebClient webclient = new WebClient();
        public static string DownloadFile(string directory, string path)
        {
            string urladdress = "";
            string receivePath = "";
            string saveurl = "";
            string filename = @"\会议记录.docx";

            try
            {
                urladdress = ConfigurationManager.AppSettings["downUrl"].ToString();
                receivePath = ConfigurationManager.AppSettings["pcurl"].ToString();
                saveurl = string.Format("{0}{1}{2}", path, directory,filename);


                CreateDirectory(saveurl);
                webclient.DownloadFile(urladdress + directory + "//" + directory + ".docx", saveurl);
                return saveurl;
            }
            catch (Exception ex)
            {
                if (!File.Exists(saveurl + filename))
                    File.Create(saveurl + filename);
                return saveurl + filename;
            }
        }


        public static string DownloadFile(string directory, string path, string filename)
        {
            string urladdress = "";
            //string receivePath = "";
            string saveurl = "";

            string filesaveurl = "";
            try
            {
                urladdress = ConfigurationManager.AppSettings["downUrl"].ToString();
                //receivePath = ConfigurationManager.AppSettings["pcurl"].ToString();
                saveurl = string.Format("{0}{1}", path, directory);
                filesaveurl = saveurl +"\\"+ filename;
                if (!File.Exists(filesaveurl)) 
                {
                    CreateDirectory(saveurl);
                    webclient.DownloadFile(urladdress + directory + "//" + filename, filesaveurl);
                }

                return filesaveurl;
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        private static void CreateDirectory(string url)
        {
            if (!Directory.Exists(url))
            {
                Directory.CreateDirectory(url);
            }
        }

        public static string NickName { get; set; }
    }
}
