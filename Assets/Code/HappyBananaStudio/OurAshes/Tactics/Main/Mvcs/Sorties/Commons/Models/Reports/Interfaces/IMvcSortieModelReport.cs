using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Orders.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Scores.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Interfaces
{
    /// <summary>
    /// Mvc Sortie Model Report Interface
    /// </summary>
    public interface IMvcSortieModelReport
        : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngagementReport GetEngagementReport();
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatReport GetCombatReport();
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IOrderReport GetOrderReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRosterReport GetRosterReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IScoreReport GetScoreReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMapReport GetMapReport();
    }
}