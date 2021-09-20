﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Implementations
{
    /// <summary>
    /// Splash Model Implementation
    /// </summary>
    public class SplashModel : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashModel(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        protected override void BuildInitialRequests()
        {
            // Todo
        }

        /// <inheritdoc/>
        protected override void ProcessConfirmedRequest(IMvcRequest mvcRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}