using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Rosters.Combatants.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ICombatantModelConstruction
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
        ILoadoutReport GetLoadoutReport();
    }
}