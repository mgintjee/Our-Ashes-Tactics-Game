using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Armors.Traits.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Cabins.Traits.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Engines.Traits.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Weapons.Traits.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations
{
    public class LoadoutDetailsRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static ILoadoutDetails Randomize(Random random, ModelID unitID)
        {
            IArmorGearDetails armorGearDetails = RandomizeArmorGearDetails(random, unitID);
            ICabinGearDetails cabinGearDetails = RandomizeCabinGearDetails(random, unitID);
            IEngineGearDetails engineGearDetails = RandomizeEngineGearDetails(random, unitID);
            IList<IWeaponGearDetails> weaponGearDetails = RandomizeWeaponGearDetailsSet(random, unitID);
            ILoadoutDetails details = LoadoutDetailsImpl.Builder.Get()
                .SetArmorGearDetails(armorGearDetails)
                .SetCabinGearDetails(cabinGearDetails)
                .SetEngineGearDetails(engineGearDetails)
                .SetWeaponGearDetails(weaponGearDetails)
                .Build();
            logger.Info("Randomized: {}", details);
            return details;
        }

        private static IArmorGearDetails RandomizeArmorGearDetails(Random random, ModelID modelID)
        {
            ISet<ArmorGearID> availableArmorIDs = UnitGearIDConstants.Armor.GetArmorTraitIDs(modelID);
            ArmorGearID gearID = EnumUtils.GenerateRandomEnumFrom(random, availableArmorIDs);
            int traitCount = ArmorTraitIDConstants.GetArmorTraitCount(gearID);
            ISet<ArmorTraitID> availableTraitIDs = ArmorTraitIDConstants.GetArmorTraitIDs(gearID);
            ISet<ArmorTraitID> traitIDs = EnumUtils.GenerateRandomEnumsFrom(random, availableTraitIDs, traitCount);
            IArmorGearDetails gearDetails = ArmorGearDetailsImpl.Builder.Get()
                .SetArmorGearID(gearID)
                .SetArmorTraitIDs(traitIDs)
                .Build();
            logger.Info("Randomized: {}", gearDetails);
            return gearDetails;
        }

        private static ICabinGearDetails RandomizeCabinGearDetails(Random random, ModelID unitID)
        {
            ISet<CabinGearID> availableCabinIDs = UnitGearIDConstants.Cabin.GetCabinTraitIDs(unitID);
            CabinGearID gearID = EnumUtils.GenerateRandomEnumFrom(random, availableCabinIDs);
            int traitCount = CabinTraitIDConstants.GetCabinTraitCount(gearID);
            ISet<CabinTraitID> availableTraitIDs = CabinTraitIDConstants.GetCabinTraitIDs(gearID);
            ISet<CabinTraitID> traitIDs = EnumUtils.GenerateRandomEnumsFrom(random, availableTraitIDs, traitCount);
            ICabinGearDetails cabinGearDetails = CabinGearDetailsImpl.Builder.Get()
                .SetCabinGearID(gearID)
                .SetCabinTraitIDs(traitIDs)
                .Build();
            logger.Info("Randomized: {}", cabinGearDetails);
            return cabinGearDetails;
        }

        private static IEngineGearDetails RandomizeEngineGearDetails(Random random, ModelID unitID)
        {
            ISet<EngineGearID> availableEngineIDs = UnitGearIDConstants.Engine.GetEngineTraitIDs(unitID);
            EngineGearID gearID = EnumUtils.GenerateRandomEnumFrom(random, availableEngineIDs);
            int traitCount = EngineTraitIDConstants.GetEngineTraitCount(gearID);
            ISet<EngineTraitID> availableTraitIDs = EngineTraitIDConstants.GetEngineTraitIDs(gearID);
            ISet<EngineTraitID> traitIDs = EnumUtils.GenerateRandomEnumsFrom(random, availableTraitIDs, traitCount);
            IEngineGearDetails gearDetails = EngineGearDetailsImpl.Builder.Get()
                .SetEngineGearID(gearID)
                .SetEngineTraitIDs(traitIDs)
                .Build();
            logger.Info("Randomized: {}", gearDetails);
            return gearDetails;
        }

        private static IList<IWeaponGearDetails> RandomizeWeaponGearDetailsSet(Random random, ModelID unitID)
        {
            int weaponCount = 0;

            UnitAttributesManager.GetUnitAttributes(unitID).IfPresent(attribtues =>
            {
                weaponCount = attribtues.GetMountableAttributes().GetWeaponGearSizes().Count;
            });

            IList<IWeaponGearDetails> weaponGearDetails = new List<IWeaponGearDetails>();

            for (int i = 0; i < weaponCount; ++i)
            {
                weaponGearDetails.Add(RandomizeWeaponGearDetails(random, unitID));
            }

            return weaponGearDetails;
        }

        private static IWeaponGearDetails RandomizeWeaponGearDetails(Random random, ModelID unitID)
        {
            ISet<WeaponGearID> availableWeaponIDs = UnitGearIDConstants.Weapon.GetWeaponTraitIDs(unitID);
            WeaponGearID gearID = EnumUtils.GenerateRandomEnumFrom(random, availableWeaponIDs);
            int traitCount = WeaponTraitIDConstants.GetWeaponTraitCount(gearID);
            ISet<WeaponTraitID> availableTraitIDs = WeaponTraitIDConstants.GetWeaponTraitIDs(gearID);
            ISet<WeaponTraitID> traitIDs = EnumUtils.GenerateRandomEnumsFrom(random, availableTraitIDs, traitCount);
            IWeaponGearDetails gearDetails = WeaponGearDetailsImpl.Builder.Get()
                .SetWeaponGearID(gearID)
                .SetWeaponTraitIDs(traitIDs)
                .Build();
            logger.Info("Randomized: {}", gearDetails);
            return gearDetails;
        }
    }
}