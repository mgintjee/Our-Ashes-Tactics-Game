using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Interfaces
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
        /// <param name="controllerRequest">    </param>
        /// <param name="combatantRosterReport"></param>
        /// <param name="mapReport">            </param>
        void Process(ISortieRequest controllerRequest,
            IRosterModelReport combatantRosterReport, ISortieMapReport mapReport);
    }
}