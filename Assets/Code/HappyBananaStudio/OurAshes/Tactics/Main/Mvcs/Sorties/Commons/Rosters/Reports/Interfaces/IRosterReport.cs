using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<CombatantCallSign> GetActiveCombatantCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<CombatantCallSign> GetAllCombatantCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantCallSign"></param>
        /// <returns></returns>
        Optional<ICombatantReport> GetCombatantReport(CombatantCallSign combatantCallSign);
    }
}