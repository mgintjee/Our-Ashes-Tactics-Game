using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Inters
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