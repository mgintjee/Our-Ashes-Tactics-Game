using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Orders.Interfaces
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