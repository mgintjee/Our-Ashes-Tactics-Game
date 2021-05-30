using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using System;
using System.IO;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractLogger
        : ILogger
    {
        // Todo
        protected string LogDirectory;

        // Todo
        protected string LogFileName;

        // The Type that will identify which class is currently logging
        protected Type loggingType;

        // The String of what to split on when logging to insert the parameterized String
        private static readonly string[] Delimiters = new string[] { "{}" };

        // Todo
        private static readonly string HeaderDebug = "DEBUG: ";

        // Todo
        private static readonly string HeaderError = "ERROR: ";

        // Todo
        private static readonly string HeaderInfo = "INFO: ";

        // Todo
        private static readonly string HeaderWarn = "WARN: ";

        // Todo
        private static readonly string RootDirectory = "mvcLogs";

        /// <inheritdoc/>
        void ILogger.CreateLogFile()
        {
            string logFileDate = DateTime.Now.ToLongDateString().Replace(':', '_')
            + "-" + DateTime.Now.ToLongTimeString().Replace(':', '_');
            this.LogFileName = RootDirectory + this.LogDirectory + "/log-" + logFileDate + ".log";
            // Check if the RootDirectory exists
            if (!Directory.Exists(RootDirectory))
            {
                // Create the RootDirectory
                Directory.CreateDirectory(RootDirectory);
            }
            // Check if the LogDirectory exists
            if (!Directory.Exists(RootDirectory + this.LogDirectory))
            {
                // Create the LogDirectory
                Directory.CreateDirectory(RootDirectory + this.LogDirectory);
            }
            // Check if the file exists
            if (!File.Exists(this.LogFileName))
            {
                // Create the logFile
                File.CreateText(this.LogFileName);
            }
        }

        /// <inheritdoc/>
        void ILogger.Debug(string message)
        {
            this.LogDebug(this.ConvertMessage(HeaderDebug, message));
        }

        /// <inheritdoc/>
        void ILogger.Debug(string message, params object[] parameterArray)
        {
            this.LogDebug(this.ConvertMessage(HeaderDebug, message, parameterArray));
        }

        /// <inheritdoc/>
        void ILogger.Error(string message)
        {
            this.LogError(this.ConvertMessage(HeaderError, message));
        }

        /// <inheritdoc/>
        void ILogger.Error(string message, params object[] parameterArray)
        {
            this.LogError(this.ConvertMessage(HeaderError, message, parameterArray));
        }

        /// <inheritdoc/>
        void ILogger.Info(string message)
        {
            this.LogInfo(this.ConvertMessage(HeaderInfo, message));
        }

        /// <inheritdoc/>
        void ILogger.Info(string message, params object[] parameterArray)
        {
            this.LogInfo(this.ConvertMessage(HeaderInfo, message, parameterArray));
        }

        /// <inheritdoc/>
        void ILogger.Warn(string message)
        {
            this.LogWarn(this.ConvertMessage(HeaderWarn, message));
        }

        /// <inheritdoc/>
        void ILogger.Warn(string message, params object[] parameterArray)
        {
            this.LogWarn(this.ConvertMessage(HeaderWarn, message, parameterArray));
        }

        /// <summary>
        /// Logger Method, to convert a message into the proper format
        /// </summary>
        /// <param name="prefix">        The String prefix for the message</param>
        /// <param name="message">       The String message to Log</param>
        /// <param name="parameterArray">The Array: Object that will be logged</param>
        /// <returns>The String of the message with the parameterArray and loggingClass included</returns>
        private string ConvertMessage(string prefix, string message, params object[] parameterArray)
        {
            // Default the String to empty
            string convertedMessage = "";
            // Split the message based off of the subString to split on
            string[] messageParts = message.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
            // Iterate over the MessageParts
            for (int i = 0; i < messageParts.Length; ++i)
            {
                // Append the first part of the Message
                convertedMessage += messageParts[i];
                // Check if there is a corresponding
                if (i < parameterArray.Length)
                {
                    // Collect the parameterObject from the parameterArray
                    object parameterObject = parameterArray[i];
                    // Check if the parameterObject is non-null
                    if (parameterObject != null)
                    {
                        if (parameterObject is Type)
                        {
                            // Append the String of the parameterObject
                            convertedMessage += ((Type)parameterObject).Name;
                        }
                        else
                        {
                            // Append the String of the parameterObject
                            convertedMessage += parameterObject.ToString();
                        }
                    }
                    else
                    {
                        // Append null
                        convertedMessage += "null";
                    }
                }
            }

            return this.ConvertMessage(prefix, convertedMessage);
        }

        /// <summary>
        /// Logger Method, to convert a message into the proper format
        /// </summary>
        /// <param name="prefix"> The String prefix for the message</param>
        /// <param name="message">The String message to Log</param>
        /// <returns>The String of the message with the loggingClass included</returns>
        private string ConvertMessage(string prefix, string message)
        {
            return prefix + this.loggingType.Name + ": " + message;
        }

        /// <summary>
        /// </summary>
        /// <param name="potentialBase">      </param>
        /// <param name="potentialDescendant"></param>
        /// <returns></returns>
        private bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
        {
            return potentialDescendant.IsSubclassOf(potentialBase) ||
                    potentialDescendant == potentialBase ||
                   potentialBase.IsAssignableFrom(potentialDescendant);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void LogDebug(string message)
        {
            UnityEngine.Debug.Log(message);
            WriteToLogFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void LogError(string message)
        {
            UnityEngine.Debug.LogError(message);
            WriteToLogFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void LogInfo(string message)
        {
            UnityEngine.Debug.Log(message);
            WriteToLogFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void LogWarn(string message)
        {
            UnityEngine.Debug.LogWarning(message);
            WriteToLogFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void WriteToLogFile(string message)
        {
            StreamWriter logFileStream = File.AppendText(this.LogFileName);
            logFileStream.Write(DateTime.Now.ToLongTimeString() + ": " + message + "\n");
            logFileStream.Close();
        }
    }
}