using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Implementations.Abstracts;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Worlds.Commons.Loggers.Implementations
{
    /// <summary>
    /// World Logger
    /// </summary>
    public class WorldLogger
        : AbstractLogger
    {
        /// <summary>
        /// Constructor Method, to construct the Logger
        /// </summary>
        /// <param name="type">The Type of the class using this Logger</param>
        public WorldLogger(Type type)
        {
            this.loggingType = type;
            this.LogDirectory = "/worlds";
        }
    }
}