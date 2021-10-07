using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers
{
    /// <summary>
    /// Central Logger Manager
    /// </summary>
    public static class LoggerManager
    {
        // Todo
        private static readonly IDictionary<MvcType, string> MvcTypeLogFilePaths = new Dictionary<MvcType, string>();

        // Todo
        private static readonly string _loggerRootFolder = "mvc_logs/";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType">     </param>
        /// <param name="classLogging"></param>
        /// <returns></returns>
        public static ILogger GetLogger(MvcType mvcType, Type classLogging)
        {
            return BuildLogger(mvcType, classLogging);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType"></param>
        /// <returns></returns>
        public static void EndLoggingFile(MvcType mvcType)
        {
            MvcTypeLogFilePaths.Remove(mvcType);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="classLogging"></param>
        /// <returns></returns>
        private static ILogger BuildLogger(MvcType mvcType, Type classLogging)
        {
            if (!MvcTypeLogFilePaths.ContainsKey(mvcType))
            {
                MvcTypeLogFilePaths.Add(mvcType, CreateLogFile(mvcType));
                UnityEngine.Debug.Log("Log File: " + MvcTypeLogFilePaths[mvcType]);
            }
            return new Logger(mvcType, classLogging, MvcTypeLogFilePaths[mvcType]);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private static string CreateLogFile(MvcType mvcType)
        {
            UnityEngine.Debug.Log("CreateLogFile: " + mvcType);
            string logFileDate = DateTime.Now.ToLongDateString().Replace(':', '_')
            + "-" + DateTime.Now.ToLongTimeString().Replace(':', '_');
            string logFilePath = _loggerRootFolder + mvcType + "/" + logFileDate + ".log";
            // Check if the RootDirectory exists
            if (!Directory.Exists(_loggerRootFolder))
            {
                // Create the RootDirectory
                Directory.CreateDirectory(_loggerRootFolder);
            }
            // Check if the LogDirectory exists
            if (!Directory.Exists(_loggerRootFolder + mvcType))
            {
                // Create the LogDirectory
                Directory.CreateDirectory(_loggerRootFolder + mvcType);
            }
            // Check if the file exists
            if (!File.Exists(logFilePath))
            {
                // Create the logFile
                File.CreateText(logFilePath).Close();
            }
            return logFilePath;
        }
    }
}