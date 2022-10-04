namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IClassLogger
    {
        /// <summary>
        /// Logger Method, to log a message with no parameters
        /// </summary>
        /// <param name="message">The String message to Log</param>
        void Debug(string message);

        /// <summary>
        /// Logger Method, to log a message with an array of parameters
        /// </summary>
        /// <param name="message">       The String message to Log</param>
        /// <param name="parameterArray">The Array: Object that will be logged</param>
        void Debug(string message, params object[] parameterArray);

        /// <summary>
        /// Logger Method, to log an error message with no parameters
        /// </summary>
        /// <param name="message">The String message to Log</param>
        void Error(string message);

        /// <summary>
        /// Logger Method, to log an error message with an array of parameters
        /// </summary>
        /// <param name="message">       The String message to Log</param>
        /// <param name="parameterArray">The Array: Object that will be logged</param>
        void Error(string message, params object[] parameterArray);

        /// <summary>
        /// Logger Method, to log a message with no parameters
        /// </summary>
        /// <param name="message">The String message to Log</param>
        void Info(string message);

        /// <summary>
        /// Logger Method, to log a message with an array of parameters
        /// </summary>
        /// <param name="message">       The String message to Log</param>
        /// <param name="parameterArray">The Array: Object that will be logged</param>
        void Info(string message, params object[] parameterArray);

        /// <summary>
        /// Logger Method, to log a warning message with no parameters
        /// </summary>
        /// <param name="message">The String message to Log</param>
        void Warn(string message);

        /// <summary>
        /// Logger Method, to log a warning message with an array of parameters
        /// </summary>
        /// <param name="message">       The String message to Log</param>
        /// <param name="parameterArray">The Array: Object that will be logged</param>
        void Warn(string message, params object[] parameterArray);
    }
}