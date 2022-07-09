using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs
{
    /// <summary>
    /// Todo Add a builder
    /// </summary>
    public abstract class AbstractMvcModelState
        : IMvcModelState
    {
        protected IList<IMvcRequest> mvcModelRequests = new List<IMvcRequest>();

        protected IMvcRequest prevMvcRequest;

        public abstract IMvcModelState GetCopy();

        Optional<IMvcRequest> IMvcModelState.GetPrevMvcRequest()
        {
            return Optional<IMvcRequest>.Of(this.prevMvcRequest);
        }
    }
}