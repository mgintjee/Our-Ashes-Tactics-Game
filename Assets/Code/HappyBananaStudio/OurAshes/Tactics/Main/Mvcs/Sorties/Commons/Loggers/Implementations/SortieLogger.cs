using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Implementations.Abstracts;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loggers.Implementations
{
    /// <summary>
    /// Sortie Logger
    /// </summary>
    public class SortieLogger
        : AbstractLogger
    {
        /// <summary>
        /// Constructor Method, to construct the Logger
        /// </summary>
        /// <param name="type">The Type of the class using this Logger</param>
        public SortieLogger(Type type)
        {
            this.loggingType = type;
            this.LogDirectory = "/sorties";
        }
    }
}