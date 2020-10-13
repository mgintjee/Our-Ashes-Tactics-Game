/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Loggers
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICodeLogger
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        void Debug(string message);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="parameterArray">
        /// </param>
        void Debug(string message, params object[] parameterArray);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        void Error(string message);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="parameterArray">
        /// </param>
        void Error(string message, params object[] parameterArray);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        void Info(string message);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="parameterArray">
        /// </param>
        void Info(string message, params object[] parameterArray);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        void Warn(string message);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="parameterArray">
        /// </param>
        void Warn(string message, params object[] parameterArray);
    }
}
