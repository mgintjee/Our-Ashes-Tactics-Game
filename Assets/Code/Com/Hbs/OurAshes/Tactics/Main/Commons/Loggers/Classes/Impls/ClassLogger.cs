using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Consoles.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Consoles.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Files.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ClassLogger
        : IClassLogger
    {
        // Todo
        private readonly IConsoleLogger consoleLogger;

        // Todo
        private readonly IFileLogger fileLogger;

        // Todo
        private readonly MvcType mvcType;

        // Todo
        private readonly Type classType;

        public ClassLogger(MvcType mvcType, Type type, IFileLogger fileLogger)
        {
            this.mvcType = mvcType;
            this.classType = type;
            this.consoleLogger = new ConsoleLogger();
            this.fileLogger = fileLogger;
        }

        /// <inheritdoc/>
        void IClassLogger.Debug(string message)
        {
            this.LogDebug(this.ConvertMessage(LoggerConstants.HeaderDebug, message));
        }

        /// <inheritdoc/>
        void IClassLogger.Debug(string message, params object[] parameterArray)
        {
            this.LogDebug(this.ConvertMessage(LoggerConstants.HeaderDebug, message, parameterArray));
        }

        /// <inheritdoc/>
        void IClassLogger.Error(string message)
        {
            this.LogError(this.ConvertMessage(LoggerConstants.HeaderError, message));
        }

        /// <inheritdoc/>
        void IClassLogger.Error(string message, params object[] parameterArray)
        {
            this.LogError(this.ConvertMessage(LoggerConstants.HeaderError, message, parameterArray));
        }

        /// <inheritdoc/>
        void IClassLogger.Info(string message)
        {
            this.LogInfo(this.ConvertMessage(LoggerConstants.HeaderInfo, message));
        }

        /// <inheritdoc/>
        void IClassLogger.Info(string message, params object[] parameterArray)
        {
            this.LogInfo(this.ConvertMessage(LoggerConstants.HeaderInfo, message, parameterArray));
        }

        /// <inheritdoc/>
        void IClassLogger.Warn(string message)
        {
            this.LogWarn(this.ConvertMessage(LoggerConstants.HeaderWarn, message));
        }

        /// <inheritdoc/>
        void IClassLogger.Warn(string message, params object[] parameterArray)
        {
            this.LogWarn(this.ConvertMessage(LoggerConstants.HeaderWarn, message, parameterArray));
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
            string[] messageParts = message.Split(LoggerConstants.Delimiters, StringSplitOptions.RemoveEmptyEntries);

            if (messageParts.Length == 0)
            {
                foreach (object parameterObject in parameterArray)
                {
                    // Check if the parameterObject is non-null
                    if (parameterObject != null)
                    {
                        convertedMessage += StringUtils.Format(parameterObject);
                    }
                    else
                    {
                        // Append null
                        convertedMessage += "null";
                    }
                }
            }

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
                        convertedMessage += StringUtils.Format(parameterObject);
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
            return " | " + mvcType + " | " + classType.Name + " | " + prefix + " | " + message;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void LogDebug(string message)
        {
            this.consoleLogger.Debug(message);
            this.fileLogger.WriteToFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void LogError(string message)
        {
            this.consoleLogger.Error(message);
            this.fileLogger.WriteToFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void LogInfo(string message)
        {
            this.consoleLogger.Info(message);
            this.fileLogger.WriteToFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message"></param>
        private void LogWarn(string message)
        {
            this.consoleLogger.Warn(message);
            this.fileLogger.WriteToFile(message);
        }
    }
}