using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attrs.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Armors.Traits.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Cabins.Traits.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Engines.Traits.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Constants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Gears.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Weapons.Traits.IDs;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Randomizations
{
    public class LoadoutDetailsRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);
        public static ILoadoutDetails Randomize(Random random, CombatantID combatantID)
        {
            IArmorGearDetails armorGearDetails = RandomizeArmorGearDetails(random, combatantID);
            ICabinGearDetails cabinGearDetails = RandomizeCabinGearDetails(random, combatantID);
            IEngineGearDetails engineGearDetails = RandomizeEngineGearDetails(random, combatantID);
            ISet<IWeaponGearDetails> weaponGearDetails = RandomizeWeaponGearDetailsSet(random, combatantID);
            ILoadoutDetails details = LoadoutDetailsImpl.Builder.Get()
                .SetArmorGearDetails(armorGearDetails)
                .SetCabinGearDetails(cabinGearDetails)
                .SetEngineGearDetails(engineGearDetails)
                .SetWeaponGearDetails(weaponGearDetails)
                .Build();
            logger.Info("Randomized: {}", details);
            return details;
        }

        private static IArmorGearDetails RandomizeArmorGearDetails(Random random, CombatantID combatantID)
        {
            ISet<ArmorGearID> availableArmorIDs = CombatantGearIDConstants.Armor.GetArmorTraitIDs(combatantID);
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

        private static ICabinGearDetails RandomizeCabinGearDetails(Random random, CombatantID combatantID)
        {
            ISet<CabinGearID> availableCabinIDs = CombatantGearIDConstants.Cabin.GetCabinTraitIDs(combatantID);
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

        private static IEngineGearDetails RandomizeEngineGearDetails(Random random, CombatantID combatantID)
        {
            ISet<EngineGearID> availableEngineIDs = CombatantGearIDConstants.Engine.GetEngineTraitIDs(combatantID);
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

        private static ISet<IWeaponGearDetails> RandomizeWeaponGearDetailsSet(Random random, CombatantID combatantID)
        {
            int weaponCount = 0;

            CombatantAttributesManager.GetCombatantAttributes(combatantID).IfPresent(attribtues =>
            {
                weaponCount = attribtues.GetMountableAttributes().GetWeaponGearSizes().Count;
            });

            ISet<IWeaponGearDetails> weaponGearDetails = new HashSet<IWeaponGearDetails>();

            for (int i = 0; i < weaponCount; ++i)
            {
                weaponGearDetails.Add(RandomizeWeaponGearDetails(random, combatantID));
            }

            return weaponGearDetails;
        }

        private static IWeaponGearDetails RandomizeWeaponGearDetails(Random random, CombatantID combatantID)
        {
            ISet<WeaponGearID> availableWeaponIDs = CombatantGearIDConstants.Weapon.GetWeaponTraitIDs(combatantID);
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