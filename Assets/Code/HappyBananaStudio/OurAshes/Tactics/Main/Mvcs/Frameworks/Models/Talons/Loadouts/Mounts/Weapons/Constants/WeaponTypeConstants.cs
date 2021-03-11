namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponTypeConstants
    {
        // Todo
        private static readonly IDictionary<WeaponType, ISet<WeaponId>> weaponIdWeaponTypeDictionary =
            new Dictionary<WeaponType, ISet<WeaponId>>()
            {
                {
                    WeaponType.Assault,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Assault1
                    }
                },
                {
                    WeaponType.Cannon,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Cannon1
                    }
                },
                {
                    WeaponType.HeatLauncher,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.HeatLauncher1
                    }
                },
                {
                    WeaponType.Machinegun,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Machinegun1
                    }
                },
                {
                    WeaponType.Sniper,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Sniper1
                    }
                },
                {
                    WeaponType.Shotgun,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Shotgun1
                    }
                }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponIdType"></param>
        /// <returns></returns>
        public static ISet<WeaponId> GetWeaponIdSet(WeaponType weaponIdType)
        {
            // Check if the weaponIdType is supported
            if (weaponIdWeaponTypeDictionary.ContainsKey(weaponIdType))
            {
                return weaponIdWeaponTypeDictionary[weaponIdType];
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponIdType);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public static WeaponType GetWeaponType(WeaponId weaponId)
        {
            foreach (WeaponType weaponIdType in weaponIdWeaponTypeDictionary.Keys)
            {
                if (weaponIdWeaponTypeDictionary[weaponIdType].Contains(weaponId))
                {
                    return weaponIdType;
                }
            }
            throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponId);
        }
    }
}