using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Managers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Menus.Homes.Frames.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Controls.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Frames.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Models.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Views.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Splashes.Frames.Impls;
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
        private readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Manager)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<MvcType, IMvcFrame> mvcTypeFrames = new Dictionary<MvcType, IMvcFrame>();

        // Todo
        private readonly IUnityScript unityScript;

        // Todo
        private MvcType activeMvcType = MvcType.None;

        // Todo
        private List<IMvcFrameResult> mvcFrameResults = new List<IMvcFrameResult>();

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
                logger.Info("Creating initial {}...", typeof(IMvcFrame));
                IMvcFrameConstruction mvcFrameConstruction = this.BuildLoadingFrameConstruction();
                this.mvcTypeFrames[mvcFrameConstruction.GetMvcType()] =
                    this.BuildMvcFrame(this.BuildLoadingFrameConstruction(), null);
            }
            if (!this.mvcTypeFrames.ContainsKey(this.activeMvcType))
            {
                // Should never be here except for errors
                logger.Error("No {} associated to {}", typeof(IMvcFrame), this.activeMvcType);
                return;
            }
            IMvcFrame mvcFrame = this.mvcTypeFrames[this.activeMvcType];
            // Check if the MvcFrame is now complete
            if (!mvcFrame.IsProcessing())
            {
                logger.Info("Frame: {} is complete.", this.activeMvcType);
                IMvcFrameResult mvcFrameResult = this.mvcTypeFrames[this.activeMvcType].GetMvcFrameResult();
                // Cache the MvcFrameResult
                this.mvcFrameResults.Add(mvcFrameResult);
                if (mvcFrameResult.GetNextMvcFrameConstruction() == null)
                {
                    // Todo: End the app or something
                    unityScript.Destroy();
                    return;
                }
                this.mvcTypeFrames[this.activeMvcType].Destroy();
                this.mvcTypeFrames[this.activeMvcType] = null;
                if (this.activeMvcType != MvcType.ScreenLoading)
                {
                    IMvcFrameConstruction loadingFrameConstruction = this.BuildLoadingFrameConstruction();
                    this.mvcTypeFrames[loadingFrameConstruction.GetMvcType()] =
                        this.BuildMvcFrame(loadingFrameConstruction, mvcFrameResult);
                }
                else
                {
                    this.mvcTypeFrames[mvcFrameResult.GetNextMvcFrameConstruction().GetMvcType()] =
                        this.BuildMvcFrame(mvcFrameResult.GetNextMvcFrameConstruction(), mvcFrameResult);
                }
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
        /// <param name="nextMvcFrameConstruction"></param>
        /// <returns></returns>
        private IMvcFrame BuildMvcFrame(IMvcFrameConstruction nextMvcFrameConstruction, IMvcFrameResult currMvcFrameResult)
        {
            // Set the active MvcType
            this.activeMvcType = nextMvcFrameConstruction.GetMvcType();
            IMvcFrame mvcFrame;
            // Switch-case on the new active MvcType
            switch (this.activeMvcType)
            {
                case MvcType.ScreenSplash:
                    mvcFrame = new SplashFrameImpl(nextMvcFrameConstruction, currMvcFrameResult);
                    break;

                case MvcType.MenuHome:
                    mvcFrame = new HomeFrameImpl(nextMvcFrameConstruction, currMvcFrameResult);
                    break;

                case MvcType.ScreenLoading:
                    mvcFrame = new LoadingFrameImpl(nextMvcFrameConstruction, currMvcFrameResult);
                    break;

                default:
                    mvcFrame = null;
                    break;
            }
            if (mvcFrame != null)
            {
                logger.Info("Transitioning to {}", mvcFrame.GetType());
            }
            else
            {
                logger.Info("Unsupported {}:{}. Unable to build {}.",
                    typeof(MvcType), this.activeMvcType, typeof(IMvcFrame));
            }
            return mvcFrame;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IMvcFrameConstruction BuildLoadingFrameConstruction()
        {
            return MvcFrameConstruction.Builder.Get()
                .SetSimulationType(SimsType.Interactive)
                .SetUnityScript(unityScript)
                .SetMvcType(MvcType.ScreenLoading)
                .SetMvcControlConstruction(LoadingControlConstructionImpl.Builder.Get().Build())
                .SetMvcModelConstruction(LoadingModelConstruction.Builder.Get().Build())
                .SetMvcViewConstruction(LoadingViewConstruction.Builder.Get().Build())
                .SetRandom(RandomManager.GetRandom(MvcType.ScreenLoading))
                .Build();
        }
    }
}