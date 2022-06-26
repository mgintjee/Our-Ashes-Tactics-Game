﻿using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Impls
{
    /// <summary>
    /// Default Mvc Model Implementation
    /// </summary>
    public class DefaultMvcModelImpl
        : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public DefaultMvcModelImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelRequest"></param>
        /// <returns></returns>
        protected override IMvcModelState ProcessMvcModelRequest(IMvcRequest mvcModelRequest)
        {
            isProcessing = false;
            return this.mvcModelState;
        }
    }
}