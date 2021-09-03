using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Unity.Scripts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Frames.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Models.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Views.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Managers.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Managers.Implementations
{
    /// <summary>
    /// Mvc Manager Implementationw
    /// </summary>
    public class MvcManager : IMvcManager
    {
        // Todo
        private readonly IDictionary<MvcType, IMvcFrame> mvcTypeFrames = new Dictionary<MvcType, IMvcFrame>();

        // Todo
        private readonly int seed = 22;

        // Todo
        private MvcType activeMvcType = MvcType.None;

        // Todo
        private IUnityScript unityScript;

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
                this.mvcTypeFrames[MvcType.Home] = this.BuildMvcFrame(this.buildInitialHomeConstruction());
            }

            IMvcFrame mvcFrame = this.mvcTypeFrames[this.activeMvcType];
            // Check if the MvcFrame is now complete
            if (!mvcFrame.IsComplete())
            {
                IMvcFrameConstruction mvcFrameConstruction = mvcFrame.GetReturnMvcFrameConstruction();
                if (mvcFrameConstruction == null)
                {
                    // Todo: End this
                    unityScript.Destroy();
                    return;
                }
                this.mvcTypeFrames[this.activeMvcType] = null;
                this.mvcTypeFrames[mvcFrameConstruction.GetMvcType()] = this.BuildMvcFrame(mvcFrameConstruction);
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
        private IMvcFrame BuildMvcFrame(IMvcFrameConstruction mvcFrameConstruction)
        {
            // Set the active MvcType
            this.activeMvcType = mvcFrameConstruction.GetMvcType();
            // Switch-case on the new active MvcType
            switch (this.activeMvcType)
            {
                case MvcType.Home:
                    return new HomeFrame(mvcFrameConstruction);

                default:
                    return null;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IMvcFrameConstruction buildInitialHomeConstruction()
        {
            return MvcFrameConstruction.Builder.Get()
                .SetMvcControllerConstruction(HomeControllerConstruction.Builder.GetBuilder().Build())
                .SetMvcViewConstruction(HomeViewConstruction.Builder.GetBuilder().Build())
                .SetMvcModelConstruction(HomeModelConstruction.Builder.GetBuilder().Build())
                .SetSimulationType(SimulationType.Interactive)
                .SetUnityScript(unityScript)
                .SetMvcType(MvcType.Home)
                .SetRandom(new Random(seed))
                .Build();
        }
    }
}