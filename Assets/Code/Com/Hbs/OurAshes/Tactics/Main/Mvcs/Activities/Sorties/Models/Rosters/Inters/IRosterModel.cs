using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Combats.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Rosters.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRosterModelReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="ModelRequest"></param>
        /// <returns></returns>
        void Process(IMvcControlSortieRequest ModelRequest, ICombatReport combatReport);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewPhase();
    }
}