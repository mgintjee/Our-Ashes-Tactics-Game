using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Views.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Interfaces
{
    /// <summary>
    /// Combatant Stats Interface
    /// </summary>
    public interface ICombatantStats
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        CombatantID GetCombatantID();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantModelStats GetCombatantModelStats();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICombatantViewStats GetCombatantViewStats();
    }
}