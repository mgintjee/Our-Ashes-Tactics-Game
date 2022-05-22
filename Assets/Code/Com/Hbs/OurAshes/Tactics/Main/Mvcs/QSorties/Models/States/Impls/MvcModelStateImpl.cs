using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
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
        private IList<IFactionDetails> factionDetails = new List<IFactionDetails>();
        private IFieldDetails fieldDetails;

        public override Commons.Models.States.Inters.IMvcModelState GetCopy()
        {
            return new MvcModelStateImpl()
                .SetFieldDetails(this.fieldDetails)
                .SetFactionDetails(this.factionDetails)
                .SetPrevMvcRequest(this.prevMvcRequest);
        }

        public MvcModelStateImpl SetFactionDetails(IList<IFactionDetails> factionDetails)
        {
            this.factionDetails = new List<IFactionDetails>(factionDetails);
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

        IList<IFactionDetails> IMvcModelState.GetFactionDetails()
        {
            return this.factionDetails;
        }
    }
}