using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Orders.Reports.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IOrderReport
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