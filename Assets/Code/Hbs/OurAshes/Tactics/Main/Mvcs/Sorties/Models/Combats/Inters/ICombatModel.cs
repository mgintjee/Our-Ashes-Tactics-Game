using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatReport GetReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="ControlRequest">       </param>
        /// <param name="combatantRosterReport"></param>
        /// <param name="mapReport">            </param>
        void Process(IMvcControlSortieRequest ControlRequest,
            IRosterModelReport combatantRosterReport, ISortieMapReport mapReport);
    }
}