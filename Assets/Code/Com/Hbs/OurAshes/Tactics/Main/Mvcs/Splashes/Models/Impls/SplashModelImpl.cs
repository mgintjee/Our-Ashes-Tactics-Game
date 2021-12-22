using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Requests.Impls;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Models.Impls
{
    /// <summary>
    /// Mvc Model Splash Impl
    /// </summary>
    public class SplashModelImpl
        : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SplashModelImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        public override IMvcModelState Process(IMvcModelRequest mvcModelRequest)
        {
            if (mvcModelRequest != null)
            {
                _logger.Info("Processing {}...", mvcModelRequest);
                return this.ProcessMvcModelRequest(mvcModelRequest);
            }
            else
            {
                return this.ProcessInitialMvcModelRequest();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private IMvcModelState ProcessInitialMvcModelRequest()
        {
            ISet<IMvcModelRequest> mvcModelRequests = new HashSet<IMvcModelRequest>
                { new SplashModelRequestImpl() };
            ((MvcModelStateImpl)this.mvcModelState).SetMvcModelRequests(mvcModelRequests);
            return this.mvcModelState;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelRequest"></param>
        /// <returns></returns>
        private IMvcModelState ProcessMvcModelRequest(IMvcModelRequest mvcModelRequest)
        {
            _isProcessing = false;
            return this.mvcModelState;
        }
    }
}