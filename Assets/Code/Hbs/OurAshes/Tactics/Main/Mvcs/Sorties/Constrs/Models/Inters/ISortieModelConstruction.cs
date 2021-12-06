using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Commons.Scores.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Engagements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Rosters.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Inters
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