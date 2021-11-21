using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Commons.Scores.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Engagements.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Maps.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Rosters.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Views.Interfaces
{
    /// <summary>
    /// Sortie View Construction Interface
    /// </summary>
    public interface ISortieViewConstruction : IMvcViewConstruction
    {
        IEngagementViewConstruction GetEngagementViewConstruction();

        ISortieMapViewConstruction GetSortieMapViewConstruction();

        IRosterViewConstruction GetRosterViewConstruction();

        IScoreConstruction GetScoreConstruction();
    }
}