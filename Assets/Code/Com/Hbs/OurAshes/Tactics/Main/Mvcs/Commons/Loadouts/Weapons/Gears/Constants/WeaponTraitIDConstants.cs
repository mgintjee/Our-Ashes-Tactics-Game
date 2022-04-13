﻿using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Traits.IDs;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WeaponTraitIDConstants
    {
        private static readonly IDictionary<WeaponGearID, ISet<WeaponTraitID>> WEAPON_GEAR_ID_TRAIT_IDS = new Dictionary<WeaponGearID, ISet<WeaponTraitID>>();
        private static readonly IDictionary<WeaponGearID, int> WEAPON_GEAR_ID_TRAIT_COUNTS = new Dictionary<WeaponGearID, int>();

        public static ISet<WeaponTraitID> GetWeaponTraitIDs(WeaponGearID weaponGearID)
        {
            ISet<WeaponTraitID> weaponTraitIDs = new HashSet<WeaponTraitID>();

            if (WEAPON_GEAR_ID_TRAIT_IDS.ContainsKey(weaponGearID))
            {
                weaponTraitIDs = new HashSet<WeaponTraitID>(WEAPON_GEAR_ID_TRAIT_IDS[weaponGearID]);
            }

            return weaponTraitIDs;
        }

        public static int GetWeaponTraitCount(WeaponGearID weaponGearID)
        {
            int weaponTraitCount = 0;

            if (WEAPON_GEAR_ID_TRAIT_COUNTS.ContainsKey(weaponGearID))
            {
                weaponTraitCount = WEAPON_GEAR_ID_TRAIT_COUNTS[weaponGearID];
            }

            return weaponTraitCount;
        }
    }
}