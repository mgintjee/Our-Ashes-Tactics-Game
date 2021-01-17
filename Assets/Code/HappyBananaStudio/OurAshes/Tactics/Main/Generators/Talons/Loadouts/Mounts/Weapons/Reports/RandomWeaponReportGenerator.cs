namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Generators.Talons.Loadouts.Mounts.Weapons.Reports
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Randoms.Generators.Numbers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Utils.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class RandomWeaponReportGenerator
    {

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IWeaponReport GenerateRandomWeaponReport()
        {
            return GenerateRandomWeaponReport(LoadoutRarity.None, MountSize.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mountSize"></param>
        /// <returns></returns>
        public static IWeaponReport GenerateRandomWeaponReport(MountSize mountSize)
        {
            return GenerateRandomWeaponReport(LoadoutRarity.None, mountSize);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static IWeaponReport GenerateRandomWeaponReport(LoadoutRarity loadoutRarity)
        {
            return GenerateRandomWeaponReport(loadoutRarity, MountSize.None);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <param name="mountSize"></param>
        /// <returns></returns>
        public static IWeaponReport GenerateRandomWeaponReport(LoadoutRarity loadoutRarity, MountSize mountSize)
        {
            WeaponId weaponId = GetRandomWeaponId(loadoutRarity, mountSize);
            // Todo: Only randomize traits for non-unique loadouts which is determined by the loadoutRarity
            WeaponTraitAmmo weaponTraitAmmo = WeaponTraitAmmo.None;
            WeaponTraitBarrel weaponTraitBarrel = WeaponTraitBarrel.None;
            WeaponTraitMagazine weaponTraitMagazine = WeaponTraitMagazine.None;
            WeaponTraitTargeting weaponTraitTargeting = WeaponTraitTargeting.None;
            int traitsRequired = WeaponRarityConstants.GetLoadoutTraitCount(loadoutRarity);
            float traitsRemaining = 4f;

            if (RandomNumberGeneratorUtil.GetNextDouble() <= traitsRequired / traitsRemaining)
            {
                weaponTraitAmmo = EnumUtils.GetRandomEnum<WeaponTraitAmmo>();
                traitsRequired--;
            }
            traitsRemaining--;
            if (RandomNumberGeneratorUtil.GetNextDouble() <= traitsRequired / traitsRemaining)
            {
                weaponTraitBarrel = EnumUtils.GetRandomEnum<WeaponTraitBarrel>();
                traitsRequired--;
            }
            traitsRemaining--;
            if (RandomNumberGeneratorUtil.GetNextDouble() <= traitsRequired / traitsRemaining)
            {
                weaponTraitMagazine = EnumUtils.GetRandomEnum<WeaponTraitMagazine>();
                traitsRequired--;
            }
            traitsRemaining--;
            if (RandomNumberGeneratorUtil.GetNextDouble() <= traitsRequired / traitsRemaining)
            {
                weaponTraitTargeting = EnumUtils.GetRandomEnum<WeaponTraitTargeting>();
            }

            return new WeaponReport.Builder()
                .SetWeaponId(weaponId)
                .SetWeaponTraitReport(new WeaponTraitReport.Builder()
                    .SetWeaponTraitAmmo(weaponTraitAmmo)
                    .SetWeaponTraitBarrel(weaponTraitBarrel)
                    .SetWeaponTraitMagazine(weaponTraitMagazine)
                    .SetWeaponTraitTargeting(weaponTraitTargeting)
                    .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        private static WeaponId GetRandomWeaponId(LoadoutRarity loadoutRarity, MountSize mountSize)
        {
            ISet<WeaponId> weaponIdSet = new HashSet<WeaponId>();
            weaponIdSet.UnionWith((loadoutRarity.Equals(LoadoutRarity.None))
                ? weaponIdSet
                : WeaponRarityConstants.GetWeaponIdSet(loadoutRarity));
            weaponIdSet.IntersectWith((loadoutRarity.Equals(LoadoutRarity.None))
                ? weaponIdSet
                : WeaponMountSizeConstants.GetWeaponIdSet(mountSize));
            if (weaponIdSet.Count != 0)
            {
                return new List<WeaponId>(weaponIdSet)[RandomNumberGeneratorUtil.GetNextInt(weaponIdSet.Count)];
            }
            throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? and ? have no corresponding ?s.",
                    new StackFrame().GetMethod().Name, loadoutRarity, mountSize, typeof(WeaponId));
        }
    }
}