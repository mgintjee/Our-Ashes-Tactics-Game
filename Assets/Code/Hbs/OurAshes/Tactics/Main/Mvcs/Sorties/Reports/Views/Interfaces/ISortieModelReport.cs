using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Engagements.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Interfaces
{
    /// <summary>
    /// Mvc Sortie Model Report Interface
    /// </summary>
    public interface ISortieModelReport : IReport
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
        IRosterModelReport GetRosterReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IScoreReport GetScoreReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieMapReport GetMapReport();
    }
}