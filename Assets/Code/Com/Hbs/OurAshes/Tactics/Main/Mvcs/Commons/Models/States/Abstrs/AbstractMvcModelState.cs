using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs
{
    /// <summary>
    /// Todo Add a builder
    /// </summary>
    public abstract class AbstractMvcModelState
        : IMvcModelState
    {
        protected ISet<IMvcModelRequest> mvcModelRequests = new HashSet<IMvcModelRequest>();

        public abstract IMvcModelState GetCopy();

        ISet<IMvcModelRequest> IMvcModelState.GetMvcModelRequests()
        {
            return new HashSet<IMvcModelRequest>(this.mvcModelRequests);
        }
    }
}