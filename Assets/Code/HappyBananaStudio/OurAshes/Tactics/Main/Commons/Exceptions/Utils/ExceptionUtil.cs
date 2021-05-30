using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils
{
    /// <summary>
    /// </summary>
    public class ExceptionUtil
    {
        // The String of what to split on when logging to insert the parameterized String
        private static readonly string[] Delimiters = new string[] { "{}" };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">       </param>
        /// <param name="parameterArray"></param>
        /// <returns></returns>
        private static string ConvertMessage(string message, params object[] parameterArray)
        {
            // Default the String to empty
            string convertedMessage = "";
            // Split the message based off of the character to split on
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
                        if (parameterObject is Type type)
                        {
                            // Append the String of the parameterObject
                            convertedMessage += type.Name;
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

        /// <summary>
        /// Todo
        /// </summary>
        public class Arguments
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static ArgumentException Build()
            {
                return Build("Todo-Build Error Message");
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="message"></param>
            /// <returns></returns>
            public static ArgumentException Build(string message)
            {
                return new ArgumentException(message);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="message">       </param>
            /// <param name="parameterArray"></param>
            /// <returns></returns>
            public static ArgumentException Build(string message, params object[] parameterArray)
            {
                return new ArgumentException(ConvertMessage(message, parameterArray));
            }
        }
    }
}