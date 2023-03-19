using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Consoles.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Loggers.Consoles.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ConsoleLogger
        : IConsoleLogger
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