using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Commons.Scores.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Rosters.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Inters
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