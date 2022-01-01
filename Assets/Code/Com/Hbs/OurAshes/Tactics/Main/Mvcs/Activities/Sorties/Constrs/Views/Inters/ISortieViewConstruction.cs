using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Commons.Scores.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Maps.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Rosters.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constrs.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Views.Inters
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