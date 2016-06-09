using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Meeting.Common
{
    public class Tool
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// 转换字符串为日期时间类型，错误返回当前时间
        /// </summary>
        /// <param name="objDtValue"></param>
        /// <returns></returns>
        public static DateTime? Convert3DateTime(object objDtValue)
        {
            DateTime dtTime = DateTime.Now;
            if (objDtValue != null)
            {
                DateTime.TryParse(objDtValue.ToString(), out dtTime);
            }
            if (IsEmpty(objDtValue.ToString()))
                return null;
            return dtTime;
        }

        public static DateTime Convert2DateTime(object objDtValue)
        {
            DateTime dtTime = DateTime.Now;
            if (objDtValue != null)
            {
                DateTime.TryParse(objDtValue.ToString(), out dtTime);
            }

            return dtTime;
        }

        /// <summary>
        /// 转换为数字,出错返回0
        /// </summary>
        /// <param name="objNum"></param>
        /// <returns></returns>
        public static int Convert2Int(object objNum)
        {
            int iValue = 0;
            if (objNum != null && objNum.ToString().Length > 0)
            {
                int.TryParse(objNum.ToString(), out iValue);
            }
            return iValue;
        }
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="objStr"></param>
        /// <returns></returns>
        public static string Convert2Str(object objStr)
        {
            string strReturn = "";
            if (objStr != null)
            {
                strReturn = objStr.ToString();
            }
            return strReturn;

        }

        /// <summary>
        /// 转换成int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(string str)
        {

            try
            {
                if (string.IsNullOrEmpty(str))
                    return 0;
                else
                {

                    if (Convert.ToInt32(str).GetType().ToString() == "System.Int32")
                        return Convert.ToInt32(str);
                    else
                        return 0;
                }
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// 转换成double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ToDouble(object objNum)
        {

            try
            {
                double iValue = 0;
                if (objNum != null && objNum.ToString().Length > 0)
                {
                    double.TryParse(objNum.ToString(), out iValue);
                }
                return iValue;
            }
            catch
            {
                return 0;
            }

        }

        public static decimal ToDecimal(string str)
        {

            try
            {
                if (string.IsNullOrEmpty(str))
                    return 0;
                else
                {

                    if (Convert.ToDecimal(str).GetType().ToString() == "System.Decimal")
                        return Convert.ToDecimal(str);
                    else
                        return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
        public static double Convert2Double(object objValue)
        {
            try
            {
                double dValue = 0;
                if (objValue != null)
                {
                    double.TryParse(objValue.ToString(), out dValue);
                }
                return dValue;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public static string InitNumberInt(object strVlue)
        {
            if (String.IsNullOrEmpty(Convert2Str(strVlue)) || Convert2Str(strVlue) == "0")
            {
                return "-";
            }
            string dsm = "-";
            try
            {
                long num = Convert.ToInt64(Convert2Double(strVlue));

                if (num.ToString().Length > 2)
                {
                    dsm = num.ToString().Substring(0, num.ToString().Length - 2) + "00";
                }
                else
                {
                    dsm = num.ToString();
                }
            }
            catch (Exception ex)
            {

                return "0";
            }

            return InitNumberStr(dsm);
        }
        /// <summary>
        /// 不会讲后两位数字 置为0
        /// </summary>
        /// <param name="strVlue"></param>
        /// <returns></returns>
        public static string InitNumberInt1(object strVlue)
        {
            if (String.IsNullOrEmpty(Convert2Str(strVlue)) || Convert2Str(strVlue) == "0")
            {
                return "-";
            }
            string dsm = "-";
            try
            {
                long num = Convert.ToInt64(Convert2Double(strVlue));

                //if (num.ToString().Length > 2)
                //{
                //    dsm = num.ToString().Substring(0, num.ToString().Length - 2) + "00";
                //}
                //else
                //{
                dsm = num.ToString();
                //}
            }
            catch (Exception ex)
            {

                return "0";
            }

            return InitNumberStr(dsm);
        }
        /// <summary>
        /// 初始化数字显示
        /// </summary>
        /// <param name="objIValue"></param>
        /// <returns></returns>
        public static string InitNumberStr(object objIValue)
        {
            try
            {
                double dValue = 0;
                if (objIValue != null)
                {
                    double.TryParse(objIValue.ToString(), out dValue);
                }
                return string.Format("{0:N0}", dValue);
            }
            catch (Exception ex)
            {

                return "";
            }
        }
        public static string GetValueFromWebConfig(string key)
        {
            string ret = "";
            try
            {
                ret = ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {
                ret = "";
            }
            return ret;
        }
        /// <summary>
        /// 判断字符创是否为空或者NULL
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;
            else
                return false;
        }
        public static Dictionary<string, string> GetAttachPath()
        {
            string savePath = Tool.GetValueFromWebConfig("SavePath");
            string saveUrl = Tool.GetValueFromWebConfig("SaveUrl");
            if (String.IsNullOrEmpty(savePath)) savePath = "~/Files/";
            if (String.IsNullOrEmpty(saveUrl))
            {
                saveUrl = savePath.Substring(1);
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("savePath", savePath);
            dic.Add("saveUrl", saveUrl);
            return dic;
        }
        /// <summary>
        /// MD5函数(加密方法)
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
        public static string MD5_Other(string str)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x2");
            return ret;
        }
        /// <summary>
        /// 当我们想要获得一个唯一的key的时候，通常会想到GUID。这个key非常的长，虽然我们在很多情况下这并不是个问题。但是当我们需要将这个36个字符的字符串放在URL中时，会使的URL非常的丑陋。
        /// 想要缩短GUID的长度而不牺牲它的唯一性是不可能的，但是如果我们能够接受一个16位的字符串的话是可以做出这个牺牲的。
        /// 我们可以将一个标准的GUID 21726045-e8f7-4b09-abd8-4bcc926e9e28  转换成短的字符串 3c4ebc5f5f2c4edc 
        /// 下面的方法会生成一个短的字符串，并且这个字符串是唯一的。重复1亿次都不会出现重复的，它也是依照GUID的唯一性来生成这个字符串的
        /// </summary>
        /// <returns></returns>
        public static string GenerateStringID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(object Expression, bool defValue)
        {
            if (Expression != null)
            {
                if (string.Compare(Expression.ToString(), "true", true) == 0)
                {
                    return true;
                }
                else if (string.Compare(Expression.ToString(), "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }


        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">字符串数组</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }
        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else
                {
                    if (strSearch == stringArray[i])
                    {
                        return i;
                    }
                }

            }
            return -1;
        }
        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }


                if (startIndex > str.Length)
                {
                    return "";
                }


            }
            else
            {
                if (length < 0)
                {
                    return "";
                }
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            if (str.Length - startIndex < length)
            {
                length = str.Length - startIndex;
            }

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64String(string str)
        {
            try
            {
                byte[] bytes = Encoding.Default.GetBytes(str);
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return "";
            }

        }
        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FromBase64String(string str)
        {
            try
            {
                byte[] outputb = Convert.FromBase64String(str);
                return Encoding.Default.GetString(outputb);
            }
            catch
            {
                return "";
            }

        }
        /// <summary>
        /// 0 转换为空，显示用
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToZeroEmpty(object num)
        {
            if (num == null)
                return "";
            if (num.ToString() == "0" || num.ToString() == "0.00" || num.ToString() == "0001-01-01")
                return "";
            return num.ToString();
        }


        /// <summary>
        /// 判断是否为数字，true是数字
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static bool IsNumber(string strNumber)
        {
            if (strNumber == string.Empty || strNumber == null)
                return false;
            try
            {
                decimal.Parse(strNumber);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        public static void WriteLogToTxt(string txt, string fileName)
        {
            try
            {
                //string strPath = System.Environment.CurrentDirectory + @"\Log\";
                string strPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\LogPrint\";
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }

                using (FileStream aFile = new FileStream(strPath + fileName + ".txt", FileMode.Append))
                {
                    StreamWriter sw = new StreamWriter(aFile);
                    sw.WriteLine(txt);
                    sw.Close();
                }
            }
            catch (IOException ex)
            {
            }

        }
        /// <summary>
        /// 将日期转换成时间戳
        /// </summary>
        /// <param name="dtime"></param>
        /// <returns></returns>
        public static long DataTimeToTimespan(DateTime dtime)
        {

            DateTime oldTime = new DateTime(1970, 1, 1);
            TimeSpan span = dtime.Subtract(oldTime);
            long milliSecondsTime = (long)span.Ticks;
            return milliSecondsTime;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ConvertIntDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 万级资金单位转换 转换为万 或亿
        /// </summary>
        /// <param name="num"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string WCapitalNumUnitChange(decimal num, out string unit)
        {
            string number = "";
            unit = "万";
            if (num == 0)
            {
                unit = "";
                return number;
            }
            if (num >= 10000)
            {
                number = Math.Round((num / 10000), 2, MidpointRounding.AwayFromZero).ToString();
                unit = "亿";
            }
            else
            {
                number = Math.Floor((num)).ToString("0");
            }
            return number;
        }
        /// <summary>
        /// 转换字符串为Decimal类型，错误返回0
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static decimal ConvertDecimal(object objValue)
        {
            try
            {
                decimal dValue = 0;
                if (objValue != null)
                {
                    decimal.TryParse(objValue.ToString(), out dValue);
                }
                return dValue;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        /// <summary>
        /// 日期转天数
        /// </summary>
        /// <param name="date1"></param>
        /// <returns></returns>
        public static string ConvertDateString(DateTime date1)
        {
            string des = "";
            if (date1 != null)
            {
                int days = (DateTime.Now - date1).Days;
                if (days / 30 > 0)
                    des = days + "个月前";
                else
                    des = days + "天前";
            }

            return des;
        }

        private static double EARTH_RADIUS = 6378137;//赤道半径(单位m)
        /// <summary>
        /// 转化为弧度(rad)
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 基于余弦定理求两经纬度距离 
        /// </summary>
        /// <param name="lon1"></param>
        /// <param name="lat1"></param>
        /// <param name="lon2"></param>
        /// <param name="lat2"></param>
        /// <returns></returns>
        public static int LantitudeLongitudeDist(string lat1, string lng1, string lat2, string lng2)
        {
            double radLat1 = Rad(Convert.ToDouble(lat1));
            double radLat2 = Rad(Convert.ToDouble(lat2));
            double a = radLat1 - radLat2;
            double b = Rad(Convert.ToDouble(lng1)) - Rad(Convert.ToDouble(lng2));
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
            Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return Convert.ToInt32(s);
        }

        /// <summary>
        /// 转换千米
        /// </summary>
        /// <param name="km"></param>
        /// <returns></returns>
        public static string ConvertDistance(int km)
        {
            if (km < 1000)
                return km + "米";
            else
                return (km / 1000) + "千米";
        }

        /// <summary>
        /// 时间差
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string AgoTime(DateTime time)
        {
            string times = string.Empty;
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = time;
            TimeSpan ts = dt1 - dt2;

            if (ts.Days > 0)
            {
                times = ts.Days.ToString() + "天前";
            }
            else if (ts.Hours > 0)
            {
                times = ts.Hours.ToString() + "小时前";
            }
            else
            {
                times = "刚刚";
            }
            return times;
        }
    }
}
