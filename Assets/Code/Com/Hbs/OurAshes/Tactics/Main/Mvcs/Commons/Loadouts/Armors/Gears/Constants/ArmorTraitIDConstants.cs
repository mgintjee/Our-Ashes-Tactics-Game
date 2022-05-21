using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class ArmorTraitIDConstants
    {
        private static readonly IDictionary<ArmorGearID, ISet<ArmorTraitID>> ARMOR_GEAR_ID_TRAIT_IDS = new Dictionary<ArmorGearID, ISet<ArmorTraitID>>();
        private static readonly IDictionary<ArmorGearID, int> ARMOR_GEAR_ID_TRAIT_COUNTS = new Dictionary<ArmorGearID, int>();

        public static ISet<ArmorTraitID> GetArmorTraitIDs(ArmorGearID armorGearID)
        {
            return (ARMOR_GEAR_ID_TRAIT_IDS.ContainsKey(armorGearID))
                ? new HashSet<ArmorTraitID>(ARMOR_GEAR_ID_TRAIT_IDS[armorGearID])
                : new HashSet<ArmorTraitID>();
        }

        public static int GetArmorTraitCount(ArmorGearID armorGearID)
        {
            return (ARMOR_GEAR_ID_TRAIT_COUNTS.ContainsKey(armorGearID))
                ? ARMOR_GEAR_ID_TRAIT_COUNTS[armorGearID]
                : 0;
        }
    }
}