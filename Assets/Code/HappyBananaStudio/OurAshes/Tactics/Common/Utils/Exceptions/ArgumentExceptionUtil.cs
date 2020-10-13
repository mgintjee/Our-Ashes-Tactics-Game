/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;

namespace HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ArgumentExceptionUtil
    {
        // The String of what to split on when logging to insert the parameterized String
        private static readonly char DELIMETER = '?';

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ArgumentException Build()
        {
            return new ArgumentException();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <returns>
        /// </returns>
        public static ArgumentException Build(string message)
        {
            return new ArgumentException(message);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="parameterArray">
        /// </param>
        /// <returns>
        /// </returns>
        public static ArgumentException Build(string message, params object[] parameterArray)
        {
            return new ArgumentException(ConvertMessage(message, parameterArray));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="parameterArray">
        /// </param>
        /// <returns>
        /// </returns>
        private static string ConvertMessage(string message, params object[] parameterArray)
        {
            // Default the String to empty
            string convertedMessage = "";
            // Split the message based off of the character to split on
            string[] messageParts = message.Split(DELIMETER);
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

            return convertedMessage;
        }
    }
}
