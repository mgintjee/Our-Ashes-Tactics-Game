using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IOrderReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<CombatantCallSign> GetCurrentCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<CombatantCallSign> GetUpcomingCallSigns();
    }
}