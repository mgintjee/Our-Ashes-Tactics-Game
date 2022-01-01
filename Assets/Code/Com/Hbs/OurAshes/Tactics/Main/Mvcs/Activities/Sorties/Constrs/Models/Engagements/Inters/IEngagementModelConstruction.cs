using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Engagements.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Engagements.Inters
{
    /// <summary>
    /// Engagement Model Construction Interface
    /// </summary>
    public interface IEngagementModelConstruction
    {
        EngagementType GetEngagementType();

        ISet<IPhalanxModelConstruction> GetPhalanxConstrs();
    }
}