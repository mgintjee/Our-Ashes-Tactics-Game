using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CombatantCountConstants
    {
        private static readonly int SMALL_MAX_COMBATANT_COUNT = 6;
        private static readonly int SMALL_COMBATANT_FACTOR = 3;
        private static readonly int MEDIUM_MAX_COMBATANT_COUNT = 12;
        private static readonly int MEDIUM_COMBATANT_FACTOR = 4;
        private static readonly int LARGE_MAX_COMBATANT_COUNT = 18;
        private static readonly int LARGE_COMBATANT_FACTOR = 5;

        public static int GetMaxCombatantCounts(FieldSize fieldSize, int phalanxCount)
        {
            switch (fieldSize)
            {
                case FieldSize.Small:
                    return GetMaxCombatantCounts(phalanxCount, SMALL_COMBATANT_FACTOR, SMALL_MAX_COMBATANT_COUNT);

                case FieldSize.Medium:
                    return GetMaxCombatantCounts(phalanxCount, MEDIUM_COMBATANT_FACTOR, MEDIUM_MAX_COMBATANT_COUNT);

                case FieldSize.Large:
                    return GetMaxCombatantCounts(phalanxCount, LARGE_COMBATANT_FACTOR, LARGE_MAX_COMBATANT_COUNT);

                case FieldSize.None:
                default:
                    return 0;
            }
        }

        private static int GetMaxCombatantCounts(int phalanxCount, int combatantFactor, int maxCombatantCount)
        {
            return Math.Max(phalanxCount * combatantFactor, maxCombatantCount);
        }
    }
}