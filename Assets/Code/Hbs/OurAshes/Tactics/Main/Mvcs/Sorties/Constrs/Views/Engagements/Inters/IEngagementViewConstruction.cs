using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Engagements.Phalanxes.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Engagements.Inters
{
    /// <summary>
    /// Engagement View Construction Interface
    /// </summary>
    public interface IEngagementViewConstruction
    {
        EngagementType GetEngagementType();

        ISet<IPhalanxViewConstruction> GetPhalanxViewConstrs();
    }
}