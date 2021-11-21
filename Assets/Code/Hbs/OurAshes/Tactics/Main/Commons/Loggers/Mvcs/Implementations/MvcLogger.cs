using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Constants;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Files.Implementations;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Files.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Mvcs.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Mvcs.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcLogger : IMvcLogger
    {
        private readonly IFileLogger fileLogger;
        private readonly ISet<IClassLogger> classLoggers = new HashSet<IClassLogger>();
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