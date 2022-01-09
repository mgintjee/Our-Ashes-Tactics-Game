using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
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
        protected ISet<IMvcRequest> mvcModelRequests = new HashSet<IMvcRequest>();

        protected IMvcRequest prevMvcRequest;

        public abstract IMvcModelState GetCopy();

        ISet<IMvcRequest> IMvcModelState.GetMvcRequests()
        {
            return new HashSet<IMvcRequest>(this.mvcModelRequests);
        }

        Optional<IMvcRequest> IMvcModelState.GetPrevMvcRequest()
        {
            return Optional<IMvcRequest>.Of(this.prevMvcRequest);
        }
    }
}