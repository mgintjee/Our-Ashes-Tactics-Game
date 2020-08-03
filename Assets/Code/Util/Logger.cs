using System;
using System.Collections.Generic;

/// <summary>
/// Util Class for Logging
/// </summary>
public class Logger
{
    /*
     * Usage:
     // Provide logging capability
     private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);
     */

    // Todo: Have a text log generated?
    // Todo: Have a log displayed in game?

    #region Private Fields

    // Define the Set: Type that will display logging
    private static readonly HashSet<Type> ALLOWED_LOGGING_TYPES = new HashSet<Type>()
    {
        //typeof(MvcControllerObject),
        //typeof(MvcControllerScript),
        //typeof(MvcFrameworkObject),
        //typeof(MvcFrameworkScript),
        //typeof(MvcModelObject),
        //typeof(MvcModelScript),
        //typeof(MvcViewObject),
        //typeof(MvcViewScript),
    };

    private static readonly bool ENABLE_DEBUG = true;
    private static readonly bool ENABLE_ERROR = true;
    private static readonly bool ENABLE_INFO = true;
    private static readonly bool ENABLE_WARN = true;
    private static readonly string HEADER_DEBUG = "DEBUG: ";
    private static readonly string HEADER_ERROR = "ERROR: ";
    private static readonly string HEADER_INFO = "INFO: ";
    private static readonly string HEADER_WARN = "WARN: ";

    // is for
    private readonly Type loggingType;

    // The String of what to split on when logging to insert the parameterized String
    private readonly char splitOn = '?';

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Constructor Method, to construct the Logger
    /// </summary>
    /// <param name="type">The Type of the class using this Logger</param>
    public Logger(Type type)
    {
        this.loggingType = type;
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Logger Method, to log a message with no parameters
    /// </summary>
    /// <param name="message">The String message to Log</param>
    public void Debug(string message)
    {
        this.LogDebug(this.ConvertMessage(HEADER_DEBUG, message));
    }

    /// <summary>
    /// Logger Method, to log a message with an array of parameters
    /// </summary>
    /// <param name="message">       The String message to Log</param>
    /// <param name="parameterArray">The Array: Object that will be logged</param>
    public void Debug(string message, params object[] parameterArray)
    {
        this.LogDebug(this.ConvertMessage(HEADER_DEBUG, message, parameterArray));
    }

    /// <summary>
    /// Logger Method, to log an error message with no parameters
    /// </summary>
    /// <param name="message">The String message to Log</param>
    public void Error(string message)
    {
        this.LogError(this.ConvertMessage(HEADER_ERROR, message));
    }

    /// <summary>
    /// Logger Method, to log an error message with an array of parameters
    /// </summary>
    /// <param name="message">       The String message to Log</param>
    /// <param name="parameterArray">The Array: Object that will be logged</param>
    public void Error(string message, params System.Object[] parameterArray)
    {
        this.LogError(this.ConvertMessage(HEADER_ERROR, message, parameterArray));
    }

    /// <summary>
    /// Logger Method, to log a message with no parameters
    /// </summary>
    /// <param name="message">The String message to Log</param>
    public void Info(string message)
    {
        this.LogInfo(this.ConvertMessage(HEADER_INFO, message));
    }

    /// <summary>
    /// Logger Method, to log a message with an array of parameters
    /// </summary>
    /// <param name="message">       The String message to Log</param>
    /// <param name="parameterArray">The Array: Object that will be logged</param>
    public void Info(string message, params object[] parameterArray)
    {
        this.LogInfo(this.ConvertMessage(HEADER_INFO, message, parameterArray));
    }

    /// <summary>
    /// </summary>
    /// <param name="potentialBase">      </param>
    /// <param name="potentialDescendant"></param>
    /// <returns></returns>
    public bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
    {
        return potentialDescendant.IsSubclassOf(potentialBase)
               || potentialDescendant == potentialBase;
    }

    /// <summary>
    /// Logger Method, to log a warning message with no parameters
    /// </summary>
    /// <param name="message">The String message to Log</param>
    public void Warn(string message)
    {
        this.LogWarn(this.ConvertMessage(HEADER_WARN, message));
    }

    /// <summary>
    /// Logger Method, to log a warning message with an array of parameters
    /// </summary>
    /// <param name="message">       The String message to Log</param>
    /// <param name="parameterArray">The Array: Object that will be logged</param>
    public void Warn(string message, params object[] parameterArray)
    {
        this.LogWarn(this.ConvertMessage(HEADER_WARN, message, parameterArray));
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Logger Method, to convert a message into the the proper format
    /// </summary>
    /// <param name="prefix">        The String prefix for the message</param>
    /// <param name="message">       The String message to Log</param>
    /// <param name="parameterArray">The Array: Object that will be logged</param>
    /// <returns>The String of the message with the parameterArray and loggingClass included</returns>
    private string ConvertMessage(string prefix, string message, params System.Object[] parameterArray)
    {
        // Default the String to the prefix
        string convertedMessage = "";
        // Split the message based off of the character to split on
        string[] messageParts = message.Split(this.splitOn);
        // Iterate over the MessageParts
        for (int i = 0; i < messageParts.Length; ++i)
        {
            // Append the first part of the Message
            convertedMessage += messageParts[i];
            // Check if there is a corresponding
            if (i < parameterArray.Length)
            {
                // Collect the parameterObject from the parameterArray
                System.Object parameterObject = parameterArray[i];
                // Check if the parameterObject is non-null
                if (parameterObject != null)
                {
                    // Append the String of the parameterObject
                    convertedMessage += parameterObject.ToString();
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
    /// Logger Method, to convert a message into the the proper format
    /// </summary>
    /// <param name="prefix"> The String prefix for the message</param>
    /// <param name="message">The String message to Log</param>
    /// <returns>The String of the message with the loggingClass included</returns>
    private string ConvertMessage(string prefix, string message)
    {
        return prefix + this.loggingType.ToString() + ": " + message;
    }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    private void LogDebug(string message)
    {
        if (ENABLE_DEBUG && this.ValidLoggingType())
        {
            UnityEngine.Debug.Log(message);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    private void LogError(string message)
    {
        if (ENABLE_ERROR && this.ValidLoggingType())
        {
            UnityEngine.Debug.LogError(message);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    private void LogInfo(string message)
    {
        if (ENABLE_INFO && this.ValidLoggingType())
        {
            UnityEngine.Debug.Log(message);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="message"></param>
    private void LogWarn(string message)
    {
        if (ENABLE_WARN && this.ValidLoggingType())
        {
            UnityEngine.Debug.LogWarning(message);
        }
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    private bool ValidLoggingType()
    {
        if (ALLOWED_LOGGING_TYPES.Count == 0)
        {
            return true;
        }
        foreach (Type allowedType in ALLOWED_LOGGING_TYPES)
        {
            if (this.IsSameOrSubclass(allowedType, this.loggingType))
            {
                return true;
            }
        }
        return false;
    }

    #endregion Private Methods
}