using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Files.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Mvcs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Loggers.Classes.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Loggers.Files.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System;
using System.Collections.Generic;
using System.IO;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Loggers.Mvcs.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcLogger
        : IMvcLogger
    {
        private readonly IFileLogger fileLogger;
        private readonly IList<IClassLogger> classLoggers = new List<IClassLogger>();
        private readonly MvcType mvcType;

        public MvcLogger(MvcType mvcType)
        {
            this.mvcType = mvcType;
            this.fileLogger = new FileLogger(this.CreateLogFile(mvcType));
        }

        void IMvcLogger.EndLogging()
        {
            this.classLoggers.Clear();
            this.fileLogger.Shutdown();
        }

        IClassLogger IMvcLogger.GetClassLogger(Type type)
        {
            IClassLogger classLogger = new ClassLogger(mvcType, type, fileLogger);
            this.classLoggers.Add(classLogger);
            return classLogger;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private string CreateLogFile(MvcType mvcType)
        {
            UnityEngine.Debug.Log("CreateLogFile: " + mvcType);
            string logFileDate = DateTime.Now.ToLongDateString().Replace(':', '_')
            + "-" + DateTime.Now.ToLongTimeString().Replace(':', '_');
            string logFilePath = LoggerConstants.LoggerRootFolder + mvcType + "/" + logFileDate + ".log";
            // Check if the RootDirectory exists
            if (!Directory.Exists(LoggerConstants.LoggerRootFolder))
            {
                // Create the RootDirectory
                Directory.CreateDirectory(LoggerConstants.LoggerRootFolder);
            }
            // Check if the LogDirectory exists
            if (!Directory.Exists(LoggerConstants.LoggerRootFolder + mvcType))
            {
                // Create the LogDirectory
                Directory.CreateDirectory(LoggerConstants.LoggerRootFolder + mvcType);
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