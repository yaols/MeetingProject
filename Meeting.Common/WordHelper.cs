using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Meeting.Common
{
    public class WordHelper
    {
        /// <summary>
        /// Word转Pdf(源自文件->存成文件)
        /// </summary>
        /// <param name="wordFileFullPath">保存的Pdf文件绝对路径</param>
        /// <param name="pdfFileFullPath">读取的Word文件绝对路径</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Word2PdfFromFileSaveFile(string wordFileFullPath, string pdfFileFullPath, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            try
            {
                var doc = new Document(wordFileFullPath, new LoadOptions());
                doc.Save(pdfFileFullPath, SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        public static bool Word2HtmlFromFileSaveFileHtmlFixed(string wordFileFullPath, string htmlFileFullPath, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            try
            {
                var doc = new Document(wordFileFullPath, new LoadOptions());
                doc.Save(htmlFileFullPath, SaveFormat.HtmlFixed);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }

        public static bool Word2HtmlFromFileSaveFileHtml(string wordFileFullPath, string htmlFileFullPath, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            try
            {
                var doc = new Document(wordFileFullPath, new LoadOptions());
                doc.Save(htmlFileFullPath, SaveFormat.Html);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }


        public static bool HtmlFromFileSaveFileWord(string htmlFileFullPath, string wordFileFullPath, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            try
            {
                var doc = new Document(wordFileFullPath, new LoadOptions());
                doc.Save(htmlFileFullPath, SaveFormat.Docx);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }




        /// <summary>
        /// Word转Pdf(源自文件->存成byte[]数组)
        /// </summary>
        /// <param name="wordFileFullPath">读取的Word文件绝对路径</param>
        /// <param name="bytes">Pdf文件的byte[]bytes字节数组</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Word2PdfFromFileSaveBytes(string wordFileFullPath, out byte[] bytes, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            bytes = new byte[0];
            try
            {
                using (var pdfFileStream = new MemoryStream())//保存文件流；释放pdfFileStream
                {
                    var doc = new Document(wordFileFullPath);
                    doc.Save(pdfFileStream, SaveFormat.Pdf);
                    bytes = new byte[pdfFileStream.Length];
                    pdfFileStream.Read(bytes, 0, bytes.Length);
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
        /// Word转Pdf(源自byte[]数组->存成文件)
        /// </summary>
        /// <param name="buffer">Word文件byte[]bytes字节数组</param>
        /// <param name="pdfFileFullPath">保存的Pdf文件绝对路径</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Word2PdfFromBytesSaveFile(byte[] buffer, string pdfFileFullPath, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            try
            {
                using (var memorystream = new MemoryStream(buffer, 0, buffer.Length, true))//源文件流；释放memorystream
                {
                    var doc = new Document(memorystream);
                    doc.Save(pdfFileFullPath, SaveFormat.Pdf);
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
        /// Word转Pdf(源自byte[]数组->存成byte[]数组)
        /// </summary>
        /// <param name="buffer">Word文件byte[]bytes字节数组</param>
        /// <param name="bytes">Pdf文件的byte[]bytes字节数组</param>
        /// <param name="exceptionMessage">异常信息(发生异常exceptionMessage=异常信息,未发生异常exceptionMessage="")</param>
        /// <returns></returns>
        public static bool Word2PdfFromBytesSaveBytes(byte[] buffer, out byte[] bytes, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            bytes = new byte[0];
            try
            {
                using (var memorystream = new MemoryStream(buffer, 0, buffer.Length, true))//源文件流；释放memorystream
                {
                    using (var pdfFileStream = new MemoryStream())//保存文件流；释放pdfFileStream
                    {
                        var doc = new Document(memorystream);
                        doc.Save(pdfFileStream, SaveFormat.Pdf);
                        bytes = new byte[pdfFileStream.Length];
                        pdfFileStream.Read(bytes, 0, bytes.Length);
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

        public static bool GetWordTxtFromFile(string wordFileFullPath, string txtFileFullPath, out string exceptionMessage)
        {
            var returnResult = true;
            exceptionMessage = string.Empty;
            try
            {
                var doc = new Document(wordFileFullPath);
                var txtString = doc.GetText();
                FileHelper.String2File(txtFileFullPath, txtString, out exceptionMessage);
            }
            catch (Exception ex)
            {
                returnResult = false;
                exceptionMessage = ex.Message;
            }
            return returnResult;
        }
    }
}