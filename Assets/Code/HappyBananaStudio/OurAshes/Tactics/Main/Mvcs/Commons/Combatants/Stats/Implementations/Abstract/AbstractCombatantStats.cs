using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Views.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations.Abstract
{
    /// <summary>
    /// Abstract Combatant Stats Implementation
    /// </summary>
    public class AbstractCombatantStats
        : ICombatantStats
    {
        // Todo
        protected string name;

        // Todo
        protected CombatantID combatantID;

        // Todo
        protected ICombatantModelStats modelStats;

        // Todo
        protected ICombatantViewStats viewStats;

        CombatantID ICombatantStats.GetCombatantID()
        {
            return combatantID;
        }

        ICombatantModelStats ICombatantStats.GetCombatantModelStats()
        {
            return modelStats;
        }

        ICombatantViewStats ICombatantStats.GetCombatantViewStats()
        {
            return viewStats;
        }

        string ICombatantStats.GetName()
        {
            return name;
        }
    }
}