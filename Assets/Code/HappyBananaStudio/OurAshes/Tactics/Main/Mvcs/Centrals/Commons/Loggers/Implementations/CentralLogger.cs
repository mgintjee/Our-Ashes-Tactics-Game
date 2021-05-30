using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Implementations.Abstracts;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Commons.Loggers.Implementations
{
    /// <summary>
    /// Central Logger
    /// </summary>
    public class CentralLogger
        : AbstractLogger
    {
        /// <summary>
        /// Constructor Method, to construct the Logger
        /// </summary>
        /// <param name="type">The Type of the class using this Logger</param>
        public CentralLogger(Type type)
        {
            this.loggingType = type;
            this.LogDirectory = "/centrals";
        }
    }
}