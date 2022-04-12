using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Armors.IDs;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ArmorTraitIDConstants
    {
        private static IDictionary<ArmorGearID, ISet<ArmorTraitID>>
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