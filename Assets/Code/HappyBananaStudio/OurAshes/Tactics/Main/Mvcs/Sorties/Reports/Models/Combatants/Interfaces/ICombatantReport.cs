using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Loadouts.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatantReport : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantCallSign GetCombatantCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantID GetCombatantID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetCurrentAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ILoadoutReport GetLoadoutReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantAttributes GetMaximumAttributes();
    }
}