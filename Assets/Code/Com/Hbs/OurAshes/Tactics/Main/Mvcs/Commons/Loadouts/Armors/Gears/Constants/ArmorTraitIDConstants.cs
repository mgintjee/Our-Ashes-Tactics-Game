using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.IDs;
using System;
using System.Collections.Generic;
using System.Numerics;

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
            ISet<ArmorTraitID> armorTraitIDs = new HashSet<ArmorTraitID>();

            if (ARMOR_GEAR_ID_TRAIT_IDS.ContainsKey(armorGearID))
            {
                armorTraitIDs = new HashSet<ArmorTraitID>(ARMOR_GEAR_ID_TRAIT_IDS[armorGearID]);
            }

            return armorTraitIDs;
        }

        public static int GetArmorTraitCount(ArmorGearID armorGearID)
        {
            int armorTraitCount = 0;

            if (ARMOR_GEAR_ID_TRAIT_COUNTS.ContainsKey(armorGearID))
            {
                armorTraitCount = ARMOR_GEAR_ID_TRAIT_COUNTS[armorGearID];
            }

            return armorTraitCount;
        }
    }
}