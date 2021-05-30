using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Commons.Loggers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Implementations;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Implementations
{
    /// <summary>
    /// Central Mvc Frame Implementation
    /// </summary>
    public class CentralMvcFrame
        : ICentralMvcFrame
    {
        // Todo
        private static readonly ILogger _centralLogger = new CentralLogger(new StackFrame().GetMethod().DeclaringType);

        private readonly IDictionary<MvcType, IMvcFrame> mvcTypeFrames = new Dictionary<MvcType, IMvcFrame>()
        {
            { MvcType.Sortie, null },
            { MvcType.World, null },
        };

        // Todo
        private bool isComplete = false;

        /// <summary>
        /// Todo
        /// </summary>
        public CentralMvcFrame()
        {
            _centralLogger.Info("Constructing {}", this.GetType());
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if (this.mvcTypeFrames[MvcType.Sortie] == null)
            {
                // Todo: Build the Frame Construction
                this.mvcTypeFrames[MvcType.Sortie] = new MvcSortieFrame(null);
            }
        }

        /// <inheritdoc/>
        bool IMvcFrame.IsComplete()
        {
            return this.isComplete;
        }
    }
}