using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Commons.Scores.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Engagements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Rosters.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Interfaces
{
    /// <summary>
    /// Sortie Model Construction Interface
    /// </summary>
    public interface ISortieModelConstruction : IMvcModelConstruction
    {
        IEngagementModelConstruction GetEngagementModelConstruction();

        ISortieMapModelConstruction GetSortieMapModelConstruction();

        IRosterModelConstruction GetRosterModelConstruction();

        IScoreConstruction GetScoreConstruction();
    }
}