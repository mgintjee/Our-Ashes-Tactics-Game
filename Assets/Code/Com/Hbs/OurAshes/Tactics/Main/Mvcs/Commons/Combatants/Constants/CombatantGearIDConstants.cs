using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.IDs;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CombatantGearIDConstants
    {
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

        public class Armor
        {
            private static readonly IDictionary<CombatantID, ISet<ArmorGearID>> ARMOR_GEAR_ID_TRAIT_IDS = new Dictionary<CombatantID, ISet<ArmorGearID>>()
            {
                { CombatantID.LightAlpha, GetGearIDsForLightAlpha() },
                { CombatantID.MediumAlpha, GetGearIDsForMediumAlpha() },
                { CombatantID.HeavyAlpha, GetGearIDsForHeavyAlpha() },
            };

            public static ISet<ArmorGearID> GetArmorTraitIDs(CombatantID combatantID)
            {
                return GetEnumSet(combatantID, ARMOR_GEAR_ID_TRAIT_IDS);
            }

            private static ISet<ArmorGearID> GetGearIDsForLightAlpha()
            {
                return new HashSet<ArmorGearID>()
                {
                    ArmorGearID.AlphaAlpha
                };
            }
            private static ISet<ArmorGearID> GetGearIDsForMediumAlpha()
            {
                return new HashSet<ArmorGearID>()
                {
                    ArmorGearID.AlphaAlpha
                };
            }
            private static ISet<ArmorGearID> GetGearIDsForHeavyAlpha()
            {
                return new HashSet<ArmorGearID>()
                {
                    ArmorGearID.AlphaAlpha
                };
            }
        }

        public class Cabin
        {
            public static ISet<CabinGearID> GetCabinTraitIDs(CombatantID combatantID)
            {
                return GetEnumSet(combatantID, CABIN_GEAR_ID_TRAIT_IDS);
            }

            private static readonly IDictionary<CombatantID, ISet<CabinGearID>> CABIN_GEAR_ID_TRAIT_IDS = new Dictionary<CombatantID, ISet<CabinGearID>>()
            {
                { CombatantID.LightAlpha, GetGearIDsForLightAlpha() },
                { CombatantID.MediumAlpha, GetGearIDsForMediumAlpha() },
                { CombatantID.HeavyAlpha, GetGearIDsForHeavyAlpha() },
            };

            private static ISet<CabinGearID> GetGearIDsForLightAlpha()
            {
                return new HashSet<CabinGearID>()
                {
                    CabinGearID.AlphaAlpha
                };
            }
            private static ISet<CabinGearID> GetGearIDsForMediumAlpha()
            {
                return new HashSet<CabinGearID>()
                {
                    CabinGearID.AlphaAlpha
                };
            }
            private static ISet<CabinGearID> GetGearIDsForHeavyAlpha()
            {
                return new HashSet<CabinGearID>()
                {
                    CabinGearID.AlphaAlpha
                };
            }
        }

        public class Engine
        {
            private static readonly IDictionary<CombatantID, ISet<EngineGearID>> ENGINE_GEAR_ID_TRAIT_IDS = new Dictionary<CombatantID, ISet<EngineGearID>>()
            {
                { CombatantID.LightAlpha, GetGearIDsForLightAlpha() },
                { CombatantID.MediumAlpha, GetGearIDsForMediumAlpha() },
                { CombatantID.HeavyAlpha, GetGearIDsForHeavyAlpha() },
            };

            private static ISet<EngineGearID> GetGearIDsForLightAlpha()
            {
                return new HashSet<EngineGearID>()
                {
                    EngineGearID.AlphaAlpha
                };
            }
            private static ISet<EngineGearID> GetGearIDsForMediumAlpha()
            {
                return new HashSet<EngineGearID>()
                {
                    EngineGearID.AlphaAlpha
                };
            }
            private static ISet<EngineGearID> GetGearIDsForHeavyAlpha()
            {
                return new HashSet<EngineGearID>()
                {
                    EngineGearID.AlphaAlpha
                };
            }
            public static ISet<EngineGearID> GetEngineTraitIDs(CombatantID combatantID)
            {
                return GetEnumSet(combatantID, ENGINE_GEAR_ID_TRAIT_IDS);
            }
        }

        public class Weapon
        {
            private static readonly IDictionary<CombatantID, ISet<WeaponGearID>> WEAPON_GEAR_ID_TRAIT_IDS = new Dictionary<CombatantID, ISet<WeaponGearID>>()
            {
                { CombatantID.LightAlpha, GetGearIDsForLightAlpha() },
                { CombatantID.MediumAlpha, GetGearIDsForMediumAlpha() },
                { CombatantID.HeavyAlpha, GetGearIDsForHeavyAlpha() },
            };

            private static ISet<WeaponGearID> GetGearIDsForLightAlpha()
            {
                return new HashSet<WeaponGearID>()
                {
                    WeaponGearID.AlphaAlpha
                };
            }
            private static ISet<WeaponGearID> GetGearIDsForMediumAlpha()
            {
                return new HashSet<WeaponGearID>()
                {
                    WeaponGearID.AlphaAlpha
                };
            }
            private static ISet<WeaponGearID> GetGearIDsForHeavyAlpha()
            {
                return new HashSet<WeaponGearID>()
                {
                    WeaponGearID.AlphaAlpha
                };
            }
            public static ISet<WeaponGearID> GetWeaponTraitIDs(CombatantID combatantID)
            {
                return GetEnumSet(combatantID, WEAPON_GEAR_ID_TRAIT_IDS);
            }
        }
    }
}