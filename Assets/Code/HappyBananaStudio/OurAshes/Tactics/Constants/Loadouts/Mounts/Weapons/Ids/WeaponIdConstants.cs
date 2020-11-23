namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Constants.Loadouts.Mounts.Weapons.Ids
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loadouts.Mounts.Weapons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loadouts.Common.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponIdConstants
    {
        // Todo
        private static readonly IDictionary<WeaponId, IWeaponAttributes> weaponIdWeaponAttributesDictionary =
            new Dictionary<WeaponId, IWeaponAttributes>()
            {
                {
                    WeaponId.None,
                    new WeaponAttributesImpl.Builder().Build()
                },
                // Assault Impls
                {
                    WeaponId.Assault1,
                    new WeaponAttributesImpl.Builder()
                    .SetAccuracyPoints(85)
                    .SetArmorDamagePoints(4)
                    .SetArmorPenetrationPoints(4)
                    .SetHealthDamagePoints(4)
                    .SetMaxRangePoints(4)
                    .SetVolleySize(4)
                    .Build()
                },
                // Cannon Impls
                {
                    WeaponId.Cannon1,
                    new WeaponAttributesImpl.Builder()
                    .SetAccuracyPoints(85)
                    .SetArmorDamagePoints(6)
                    .SetArmorPenetrationPoints(8)
                    .SetHealthDamagePoints(10)
                    .SetMaxRangePoints(5)
                    .SetVolleySize(1)
                    .Build()
                },
                // Machinegun Impls
                {
                    WeaponId.Machinegun1,
                    new WeaponAttributesImpl.Builder()
                    .SetAccuracyPoints(65)
                    .SetArmorDamagePoints(2)
                    .SetArmorPenetrationPoints(1)
                    .SetHealthDamagePoints(2)
                    .SetMaxRangePoints(3)
                    .SetVolleySize(8)
                    .Build()
                },
                // Shotgun Impls
                {
                    WeaponId.Shotgun1,
                    new WeaponAttributesImpl.Builder()
                    .SetAccuracyPoints(75)
                    .SetArmorDamagePoints(4)
                    .SetArmorPenetrationPoints(2)
                    .SetHealthDamagePoints(8)
                    .SetMaxRangePoints(2)
                    .SetVolleySize(3)
                    .Build()
                },
                // Sniper Impls
                {
                    WeaponId.Sniper1,
                    new WeaponAttributesImpl.Builder()
                    .SetAccuracyPoints(115)
                    .SetArmorDamagePoints(3)
                    .SetArmorPenetrationPoints(10)
                    .SetHealthDamagePoints(10)
                    .SetMaxRangePoints(6)
                    .SetVolleySize(2)
                    .Build()
                },
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public static IWeaponAttributes GetWeaponAttributes(WeaponId weaponId)
        {
            // Check if the weaponTraitAmmo is supported
            if (weaponIdWeaponAttributesDictionary.ContainsKey(weaponId))
            {
                return weaponIdWeaponAttributesDictionary[weaponId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponId);
            }
        }
    }
}