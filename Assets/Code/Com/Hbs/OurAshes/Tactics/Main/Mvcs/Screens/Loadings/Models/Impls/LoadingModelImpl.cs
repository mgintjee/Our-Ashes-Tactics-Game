using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Screens.Loadings.Models.Impls
{
    /// <summary>
    /// Loading Model Impl
    /// </summary>
    public class LoadingModelImpl
        : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public LoadingModelImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
            _isProcessing = false;
            // Todo
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected override IMvcModelState ProcessInitialMvcModelRequest()
        {
            ((MvcModelStateImpl)this.mvcModelState).SetMvcModelRequests(
                new HashSet<IMvcModelRequest> { new MvcModelRequestImpl() });
            return this.mvcModelState;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelRequest"></param>
        /// <returns></returns>
        protected override IMvcModelState ProcessMvcModelRequest(IMvcModelRequest mvcModelRequest)
        {
            _isProcessing = false;
            return this.mvcModelState;
        }
    }
}