namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponMountSizeConstants
    {
        // Todo
        private static readonly IDictionary<MountSize, ISet<WeaponId>> mountSizeWeaponIdDictionary =
            new Dictionary<MountSize, ISet<WeaponId>>()
            {
                {
                    MountSize.None,
                    new HashSet<WeaponId>()
                },
                {
                    MountSize.Small,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Assault1,
                        WeaponId.HeatLauncher1,
                        WeaponId.Machinegun1,
                        WeaponId.Shotgun1,
                        WeaponId.Sniper1
                    }
                },
                {
                    MountSize.Large,
                    new HashSet<WeaponId>()
                    {
                        WeaponId.Cannon1,
                    }
                }
            };

        public static IDictionary<MountSize, ISet<WeaponId>> MountSizeWeaponIdDictionary => mountSizeWeaponIdDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public static MountSize GetMountSize(WeaponId weaponId)
        {
            foreach (MountSize mountSize in MountSizeWeaponIdDictionary.Keys)
            {
                if (MountSizeWeaponIdDictionary[mountSize].Contains(weaponId))
                {
                    return mountSize;
                }
            }
            throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponId);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mountSize"></param>
        /// <returns></returns>
        public static ISet<WeaponId> GetWeaponIdSet(MountSize mountSize)
        {
            // Check if the mountSize is supported
            if (MountSizeWeaponIdDictionary.ContainsKey(mountSize))
            {
                return MountSizeWeaponIdDictionary[mountSize];
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, mountSize);
            }
        }
    }
}