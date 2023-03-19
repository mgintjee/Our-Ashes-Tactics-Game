using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Managers.Loggers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Armors.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Cabins.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Engines.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Loadouts.Gears.Weapons.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Constants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models.Attrs.Managers;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.Models.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils.Combatants
{
    public class LoadoutRandomizerUtil
    {
        private static readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Common)
                .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        public static ILoadoutDetails Randomize(Random random, ModelID modelID)
        {
            ArmorGearID armorGearID = RandomizeArmorGearID(random, modelID);
            CabinGearID cabinGearID = RandomizeCabinGearID(random, modelID);
            EngineGearID engineGearID = RandomizeEngineGearID(random, modelID);
            IList<WeaponGearID> weaponGearID = RandomizeWeaponGearIDSet(random, modelID);
            ILoadoutDetails details = LoadoutDetailsImpl.Builder.Get()
                .SetArmorGearID(armorGearID)
                .SetCabinGearID(cabinGearID)
                .SetEngineGearID(engineGearID)
                .SetWeaponGearID(weaponGearID)
                .Build();
            logger.Info("Randomized: {}", details);
            return details;
        }

        private static ArmorGearID RandomizeArmorGearID(Random random, ModelID modelID)
        {
            IList<ArmorGearID> availableArmorIDs = UnitGearIDConstants.Armors.GetGearIDs(modelID);
            ArmorGearID gearID = EnumUtils.GenerateRandomEnumFrom(random, availableArmorIDs);
            return gearID;
        }

        private static CabinGearID RandomizeCabinGearID(Random random, ModelID unitID)
        {
            IList<CabinGearID> availableCabinIDs = UnitGearIDConstants.Cabins.GetGearIDs(unitID);
            CabinGearID gearID = EnumUtils.GenerateRandomEnumFrom(random, availableCabinIDs);
            return gearID;
        }

        private static EngineGearID RandomizeEngineGearID(Random random, ModelID unitID)
        {
            IList<EngineGearID> availableEngineIDs = UnitGearIDConstants.Engines.GetGearIDs(unitID);
            EngineGearID gearID = EnumUtils.GenerateRandomEnumFrom(random, availableEngineIDs);
            return gearID;
        }

        private static IList<WeaponGearID> RandomizeWeaponGearIDSet(Random random, ModelID unitID)
        {
            int weaponCount = 0;

            ModelAttributesManager.GetUnitAttributes(unitID).IfPresent(attribtues =>
            {
                weaponCount = attribtues.GetMountableAttributes().GetWeaponGearSizes().Count;
            });

            IList<WeaponGearID> weaponGearID = new List<WeaponGearID>();

            for (int i = 0; i < weaponCount; ++i)
            {
                weaponGearID.Add(RandomizeWeaponGearID(random, unitID));
            }

            return weaponGearID;
        }

        private static WeaponGearID RandomizeWeaponGearID(Random random, ModelID unitID)
        {
            IList<WeaponGearID> availableWeaponIDs = UnitGearIDConstants.Weapons.GetGearIDs(unitID);
            WeaponGearID gearID = EnumUtils.GenerateRandomEnumFrom(random, availableWeaponIDs);
            return gearID;
        }
    }
}