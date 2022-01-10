using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Models.States.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class QSortieMenuModelStateImpl
        : MvcModelStateImpl, IQSortieMenuModelState
    {
        private ISet<IPhalanxDetails> phalanxDetails = new HashSet<IPhalanxDetails>();
        private IFieldDetails fieldDetails;

        public override IMvcModelState GetCopy()
        {
            return new QSortieMenuModelStateImpl()
                .SetFieldDetails(this.fieldDetails)
                .SetPhalanxDetails(this.phalanxDetails)
                .SetMvcRequests(this.mvcModelRequests)
                .SetPrevMvcRequest(this.prevMvcRequest);
        }

        public QSortieMenuModelStateImpl SetPhalanxDetails(ISet<IPhalanxDetails> phalanxDetails)
        {
            this.phalanxDetails = new HashSet<IPhalanxDetails>(phalanxDetails);
            return this;
        }

        public QSortieMenuModelStateImpl SetFieldDetails(IFieldDetails fieldDetails)
        {
            this.fieldDetails = fieldDetails;
            return this;
        }

        IFieldDetails IQSortieMenuModelState.GetFieldDetails()
        {
            return this.fieldDetails;
        }

        ISet<IPhalanxDetails> IQSortieMenuModelState.GetPhalanxDetails()
        {
            return this.phalanxDetails;
        }
    }
}