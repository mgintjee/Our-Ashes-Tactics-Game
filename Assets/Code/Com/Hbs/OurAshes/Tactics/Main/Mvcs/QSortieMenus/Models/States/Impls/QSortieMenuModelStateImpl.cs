using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Models.States.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class QSortieMenuModelStateImpl
        : AbstractMvcModelState
    {
        public override IMvcModelState GetCopy()
        {
            return new MvcModelStateImpl()
                .SetMvcRequests(this.mvcModelRequests)
                .SetPrevMvcRequest(this.prevMvcRequest);
        }

        public QSortieMenuModelStateImpl SetMvcRequests(ISet<IMvcRequest> mvcModelRequests)
        {
            this.mvcModelRequests = new HashSet<IMvcRequest>(mvcModelRequests);
            return this;
        }

        public QSortieMenuModelStateImpl SetPrevMvcRequest(IMvcRequest prevMvcRequest)
        {
            this.prevMvcRequest = prevMvcRequest;
            return this;
        }
    }
}