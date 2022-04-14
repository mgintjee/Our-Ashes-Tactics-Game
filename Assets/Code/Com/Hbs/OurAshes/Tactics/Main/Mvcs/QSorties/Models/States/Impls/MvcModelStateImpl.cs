using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;
using System.Collections.Generic;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcModelStateImpl
        : DefaultMvcModelStateImpl, IMvcModelState
    {
        private ISet<IFactionDetails> factionDetails = new HashSet<IFactionDetails>();
        private IFieldDetails fieldDetails;

        public override Commons.Models.States.Inters.IMvcModelState GetCopy()
        {
            return new MvcModelStateImpl()
                .SetFieldDetails(this.fieldDetails)
                .SetFactionDetails(this.factionDetails)
                .SetMvcRequests(this.mvcModelRequests)
                .SetPrevMvcRequest(this.prevMvcRequest);
        }

        public MvcModelStateImpl SetFactionDetails(ISet<IFactionDetails> factionDetails)
        {
            this.factionDetails = new HashSet<IFactionDetails>(factionDetails);
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

        ISet<IFactionDetails> IMvcModelState.GetFactionDetails()
        {
            return this.factionDetails;
        }
    }
}