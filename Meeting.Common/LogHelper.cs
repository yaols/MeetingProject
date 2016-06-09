using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

namespace Meeting.Common
{
    public class LogHelper 
    {
         private const string SError = "Error";
        private const string SDebug = "Debug";
        private const string DefaultName = "Info";

        static LogHelper()
        {

        }

        public static ILog GetLog(string logName)
        {
            var log = LogManager.GetLogger(logName);
            return log;
        }

        public static void Debug(string message)
        {
            var log = LogManager.GetLogger(SDebug);
            if (log.IsDebugEnabled)
                log.Debug(message);
        }

        public static void Debug(string message, Exception ex)
        {
            var log = LogManager.GetLogger(SDebug);
            if (log.IsDebugEnabled)
                log.Debug(message, ex);
        }

        public static void Error(string message)
        {
            var log = LogManager.GetLogger(SError);
            if (log.IsErrorEnabled)
                log.Error(message);
        }

        public static void Error(string message, Exception ex)
        {
            var log =LogManager.GetLogger(SError);
            if (log.IsErrorEnabled)
                log.Error(message, ex);
        }

        public static void Fatal(string message)
        {
            var log = LogManager.GetLogger(DefaultName);
            if (log.IsFatalEnabled)
                log.Fatal(message);
        }

        public static void Info(string message)
        {
            log4net.ILog log = LogManager.GetLogger(DefaultName);
            if (log.IsInfoEnabled)
                log.Info(message);
        }

        public static void Warn(string message)
        {
            var log = LogManager.GetLogger(DefaultName);
            if (log.IsWarnEnabled)
                log.Warn(message);
        } 
    }
}