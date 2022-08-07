using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Mvcs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Mvcs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers
{
    /// <summary>
    /// Central Logger Manager
    /// </summary>
    public static class LoggerManager
    {
        // Todo
        private static readonly IDictionary<MvcType, string> MvcTypeLogFilePaths = new Dictionary<MvcType, string>();

        // Todo
        private static readonly IDictionary<MvcType, IMvcLogger> MvcTypeLoggers = new Dictionary<MvcType, IMvcLogger>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType">     </param>
        /// <param name="classLogging"></param>
        /// <returns></returns>
        public static IMvcLogger GetLogger(MvcType mvcType)
        {
            if (!MvcTypeLoggers.ContainsKey(mvcType))
            {
                MvcTypeLoggers[mvcType] = new MvcLogger(mvcType);
            }
            return MvcTypeLoggers[mvcType];
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcType"></param>
        /// <returns></returns>
        public static void EndLoggingFile(MvcType mvcType)
        {
            if (MvcTypeLoggers.ContainsKey(mvcType))
            {
                MvcTypeLoggers[mvcType].EndLogging();
                MvcTypeLogFilePaths.Remove(mvcType);
            }
        }
    }
}