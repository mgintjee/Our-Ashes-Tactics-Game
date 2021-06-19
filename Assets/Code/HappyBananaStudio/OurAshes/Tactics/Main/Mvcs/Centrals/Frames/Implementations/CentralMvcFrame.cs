using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Scripts.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Frames.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties;
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
        // Provides logging capability to the CENTRAL logs
        private static readonly ILogger _centralLogger = LoggerManager.GetCentralLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<MvcType, IMvcFrame> mvcTypeFrames = new Dictionary<MvcType, IMvcFrame>()
        {
            { MvcType.Sortie, null },
            { MvcType.World, null },
        };

        // Todo
        private bool isComplete = false;

        private ICentralMvcFrameScript centralMvcFrameScript;

        /// <summary>
        /// Todo
        /// </summary>
        public CentralMvcFrame(IUnityScript unityScript)
        {
            RandomManager.GetCentralRandom();
            this.centralMvcFrameScript = new CentralMvcFrameScript.Builder()
                .SetUnityScript(unityScript)
                .Build();
            _centralLogger.Info("Constructing {}", this.GetType());
        }

        /// <inheritdoc/>
        void IMvcFrame.Continue()
        {
            if (this.mvcTypeFrames[MvcType.Sortie] == null)
            {
                // Todo: Build the Frame Construction
                this.mvcTypeFrames[MvcType.Sortie] = new MvcSortieFrame(
                    RandomSortieConstructions.Generate(RandomManager.GetCentralRandom(),
                    SimulationType.BlackBox, centralMvcFrameScript));
            }
            else
            {
                this.mvcTypeFrames[MvcType.Sortie].Continue();
            }
        }

        /// <inheritdoc/>
        bool IMvcFrame.IsComplete()
        {
            return this.isComplete;
        }
    }
}