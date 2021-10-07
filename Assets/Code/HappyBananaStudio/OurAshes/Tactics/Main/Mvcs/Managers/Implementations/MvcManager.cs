using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Managers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Managers.Implementations
{
    /// <summary>
    /// Mvc Manager Implementationw
    /// </summary>
    public class MvcManager : IMvcManager
    {
        // Todo
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Manager, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<MvcType, IMvcFrame> mvcTypeFrames = new Dictionary<MvcType, IMvcFrame>();

        // Todo
        private readonly int seed = 22;

        // Todo
        private MvcType activeMvcType = MvcType.None;

        // Todo
        private readonly IUnityScript unityScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="unityScript"></param>
        public MvcManager(IUnityScript unityScript)
        {
            this.unityScript = unityScript;
        }

        void IMvcManager.Continue()
        {
            // Check if the activeMvcType has been set
            if (this.activeMvcType == MvcType.None)
            {
                this.mvcTypeFrames[MvcType.Splash] = this.BuildMvcFrame(this.BuildInitialMvcFrameConstruction(),
                    null);
            }
            if (!this.mvcTypeFrames.ContainsKey(this.activeMvcType))
            {
                // Should never be here except for errors
                _logger.Error("No {} associated to {}", typeof(IMvcFrame), this.activeMvcType);
                return;
            }
            IMvcFrame mvcFrame = this.mvcTypeFrames[this.activeMvcType];
            // Check if the MvcFrame is now complete
            if (mvcFrame.IsComplete())
            {
                _logger.Info("{} is complete.", this.activeMvcType);
                IMvcFrameConstruction mvcFrameConstruction = mvcFrame.GetUpcomingMvcFrameConstruction();
                if (mvcFrameConstruction == null)
                {
                    // Todo: End the app or something
                    unityScript.Destroy();
                    return;
                }
                this.mvcTypeFrames[this.activeMvcType] = null;
                this.mvcTypeFrames[mvcFrameConstruction.GetMvcType()] = this.BuildMvcFrame(mvcFrameConstruction,
                    mvcFrame.GetCurrentMvcFrameConstruction());
            }
            else
            {
                // Continue the active MvcFrame
                mvcFrame.Continue();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        /// <returns></returns>
        private IMvcFrame BuildMvcFrame(IMvcFrameConstruction mvcFrameConstruction,
            IMvcFrameConstruction currentMvcFrameConstruction)
        {
            // Set the active MvcType
            this.activeMvcType = mvcFrameConstruction.GetMvcType();
            _logger.Info("Building {} {}", this.activeMvcType, typeof(IMvcFrame));
            // Switch-case on the new active MvcType
            switch (this.activeMvcType)
            {
                case MvcType.Splash:
                    return new SplashFrame(mvcFrameConstruction, currentMvcFrameConstruction);

                default:
                    return null;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IMvcFrameConstruction BuildInitialMvcFrameConstruction()
        {
            return MvcFrameConstruction.Builder.Get()
                .SetSimulationType(SimulationType.Interactive)
                .SetUnityScript(unityScript)
                .SetMvcType(MvcType.Splash)
                .SetRandom(new Random(seed))
                .Build();
        }
    }
}