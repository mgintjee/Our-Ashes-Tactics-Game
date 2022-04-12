using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Armors.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Armors.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Armors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Cabins.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Cabins.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Cabins.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Engines.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Engines.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Engines.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Weapons.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Weapons.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Armors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Cabins.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Engines.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Traits.Weapons.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils
{
    public class LoadoutDetailsRandomizerUtil
    {
        public static ILoadoutDetails Randomize(Random random, CombatantID combatantID)
        {
            IArmorGearDetails armorGearDetails = RandomizeArmorGearDetails(random, combatantID);
            ICabinGearDetails cabinGearDetails = RandomizeCabinGearDetails(random, combatantID);
            IEngineGearDetails engineGearDetails = RandomizeEngineGearDetails(random, combatantID);
            ISet<IWeaponGearDetails> weaponGearDetails = RandomizeWeaponGearDetailsSet(random, combatantID);
            return LoadoutDetailsImpl.Builder.Get()
                .SetArmorGearDetails(armorGearDetails)
                .SetCabinGearDetails(cabinGearDetails)
                .SetEngineGearDetails(engineGearDetails)
                .SetWeaponGearDetails(weaponGearDetails)
                .Build();
        }

        private static IArmorGearDetails RandomizeArmorGearDetails(Random random, CombatantID combatantID)
        {
            ArmorGearID armorGearID = EnumUtils.GenerateRandomEnum<ArmorGearID>(random);
            int traitCount = 0;
            ISet<ArmorTraitID> availableArmorTraitIDs;
            ISet<ArmorTraitID> armorTraitIDs = EnumUtils.GenerateRandomEnumsFrom(random, availableArmorTraitIDs, traitCount);
            return ArmorGearDetailsImpl.Builder.Get()
                .SetArmorGearID(armorGearID)
                .SetArmorTraitIDs(armorTraitIDs)
                .Build();
        }

        private static ICabinGearDetails RandomizeCabinGearDetails(Random random, CombatantID combatantID)
        {
            CabinGearID cabinGearID = EnumUtils.GenerateRandomEnum<CabinGearID>(random);
            int traitCount = 0;
            ISet<CabinTraitID> availableCabinTraitIDs;
            ISet<CabinTraitID> cabinTraitIDs = EnumUtils.GenerateRandomEnumsFrom(random, availableCabinTraitIDs, traitCount);
            return CabinGearDetailsImpl.Builder.Get()
                .SetCabinGearID(cabinGearID)
                .SetCabinTraitIDs(cabinTraitIDs)
                .Build();
        }

        private static IEngineGearDetails RandomizeEngineGearDetails(Random random, CombatantID combatantID)
        {
            EngineGearID engineGearID = EnumUtils.GenerateRandomEnum<EngineGearID>(random);
            int traitCount = 0;
            ISet<EngineTraitID> engineTraitIDs = EnumUtils.GenerateRandomEnumsFrom<EngineTraitID>(random, traitCount);
            return EngineGearDetailsImpl.Builder.Get()
                .SetEngineGearID(engineGearID)
                .SetEngineTraitIDs(engineTraitIDs)
                .Build();
        }

        private static ISet<IWeaponGearDetails> RandomizeWeaponGearDetailsSet(Random random, CombatantID combatantID)
        {
            int weaponCount = 0;

            ISet<IWeaponGearDetails> weaponGearDetails = new HashSet<IWeaponGearDetails>();

            for(int i = 0; i < weaponCount; ++i)
            {
                weaponGearDetails.Add(RandomizeWeaponGearDetails(random, combatantID));
            }

            return weaponGearDetails;
        }

        private static IWeaponGearDetails RandomizeWeaponGearDetails(Random random, CombatantID combatantID)
        {
            WeaponGearID weaponGearID = EnumUtils.GenerateRandomEnum<WeaponGearID>(random);
            int traitCount = 0;
            ISet<WeaponTraitID> weaponTraitIDs = EnumUtils.GenerateRandomEnumsFrom<WeaponTraitID>(random, traitCount);
            return WeaponGearDetailsImpl.Builder.Get()
                .SetWeaponGearID(weaponGearID)
                .SetWeaponTraitIDs(weaponTraitIDs)
                .Build();
        }

    }
}