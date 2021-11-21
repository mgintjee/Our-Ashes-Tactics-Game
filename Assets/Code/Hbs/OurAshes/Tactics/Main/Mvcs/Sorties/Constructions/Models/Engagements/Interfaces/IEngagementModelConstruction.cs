using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Engagements.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Engagements.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Engagements.Interfaces
{
    /// <summary>
    /// Engagement Model Construction Interface
    /// </summary>
    public interface IEngagementModelConstruction
    {
        EngagementType GetEngagementType();

        ISet<IPhalanxModelConstruction> GetPhalanxConstructions();
    }
}