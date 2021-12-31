using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public class MvcModelStateImpl
        : AbstractMvcModelState
    {
        public override IMvcModelState GetCopy()
        {
            return new MvcModelStateImpl()
                .SetMvcModelRequests(this.mvcModelRequests);
        }

        /// <inheritdoc/>
        public MvcModelStateImpl SetMvcModelRequests(ISet<IMvcModelRequest> mvcModelRequests)
        {
            this.mvcModelRequests = new HashSet<IMvcModelRequest>(mvcModelRequests);
            return this;
        }
    }
}