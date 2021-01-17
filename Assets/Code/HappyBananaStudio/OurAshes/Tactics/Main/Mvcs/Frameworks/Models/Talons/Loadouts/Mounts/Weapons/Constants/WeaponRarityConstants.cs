namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponRarityConstants
    {
        // Todo
        private static readonly IDictionary<LoadoutRarity, int> loadoutRarityWeaponTraitCountDictionary =
            new Dictionary<LoadoutRarity, int>()
            {
                { LoadoutRarity.None, 0},
                { LoadoutRarity.Common, 1},
                { LoadoutRarity.Uncommon, 2},
                { LoadoutRarity.Rare, 3},
                { LoadoutRarity.Unique, 0},
            };

        // Todo
        private static readonly IDictionary<LoadoutRarity, ISet<WeaponId>> loadoutRarityWeaponIdSetDictionary =
            new Dictionary<LoadoutRarity, ISet<WeaponId>>()
            {
                {
                    LoadoutRarity.None,
                    new HashSet<WeaponId>()
                },
                {
                    LoadoutRarity.Common,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Assault1,
                        WeaponId.Cannon1,
                        WeaponId.HeatLauncher1,
                        WeaponId.Machinegun1,
                        WeaponId.Shotgun1,
                        WeaponId.Sniper1
                    }
                },
                {
                    LoadoutRarity.Uncommon,
                    new HashSet<WeaponId>()
                    {
                    }
                },
                {
                    LoadoutRarity.Rare,
                    new HashSet<WeaponId>()
                    {
                    }
                },
                {
                    LoadoutRarity.Unique,
                    new HashSet<WeaponId>()
                    {
                    }
                }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static ISet<WeaponId> GetWeaponIdSet(LoadoutRarity loadoutRarity)
        {
            // Check if the loadoutRarity is supported
            if (loadoutRarityWeaponIdSetDictionary.ContainsKey(loadoutRarity))
            {
                return loadoutRarityWeaponIdSetDictionary[loadoutRarity];
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, loadoutRarity);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public static LoadoutRarity GetLoadoutRarity(WeaponId weaponId)
        {
            foreach (LoadoutRarity loadoutRarity in loadoutRarityWeaponIdSetDictionary.Keys)
            {
                if (loadoutRarityWeaponIdSetDictionary[loadoutRarity].Contains(weaponId))
                {
                    return loadoutRarity;
                }
            }
            throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="loadoutRarity"></param>
        /// <returns></returns>
        public static int GetLoadoutTraitCount(LoadoutRarity loadoutRarity)
        {
            // Check if the loadoutRarity is supported
            if (loadoutRarityWeaponTraitCountDictionary.ContainsKey(loadoutRarity))
            {
                return loadoutRarityWeaponTraitCountDictionary[loadoutRarity];
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, loadoutRarity);
            }
        }
    }
}