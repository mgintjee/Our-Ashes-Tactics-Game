using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcModelStateImpl
        : DefaultMvcModelStateImpl, IMvcModelState
    {
        private ISet<IPhalanxDetails> phalanxDetails = new HashSet<IPhalanxDetails>();
        private IFieldDetails fieldDetails;

        public override Commons.Models.States.Inters.IMvcModelState GetCopy()
        {
            return new MvcModelStateImpl()
                .SetFieldDetails(this.fieldDetails)
                .SetPhalanxDetails(this.phalanxDetails)
                .SetMvcRequests(this.mvcModelRequests)
                .SetPrevMvcRequest(this.prevMvcRequest);
        }

        public MvcModelStateImpl SetPhalanxDetails(ISet<IPhalanxDetails> phalanxDetails)
        {
            this.phalanxDetails = new HashSet<IPhalanxDetails>(phalanxDetails);
            return this;
        }

        public MvcModelStateImpl SetFieldDetails(IFieldDetails fieldDetails)
        {
            this.fieldDetails = fieldDetails;
            return this;
        }

        IFieldDetails IMvcModelState.GetFieldDetails()
        {
            return this.fieldDetails;
        }

        ISet<IPhalanxDetails> IMvcModelState.GetPhalanxDetails()
        {
            return this.phalanxDetails;
        }
    }
}