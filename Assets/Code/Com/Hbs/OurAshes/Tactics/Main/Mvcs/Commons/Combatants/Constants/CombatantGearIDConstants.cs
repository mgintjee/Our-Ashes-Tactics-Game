using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Shapes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Tiles.Algorithms.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.IDs;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CombatantGearIDConstants
    {
        public class Armor
        {
            private static readonly IDictionary<CombatantID, ISet<ArmorGearID>> ARMOR_GEAR_ID_TRAIT_IDS = new Dictionary<CombatantID, ISet<ArmorGearID>>();

            public static ISet<ArmorGearID> GetArmorTraitIDs(CombatantID combatantID)
            {
                return GetEnumSet(combatantID, ARMOR_GEAR_ID_TRAIT_IDS);
            }
        }

        public class Cabin
        {
            private static readonly IDictionary<CombatantID, ISet<CabinGearID>> CABIN_GEAR_ID_TRAIT_IDS = new Dictionary<CombatantID, ISet<CabinGearID>>();

            public static ISet<CabinGearID> GetCabinTraitIDs(CombatantID combatantID)
            {
                return GetEnumSet(combatantID, CABIN_GEAR_ID_TRAIT_IDS);
            }
        }

        public class Engine
        {
            private static readonly IDictionary<CombatantID, ISet<EngineGearID>> ENGINE_GEAR_ID_TRAIT_IDS = new Dictionary<CombatantID, ISet<EngineGearID>>();

            public static ISet<EngineGearID> GetEngineTraitIDs(CombatantID combatantID)
            {
                return GetEnumSet(combatantID, ENGINE_GEAR_ID_TRAIT_IDS);
            }
        }

        public class Weapon
        {
            private static readonly IDictionary<CombatantID, ISet<WeaponGearID>> WEAPON_GEAR_ID_TRAIT_IDS = new Dictionary<CombatantID, ISet<WeaponGearID>>();

            public static ISet<WeaponGearID> GetWeaponTraitIDs(CombatantID combatantID)
            {
                return GetEnumSet(combatantID, WEAPON_GEAR_ID_TRAIT_IDS);
            }
        }

        private static ISet<TEnumValue> GetEnumSet<TEnumKey, TEnumValue>(TEnumKey tEnumKey, IDictionary<TEnumKey, ISet<TEnumValue>> tEnumKeyTEnumValues)
            where TEnumKey : Enum
            where TEnumValue : Enum
        {
            ISet<TEnumValue> tEnumValues = new HashSet<TEnumValue>();

            if (tEnumKeyTEnumValues.ContainsKey(tEnumKey))
            {
                tEnumValues = new HashSet<TEnumValue>(tEnumKeyTEnumValues[tEnumKey]);
            }

            return tEnumValues;
        }
    }
}