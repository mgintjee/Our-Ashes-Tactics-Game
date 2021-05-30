using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Views.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Managers
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CombatantStatsManager
    {
        // Todo
        private static readonly ISet<ICombatantStats> CombatantStats =
            new HashSet<ICombatantStats>()
            {
                new AlphaAlphaCombatantStats(),
                new BravoAlphaCombatantStats(),
                new CharlieAlphaCombatantStats()
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantID"></param>
        /// <returns></returns>
        private static ICombatantStats GetStats(CombatantID combatantID)
        {
            foreach (ICombatantStats stats in CombatantStats)
            {
                if (combatantID == stats.GetCombatantID())
                {
                    return stats;
                }
            }

            throw ExceptionUtil.Arguments.Build("Unable to {}. {} is not supported.",
                new StackFrame().GetMethod().Name, combatantID);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Models
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantID"></param>
            /// <returns></returns>
            public static ICombatantModelStats GetStats(CombatantID combatantID)
            {
                return CombatantStatsManager.GetStats(combatantID).GetCombatantModelStats();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Views
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="combatantID"></param>
            /// <returns></returns>
            public static ICombatantViewStats GetStats(CombatantID combatantID)
            {
                return CombatantStatsManager.GetStats(combatantID).GetCombatantViewStats();
            }
        }
    }
}