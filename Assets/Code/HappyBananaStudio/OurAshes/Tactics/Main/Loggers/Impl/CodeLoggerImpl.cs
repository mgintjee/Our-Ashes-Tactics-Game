namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Todo
    /// </summary>
    public class CodeLoggerImpl
        : ICodeLogger
    {
        /*
         * Usage:
            // Provide logging capability
            private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);
         */

        // Define the Set: Type that will display logging. Empty means there will be no filter
        private static readonly ISet<Type> allowedLoggingTypes = new HashSet<Type>()
        {
            //typeof(AbstractComplexWidgetImpl),
            //typeof(PathFinderMoveUtil),
            //typeof(PathFinderMoveImpl),
            //typeof(MvcFrameworkScript),
            //typeof(MvcModelObject),
            //typeof(MvcModelScript),
            //typeof(MvcViewObject),
            //typeof(MvcViewScript),
        };

        // Todo
        private static readonly bool ENABLE_DEBUG = true;

        // Todo
        private static readonly bool ENABLE_ERROR = true;

        // Todo
        private static readonly bool ENABLE_INFO = true;

        // Todo
        private static readonly bool ENABLE_WARN = true;

        // Todo
        private static readonly string HEADER_DEBUG = "DEBUG: ";

        // Todo
        private static readonly string HEADER_ERROR = "ERROR: ";

        // Todo
        private static readonly string HEADER_INFO = "INFO: ";

        // Todo
        private static readonly string HEADER_WARN = "WARN: ";

        // Todo
        private static readonly string LOG_FILE_DIRECTORY = "gameLogs";

        // Todo
        private static readonly string LOG_FILE_INDEX = DateTime.Now.ToLongDateString().Replace(':', '_') + "-" +
            DateTime.Now.ToLongTimeString().Replace(':', '_');

        // Todo
        //private static readonly string LOG_FILE_INDEX = DateTime.Now.ToLongDateString().Replace(':', '_');

        // Todo
        private static readonly string LOG_FILE_NAME = LOG_FILE_DIRECTORY + "/ourAshesTacticsLog-" + LOG_FILE_INDEX + ".txt";

        // The String of what to split on when logging to insert the parameterized String
        private readonly char DELIMETER = '?';

        // The Type that will identify which class is currently logging
        private readonly Type loggingType;

        /// <summary>
        /// Constructor Method, to construct the Logger
        /// </summary>
        /// <param name="type">
        /// The Type of the class using this Logger
        /// </param>
        public CodeLoggerImpl(Type type)
        {
            this.loggingType = type;
        }

        /// <summary>
        /// Logger Method, to log a message with no parameters
        /// </summary>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        void ICodeLogger.Debug(string message)
        {
            this.LogDebug(this.ConvertMessage(HEADER_DEBUG, message));
        }

        /// <summary>
        /// Logger Method, to log a message with an array of parameters
        /// </summary>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        /// <param name="parameterArray">
        /// The Array: Object that will be logged
        /// </param>
        void ICodeLogger.Debug(string message, params object[] parameterArray)
        {
            this.LogDebug(this.ConvertMessage(HEADER_DEBUG, message, parameterArray));
        }

        /// <summary>
        /// Logger Method, to log an error message with no parameters
        /// </summary>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        void ICodeLogger.Error(string message)
        {
            this.LogError(this.ConvertMessage(HEADER_ERROR, message));
        }

        /// <summary>
        /// Logger Method, to log an error message with an array of parameters
        /// </summary>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        /// <param name="parameterArray">
        /// The Array: Object that will be logged
        /// </param>
        void ICodeLogger.Error(string message, params object[] parameterArray)
        {
            this.LogError(this.ConvertMessage(HEADER_ERROR, message, parameterArray));
        }

        /// <summary>
        /// Logger Method, to log a message with no parameters
        /// </summary>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        void ICodeLogger.Info(string message)
        {
            this.LogInfo(this.ConvertMessage(HEADER_INFO, message));
        }

        /// <summary>
        /// Logger Method, to log a message with an array of parameters
        /// </summary>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        /// <param name="parameterArray">
        /// The Array: Object that will be logged
        /// </param>
        void ICodeLogger.Info(string message, params object[] parameterArray)
        {
            this.LogInfo(this.ConvertMessage(HEADER_INFO, message, parameterArray));
        }

        /// <summary>
        /// Logger Method, to log a warning message with no parameters
        /// </summary>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        void ICodeLogger.Warn(string message)
        {
            this.LogWarn(this.ConvertMessage(HEADER_WARN, message));
        }

        /// <summary>
        /// Logger Method, to log a warning message with an array of parameters
        /// </summary>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        /// <param name="parameterArray">
        /// The Array: Object that will be logged
        /// </param>
        void ICodeLogger.Warn(string message, params object[] parameterArray)
        {
            this.LogWarn(this.ConvertMessage(HEADER_WARN, message, parameterArray));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        private static void WriteToLogFile(string message)
        {
            if (!Directory.Exists(LOG_FILE_DIRECTORY))
            {
                Directory.CreateDirectory(LOG_FILE_DIRECTORY);
            }
            StreamWriter logFileStream;
            if (!File.Exists(LOG_FILE_NAME))
            {
                logFileStream = File.CreateText(LOG_FILE_NAME);
            }
            else
            {
                logFileStream = File.AppendText(LOG_FILE_NAME);
            }
            logFileStream.Write(DateTime.Now.ToLongTimeString() + " " + message + "\n");
            logFileStream.Close();
        }

        /// <summary>
        /// Logger Method, to convert a message into the proper format
        /// </summary>
        /// <param name="prefix">
        /// The String prefix for the message
        /// </param>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        /// <param name="parameterArray">
        /// The Array: Object that will be logged
        /// </param>
        /// <returns>
        /// The String of the message with the parameterArray and loggingClass included
        /// </returns>
        private string ConvertMessage(string prefix, string message, params object[] parameterArray)
        {
            // Default the String to empty
            string convertedMessage = "";
            // Split the message based off of the character to split on
            string[] messageParts = message.Split(this.DELIMETER);
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
        /// <param name="prefix">
        /// The String prefix for the message
        /// </param>
        /// <param name="message">
        /// The String message to Log
        /// </param>
        /// <returns>
        /// The String of the message with the loggingClass included
        /// </returns>
        private string ConvertMessage(string prefix, string message)
        {
            return prefix + this.loggingType.Name + ": " + message;
        }

        /// <summary>
        /// </summary>
        /// <param name="potentialBase">
        /// </param>
        /// <param name="potentialDescendant">
        /// </param>
        /// <returns>
        /// </returns>
        private bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
        {
            return potentialDescendant.IsSubclassOf(potentialBase) ||
                    potentialDescendant == potentialBase ||
                   potentialBase.IsAssignableFrom(potentialDescendant);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        private void LogDebug(string message)
        {
            if (ENABLE_DEBUG && this.ValidLoggingType())
            {
                UnityEngine.Debug.Log(message);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        private void LogError(string message)
        {
            if (ENABLE_ERROR && this.ValidLoggingType())
            {
                UnityEngine.Debug.LogError(message);
            }
            WriteToLogFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        private void LogInfo(string message)
        {
            if (ENABLE_INFO && this.ValidLoggingType())
            {
                UnityEngine.Debug.Log(message);
            }
            WriteToLogFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        private void LogWarn(string message)
        {
            if (ENABLE_WARN && this.ValidLoggingType())
            {
                UnityEngine.Debug.LogWarning(message);
            }
            WriteToLogFile(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        private bool ValidLoggingType()
        {
            if (allowedLoggingTypes.Count == 0)
            {
                return true;
            }
            foreach (Type allowedType in allowedLoggingTypes)
            {
                if (this.IsSameOrSubclass(allowedType, this.loggingType))
                {
                    return true;
                }
            }
            return false;
        }
    }
}