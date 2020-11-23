namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Constants.Loadouts.Mounts.Weapons.Ids
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Weapons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponIdTypeConstants
    {
        // Todo
        private static readonly IDictionary<WeaponIdType, ISet<WeaponId>> weaponIdWeaponIdTypeDictionary =
            new Dictionary<WeaponIdType, ISet<WeaponId>>()
            {
                {
                    WeaponIdType.None,
                    new HashSet<WeaponId>()
                },
                {
                    WeaponIdType.Assault,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Assault1
                    }
                },
                {
                    WeaponIdType.Cannon,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Cannon1
                    }
                },
                {
                    WeaponIdType.HeatLauncher,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.HeatLauncher1
                    }
                },
                {
                    WeaponIdType.Machinegun,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Machinegun1
                    }
                },
                {
                    WeaponIdType.Sniper,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Sniper1
                    }
                },
                {
                    WeaponIdType.Shotgun,
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
        public static ISet<WeaponId> GetWeaponIdSet(WeaponIdType weaponIdType)
        {
            // Check if the weaponIdType is supported
            if (weaponIdWeaponIdTypeDictionary.ContainsKey(weaponIdType))
            {
                return weaponIdWeaponIdTypeDictionary[weaponIdType];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponIdType);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public static WeaponIdType GetWeaponIdType(WeaponId weaponId)
        {
            foreach (WeaponIdType weaponIdType in weaponIdWeaponIdTypeDictionary.Keys)
            {
                if (weaponIdWeaponIdTypeDictionary[weaponIdType].Contains(weaponId))
                {
                    return weaponIdType;
                }
            }
            throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponId);
        }
    }
}