using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Engagements.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Maps.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Scores.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Views.Inters
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