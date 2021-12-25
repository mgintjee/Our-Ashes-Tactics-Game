using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Requests.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Requests.Types;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Homes.Models.Impls
{
    /// <summary>
    /// Home Model Impl
    /// </summary>
    public class HomeModelImpl
        : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeModelImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        protected override IMvcModelState ProcessInitialMvcModelRequest()
        {
            ((MvcModelStateImpl)this.mvcModelState)
                .SetMvcModelRequests(new HashSet<IMvcModelRequest>
                    {
                        new HomeRequestImpl().SetHomeRequestType(HomeRequestType.Exit),
                        new HomeRequestImpl().SetHomeRequestType(HomeRequestType.QSortie)
                    });
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