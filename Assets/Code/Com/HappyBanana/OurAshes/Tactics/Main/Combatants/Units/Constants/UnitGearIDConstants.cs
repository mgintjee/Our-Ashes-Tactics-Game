using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Sizes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public class UnitGearIDConstants
    {
        public class Armors
        {
            private static readonly IList<ArmorGearID> DEFAULT_GEAR_IDS = new List<ArmorGearID>() { ArmorGearID.EMPTY };

            public static IList<ArmorGearID> GetGearIDs(ModelID modelID)
            {
                IList<ArmorGearID> gearIDs = new List<ArmorGearID>(DEFAULT_GEAR_IDS);
                ModelAttributesManager.GetUnitAttributes(modelID).IfPresent(unitAttributes =>
                {
                    GearSize gearSize = unitAttributes.GetMountableAttributes().GetArmorGearSize();
                    gearIDs = GetGearIDs(gearSize);
                });
                return gearIDs;
            }

            public static IList<ArmorGearID> GetGearIDs(GearSize gearSize)
            {
                IList<ArmorGearID> gearIDs = new List<ArmorGearID>(DEFAULT_GEAR_IDS);
                IList<ArmorGearID> allGearIDs = EnumUtils.GetEnumListWithoutFirst<ArmorGearID>();
                foreach (ArmorGearID gearID in allGearIDs)
                {
                    ArmorAttributesManager.GetAttributes(gearID).IfPresent(gearAttributes =>
                    {
                        if (gearAttributes.GetGearSize() == gearSize)
                        {
                            gearIDs.Add(gearID);
                        }
                    });
                }
                return gearIDs;
            }
        }

        public class Cabins
        {
            private static readonly IList<CabinGearID> DEFAULT_GEAR_ID = new List<CabinGearID>() { CabinGearID.EMPTY };

            public static IList<CabinGearID> GetGearIDs(ModelID modelID)
            {
                IList<CabinGearID> gearIDs = new List<CabinGearID>(DEFAULT_GEAR_ID);
                ModelAttributesManager.GetUnitAttributes(modelID).IfPresent(unitAttributes =>
                {
                    GearSize gearSize = unitAttributes.GetMountableAttributes().GetCabinGearSize();
                    gearIDs = GetGearIDs(gearSize);
                });
                return gearIDs;
            }

            public static IList<CabinGearID> GetGearIDs(GearSize gearSize)
            {
                IList<CabinGearID> gearIDs = new List<CabinGearID>(DEFAULT_GEAR_ID);
                IList<CabinGearID> allGearIDs = EnumUtils.GetEnumListWithoutFirst<CabinGearID>();
                foreach (CabinGearID gearID in allGearIDs)
                {
                    CabinAttributesManager.GetAttributes(gearID).IfPresent(gearAttributes =>
                    {
                        if (gearAttributes.GetGearSize() == gearSize)
                        {
                            gearIDs.Add(gearID);
                        }
                    });
                }
                return gearIDs;
            }
        }

        public class Engines
        {
            private static readonly IList<EngineGearID> DEFAULT_GEAR_ID = new List<EngineGearID>() { EngineGearID.EMPTY };

            public static IList<EngineGearID> GetGearIDs(ModelID modelID)
            {
                IList<EngineGearID> gearIDs = new List<EngineGearID>(DEFAULT_GEAR_ID);
                ModelAttributesManager.GetUnitAttributes(modelID).IfPresent(unitAttributes =>
                {
                    GearSize gearSize = unitAttributes.GetMountableAttributes().GetEngineGearSize();
                    gearIDs = GetGearIDs(gearSize);
                });
                return gearIDs;
            }

            public static IList<EngineGearID> GetGearIDs(GearSize gearSize)
            {
                IList<EngineGearID> gearIDs = new List<EngineGearID>(DEFAULT_GEAR_ID);
                IList<EngineGearID> allGearIDs = EnumUtils.GetEnumListWithoutFirst<EngineGearID>();
                foreach (EngineGearID gearID in allGearIDs)
                {
                    EngineAttributesManager.GetAttributes(gearID).IfPresent(gearAttributes =>
                    {
                        if (gearAttributes.GetGearSize() == gearSize)
                        {
                            gearIDs.Add(gearID);
                        }
                    });
                }
                return gearIDs;
            }
        }

        public class Weapons
        {
            private static readonly IList<WeaponGearID> DEFAULT_GEAR_ID = new List<WeaponGearID>() { WeaponGearID.EMPTY };

            public static IList<WeaponGearID> GetGearIDs(ModelID modelID)
            {
                IList<WeaponGearID> gearIDs = new List<WeaponGearID>(DEFAULT_GEAR_ID);
                ModelAttributesManager.GetUnitAttributes(modelID).IfPresent(unitAttributes =>
                {
                    IList<GearSize> gearSizes = unitAttributes.GetMountableAttributes().GetWeaponGearSizes();
                    foreach (GearSize gearSize in gearSizes)
                    {
                        foreach (WeaponGearID id in GetGearIDs(gearSize))
                        {
                            gearIDs.Add(id);
                        }
                    }
                });
                return gearIDs;
            }

            public static IList<WeaponGearID> GetGearIDs(GearSize gearSize)
            {
                IList<WeaponGearID> gearIDs = new List<WeaponGearID>(DEFAULT_GEAR_ID);
                IList<WeaponGearID> allGearIDs = EnumUtils.GetEnumListWithoutFirst<WeaponGearID>();
                foreach (WeaponGearID gearID in allGearIDs)
                {
                    WeaponAttributesManager.GetAttributes(gearID).IfPresent(gearAttributes =>
                    {
                        if (gearAttributes.GetGearSize() == gearSize)
                        {
                            gearIDs.Add(gearID);
                        }
                    });
                }
                return gearIDs;
            }
        }
    }
}