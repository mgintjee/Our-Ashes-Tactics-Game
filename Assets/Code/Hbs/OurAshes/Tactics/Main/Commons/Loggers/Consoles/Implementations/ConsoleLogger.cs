using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Consoles.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Consoles.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ConsoleLogger : IConsoleLogger
    {
        /// <inheritdoc/>
        void IConsoleLogger.Debug(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        /// <inheritdoc/>
        void IConsoleLogger.Error(string message)
        {
            UnityEngine.Debug.LogError(message);
        }

        /// <inheritdoc/>
        void IConsoleLogger.Info(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        /// <inheritdoc/>
        void IConsoleLogger.Warn(string message)
        {
            UnityEngine.Debug.LogWarning(message);
        }
    }
}