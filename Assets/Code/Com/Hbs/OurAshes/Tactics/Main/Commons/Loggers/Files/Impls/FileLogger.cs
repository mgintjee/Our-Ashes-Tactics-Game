using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Files.Inters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Files.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FileLogger : IFileLogger
    {
        // Todo
        private readonly Queue<string> _messageQueue = new Queue<string>();

        // Todo
        private readonly Thread loggingThread;

        // Todo
        private readonly string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
            loggingThread = new Thread(this.LogToFile);
            loggingThread.Start();
        }

        void IFileLogger.Shutdown()
        {
            this.loggingThread.Join(1_000);
        }

        void IFileLogger.WriteToFile(string message)
        {
            this._messageQueue.Enqueue(message);
        }

        private void LogToFile()
        {
            while (true)
            {
                if (this._messageQueue.Count != 0)
                {
                    StreamWriter logFileStream = File.AppendText(_logFilePath);
                    logFileStream.Write(DateTime.Now.ToLongTimeString() + ": " + this._messageQueue.Dequeue() + "\n");
                    logFileStream.Close();
                }
            }
        }
    }
}