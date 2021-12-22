using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Frames.Impls;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Impls
{
    /// <summary>
    /// Mvc Manager Implw
    /// </summary>
    public class MvcManager : IMvcManager
    {
        // Todo
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Manager)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<MvcType, IMvcFrame> mvcTypeFrames = new Dictionary<MvcType, IMvcFrame>();

        // Todo
        private readonly int seed = 22;

        // Todo
        private readonly IUnityScript unityScript;

        // Todo
        private MvcType activeMvcType = MvcType.None;

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
                _logger.Info("Creating initial {}...", typeof(IMvcFrame));
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
            if (!mvcFrame.IsProcessing())
            {
                _logger.Info("Frame: {} is complete.", this.activeMvcType);
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
            IMvcFrame mvcFrame;
            // Switch-case on the new active MvcType
            switch (this.activeMvcType)
            {
                case MvcType.Splash:
                    mvcFrame = new SplashFrameImpl(mvcFrameConstruction, currentMvcFrameConstruction);
                    break;

                case MvcType.Home:
                    mvcFrame = new HomeFrameImpl(mvcFrameConstruction, currentMvcFrameConstruction);
                    break;

                default:
                    mvcFrame = null;
                    break;
            }
            if (mvcFrame != null)
            {
                _logger.Info("Transitioning to {}", mvcFrame.GetType());
            }
            else
            {
                _logger.Info("Unsupported {}:{}. Unable to build {}.",
                    typeof(MvcType), this.activeMvcType, typeof(IMvcFrame));
            }
            return mvcFrame;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IMvcFrameConstruction BuildInitialMvcFrameConstruction()
        {
            return MvcFrameConstruction.Builder.Get()
                .SetSimulationType(SimsType.Interactive)
                .SetUnityScript(unityScript)
                .SetMvcType(MvcType.Splash)
                .SetRandom(RandomManager.GetRandom(MvcType.Splash))
                .Build();
        }
    }
}