using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnitCountConstants
    {
        private static readonly int SMALL_MAX_COMBATANT_COUNT = 6;
        private static readonly int SMALL_COMBATANT_FACTOR = 3;
        private static readonly int MEDIUM_MAX_COMBATANT_COUNT = 12;
        private static readonly int MEDIUM_COMBATANT_FACTOR = 4;
        private static readonly int LARGE_MAX_COMBATANT_COUNT = 18;
        private static readonly int LARGE_COMBATANT_FACTOR = 5;

        public static int GetMaxCount(FieldSize fieldSize, int phalanxCount)
        {
            switch (fieldSize)
            {
                case FieldSize.Small:
                    return GetMaxUnitCounts(phalanxCount, SMALL_COMBATANT_FACTOR, SMALL_MAX_COMBATANT_COUNT);

                case FieldSize.Medium:
                    return GetMaxUnitCounts(phalanxCount, MEDIUM_COMBATANT_FACTOR, MEDIUM_MAX_COMBATANT_COUNT);

                case FieldSize.Large:
                    return GetMaxUnitCounts(phalanxCount, LARGE_COMBATANT_FACTOR, LARGE_MAX_COMBATANT_COUNT);

                case FieldSize.None:
                default:
                    return 0;
            }
        }

        private static int GetMaxUnitCounts(int phalanxCount, int unitFactor, int maxUnitCount)
        {
            return Math.Max(phalanxCount * unitFactor, maxUnitCount);
        }
    }
}