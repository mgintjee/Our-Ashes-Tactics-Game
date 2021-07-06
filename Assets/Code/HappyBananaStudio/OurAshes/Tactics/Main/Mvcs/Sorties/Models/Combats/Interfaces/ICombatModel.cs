using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Combats.Interfaces
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
            IRosterReport combatantRosterReport, IMapReport mapReport);
    }
}