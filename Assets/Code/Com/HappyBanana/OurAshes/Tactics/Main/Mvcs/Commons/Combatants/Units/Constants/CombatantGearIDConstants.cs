using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnitGearIDConstants
    {
        private static ISet<TEnumValue> GetEnumSet<TEnumKey, TEnumValue>(TEnumKey tEnumKey,
            IDictionary<TEnumKey, ISet<TEnumValue>> tEnumKeyTEnumValues)
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
            private static readonly IDictionary<ModelID, ISet<ArmorGearID>> ARMOR_GEAR_ID_TRAIT_IDS = new Dictionary<ModelID, ISet<ArmorGearID>>()
            {
                { ModelID.LightAlpha, GetGearIDsForLightAlpha() },
                { ModelID.MediumAlpha, GetGearIDsForMediumAlpha() },
                { ModelID.HeavyAlpha, GetGearIDsForHeavyAlpha() },
            };

            public static ISet<ArmorGearID> GetArmorTraitIDs(ModelID unitID)
            {
                return GetEnumSet(unitID, ARMOR_GEAR_ID_TRAIT_IDS);
            }

            private static ISet<ArmorGearID> GetGearIDsForLightAlpha()
            {
                return new HashSet<ArmorGearID>()
                {
                    ArmorGearID.AA
                };
            }

            private static ISet<ArmorGearID> GetGearIDsForMediumAlpha()
            {
                return new HashSet<ArmorGearID>()
                {
                    ArmorGearID.AA
                };
            }

            private static ISet<ArmorGearID> GetGearIDsForHeavyAlpha()
            {
                return new HashSet<ArmorGearID>()
                {
                    ArmorGearID.AA
                };
            }
        }

        public class Cabin
        {
            private static readonly IDictionary<ModelID, ISet<CabinGearID>> CABIN_GEAR_ID_TRAIT_IDS = new Dictionary<ModelID, ISet<CabinGearID>>()
            {
                { ModelID.LightAlpha, GetGearIDsForLightAlpha() },
                { ModelID.MediumAlpha, GetGearIDsForMediumAlpha() },
                { ModelID.HeavyAlpha, GetGearIDsForHeavyAlpha() },
            };

            public static ISet<CabinGearID> GetCabinTraitIDs(ModelID unitID)
            {
                return GetEnumSet(unitID, CABIN_GEAR_ID_TRAIT_IDS);
            }

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
            private static readonly IDictionary<ModelID, ISet<EngineGearID>> ENGINE_GEAR_ID_TRAIT_IDS = new Dictionary<ModelID, ISet<EngineGearID>>()
            {
                { ModelID.LightAlpha, GetGearIDsForLightAlpha() },
                { ModelID.MediumAlpha, GetGearIDsForMediumAlpha() },
                { ModelID.HeavyAlpha, GetGearIDsForHeavyAlpha() },
            };

            public static ISet<EngineGearID> GetEngineTraitIDs(ModelID unitID)
            {
                return GetEnumSet(unitID, ENGINE_GEAR_ID_TRAIT_IDS);
            }

            private static ISet<EngineGearID> GetGearIDsForLightAlpha()
            {
                return new HashSet<EngineGearID>()
                {
                    EngineGearID.AA
                };
            }

            private static ISet<EngineGearID> GetGearIDsForMediumAlpha()
            {
                return new HashSet<EngineGearID>()
                {
                    EngineGearID.AA
                };
            }

            private static ISet<EngineGearID> GetGearIDsForHeavyAlpha()
            {
                return new HashSet<EngineGearID>()
                {
                    EngineGearID.AA
                };
            }
        }

        public class Weapon
        {
            private static readonly IDictionary<ModelID, ISet<WeaponGearID>> WEAPON_GEAR_ID_TRAIT_IDS = new Dictionary<ModelID, ISet<WeaponGearID>>()
            {
                { ModelID.LightAlpha, GetGearIDsForLightAlpha() },
                { ModelID.MediumAlpha, GetGearIDsForMediumAlpha() },
                { ModelID.HeavyAlpha, GetGearIDsForHeavyAlpha() },
            };

            public static ISet<WeaponGearID> GetWeaponTraitIDs(ModelID unitID)
            {
                return GetEnumSet(unitID, WEAPON_GEAR_ID_TRAIT_IDS);
            }

            private static ISet<WeaponGearID> GetGearIDsForLightAlpha()
            {
                return new HashSet<WeaponGearID>()
                {
                    WeaponGearID.AA
                };
            }

            private static ISet<WeaponGearID> GetGearIDsForMediumAlpha()
            {
                return new HashSet<WeaponGearID>()
                {
                    WeaponGearID.AA
                };
            }

            private static ISet<WeaponGearID> GetGearIDsForHeavyAlpha()
            {
                return new HashSet<WeaponGearID>()
                {
                    WeaponGearID.AA
                };
            }
        }
    }
}