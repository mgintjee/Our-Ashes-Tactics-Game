using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Phalanxes.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Interfaces
{
    /// <summary>
    /// Engagement View Construction Interface
    /// </summary>
    public interface IEngagementViewConstruction
    {
        EngagementType GetEngagementType();

        ISet<IPhalanxViewConstruction> GetPhalanxViewConstructions();
    }
}