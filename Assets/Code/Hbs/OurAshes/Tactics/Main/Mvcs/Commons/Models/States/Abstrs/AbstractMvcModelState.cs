using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs
{
    /// <summary>
    /// Todo Add a builder
    /// </summary>
    public abstract class AbstractMvcModelState
        : AbstractReport, IMvcModelState
    {
        protected ISet<IMvcModelRequest> mvcModelRequests = new HashSet<IMvcModelRequest>();

        public AbstractMvcModelState()
        {
        }

        public AbstractMvcModelState(IMvcModelState mvcModelState)
        {
            this.mvcModelRequests = new HashSet<IMvcModelRequest>(mvcModelState.GetMvcModelRequests());
        }

        ISet<IMvcModelRequest> IMvcModelState.GetMvcModelRequests()
        {
            return new HashSet<IMvcModelRequest>(this.mvcModelRequests);
        }
    }
}