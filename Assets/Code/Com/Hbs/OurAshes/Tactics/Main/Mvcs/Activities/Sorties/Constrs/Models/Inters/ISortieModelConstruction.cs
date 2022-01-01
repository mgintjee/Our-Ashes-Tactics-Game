using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Commons.Scores.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Maps.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constrs.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Inters
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