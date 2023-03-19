using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Randoms;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Results.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Homes.Menus.Frames.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Loadings.Screens.Frames.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Managers.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Splashes.Screens.Frames.Impls;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Managers.Impls
{
    /// <summary>
    /// Mvc Manager Implw
    /// </summary>
    public class MvcManagerImpl
        : IMvcManager
    {
        // Provides logging capability
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
        public MvcManagerImpl(IUnityScript unityScript)
        {
            this.unityScript = unityScript;
        }

        void IMvcManager.Continue()
        {
            // Check if the activeMvcType has been set
            if (this.activeMvcType == MvcType.None)
            {
                logger.Info("Creating initial {}...", typeof(IMvcFrame).Name);
                IMvcFrameConstruction mvcFrameConstruction = this.BuildLoadingFrameConstruction();
                this.mvcTypeFrames[mvcFrameConstruction.GetMvcType()] =
                    this.BuildMvcFrame(this.BuildLoadingFrameConstruction(), null);
            }
            if (!this.mvcTypeFrames.ContainsKey(this.activeMvcType))
            {
                // Should never be here except for errors
                logger.Error("No {} associated to {}", typeof(IMvcFrame).Name, this.activeMvcType);
                return;
            }
            IMvcFrame mvcFrame = this.mvcTypeFrames[this.activeMvcType];
            if (mvcFrame == null)
            {
                // Should never be here except for errors
                logger.Error("No {} associated to active {}:{}",
                    typeof(IMvcFrame).Name, typeof(MvcType).Name, this.activeMvcType);
                return;
            }
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
                if (this.activeMvcType != MvcType.LoadingScreen)
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
            IMvcFrame mvcFrame;
            // Switch-case on the new active MvcType
            switch (nextMvcFrameConstruction.GetMvcType())
            {
                case MvcType.SplashScreen:
                    mvcFrame = new SplashScreenFrameImpl(nextMvcFrameConstruction, currMvcFrameResult);
                    break;

                case MvcType.HomeMenu:
                    mvcFrame = new HomeMenuFrameImpl(nextMvcFrameConstruction, currMvcFrameResult);
                    break;

                case MvcType.LoadingScreen:
                    mvcFrame = new LoadingScreenFrameImpl(nextMvcFrameConstruction, currMvcFrameResult);
                    break;

                case MvcType.QSortieMenu:
                    mvcFrame = new QSortieMenuFrameImpl(nextMvcFrameConstruction, currMvcFrameResult);
                    break;

                case MvcType.Sortie:
                    mvcFrame = new SortieGameFrameImpl(nextMvcFrameConstruction, currMvcFrameResult);
                    break;

                default:
                    mvcFrame = null;
                    break;
            }
            if (mvcFrame != null)
            {
                logger.Info("Transitioning {}s : {} => {}", typeof(MvcType).Name,
                    this.activeMvcType, nextMvcFrameConstruction.GetMvcType());
                // Set the active MvcType
                this.activeMvcType = nextMvcFrameConstruction.GetMvcType();
            }
            else
            {
                logger.Info("Unsupported {}. Unable to build {}.",
                    nextMvcFrameConstruction.GetMvcType(), typeof(IMvcFrame).Name);
            }
            return mvcFrame;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IMvcFrameConstruction BuildLoadingFrameConstruction()
        {
            MvcType mvcType = MvcType.LoadingScreen;
            Random random = RandomManager.GetRandom(mvcType);
            return new MvcFrameConstructionImpl(mvcType, SimType.Interactive, unityScript, random);
        }
    }
}