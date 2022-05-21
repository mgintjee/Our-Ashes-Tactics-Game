using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Traits.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CabinTraitIDConstants
    {
        private static readonly IDictionary<CabinGearID, ISet<CabinTraitID>> CABIN_GEAR_ID_TRAIT_IDS = new Dictionary<CabinGearID, ISet<CabinTraitID>>();
        private static readonly IDictionary<CabinGearID, int> CABIN_GEAR_ID_TRAIT_COUNTS = new Dictionary<CabinGearID, int>();

        public static ISet<CabinTraitID> GetCabinTraitIDs(CabinGearID cabinGearID)
        {
            ISet<CabinTraitID> cabinTraitIDs = new HashSet<CabinTraitID>();

            if (CABIN_GEAR_ID_TRAIT_IDS.ContainsKey(cabinGearID))
            {
                cabinTraitIDs = new HashSet<CabinTraitID>(CABIN_GEAR_ID_TRAIT_IDS[cabinGearID]);
            }

            return cabinTraitIDs;
        }

        public static int GetCabinTraitCount(CabinGearID cabinGearID)
        {
            int cabinTraitCount = 0;

            if (CABIN_GEAR_ID_TRAIT_COUNTS.ContainsKey(cabinGearID))
            {
                cabinTraitCount = CABIN_GEAR_ID_TRAIT_COUNTS[cabinGearID];
            }

            return cabinTraitCount;
        }
    }
}