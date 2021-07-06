using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations.Alphas;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations.Bravos;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Implementations.Charlies;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Interfaces;
using System.Collections.Generic;

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
        public static Optional<ICombatantStats> GetStats(CombatantID combatantID)
        {
            foreach (ICombatantStats stats in CombatantStats)
            {
                if (combatantID == stats.GetCombatantID())
                {
                    return Optional<ICombatantStats>.Of(stats);
                }
            }
            return Optional<ICombatantStats>.Empty();
        }
    }
}