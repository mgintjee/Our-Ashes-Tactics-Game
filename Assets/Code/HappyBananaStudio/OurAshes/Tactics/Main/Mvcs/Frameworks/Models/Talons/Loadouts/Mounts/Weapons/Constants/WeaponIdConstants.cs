namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponIdConstants
    {
        // Todo
        private static readonly IDictionary<WeaponId, ILoadoutAttributes> weaponIdWeaponAttributesDictionary =
            new Dictionary<WeaponId, ILoadoutAttributes>()
            {
                // Assault Impls
                {
                    WeaponId.Assault1,
                    new LoadoutAttributes.Builder()
                        .SetWeaponAttributes(new WeaponAttributes.Builder()
                            .SetAccuracyPoints(85f)
                            .SetArmorDamagePoints(4f)
                            .SetArmorPenetrationPoints(4f)
                            .SetHealthDamagePoints(4f)
                            .SetMaxRangePoints(4)
                            .SetVolleySize(4)
                            .Build())
                        .Build()
                },
                // Cannon Impls
                {
                    WeaponId.Cannon1,
                    new LoadoutAttributes.Builder()
                        .SetWeaponAttributes(new WeaponAttributes.Builder()
                            .SetAccuracyPoints(85f)
                            .SetArmorDamagePoints(6f)
                            .SetArmorPenetrationPoints(8f)
                            .SetHealthDamagePoints(10f)
                            .SetMaxRangePoints(5)
                            .SetVolleySize(1)
                            .Build())
                        .Build()
                },
                // HeatLauncher Impls
                {
                    WeaponId.HeatLauncher1,
                    new LoadoutAttributes.Builder()
                        .SetWeaponAttributes(new WeaponAttributes.Builder()
                            .SetAccuracyPoints(95f)
                            .SetArmorDamagePoints(2f)
                            .SetArmorPenetrationPoints(6f)
                            .SetHealthDamagePoints(8f)
                            .SetMaxRangePoints(4)
                            .SetVolleySize(2)
                            .Build())
                        .Build()
                },
                // Machinegun Impls
                {
                    WeaponId.Machinegun1,
                    new LoadoutAttributes.Builder()
                        .SetWeaponAttributes(new WeaponAttributes.Builder()
                            .SetAccuracyPoints(65)
                            .SetArmorDamagePoints(2)
                            .SetArmorPenetrationPoints(1)
                            .SetHealthDamagePoints(2)
                            .SetMaxRangePoints(3)
                            .SetVolleySize(8)
                            .Build())
                        .Build()
                },
                // Shotgun Impls
                {
                    WeaponId.Shotgun1,
                    new LoadoutAttributes.Builder()
                        .SetWeaponAttributes(new WeaponAttributes.Builder()
                            .SetAccuracyPoints(75)
                            .SetArmorDamagePoints(4)
                            .SetArmorPenetrationPoints(2)
                            .SetHealthDamagePoints(8)
                            .SetMaxRangePoints(2)
                            .SetVolleySize(3)
                            .Build())
                        .Build()
                },
                // Sniper Impls
                {
                    WeaponId.Sniper1,
                    new LoadoutAttributes.Builder()
                        .SetWeaponAttributes(new WeaponAttributes.Builder()
                            .SetAccuracyPoints(115)
                            .SetArmorDamagePoints(3)
                            .SetArmorPenetrationPoints(10)
                            .SetHealthDamagePoints(10)
                            .SetMaxRangePoints(6)
                            .SetVolleySize(2)
                            .Build())
                        .Build()
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(WeaponId weaponId)
        {
            // Check if the weaponId is supported
            if (weaponIdWeaponAttributesDictionary.ContainsKey(weaponId))
            {
                return weaponIdWeaponAttributesDictionary[weaponId];
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponId);
            }
        }
    }
}