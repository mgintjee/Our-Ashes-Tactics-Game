using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class DefaultMvcModelStateImpl
        : AbstractMvcModelState
    {
        public override IMvcModelState GetCopy()
        {
            return new DefaultMvcModelStateImpl()
                .SetPrevMvcRequest(this.prevMvcRequest);
        }

        public DefaultMvcModelStateImpl SetPrevMvcRequest(IMvcRequest prevMvcRequest)
        {
            this.prevMvcRequest = prevMvcRequest;
            return this;
        }
    }
}