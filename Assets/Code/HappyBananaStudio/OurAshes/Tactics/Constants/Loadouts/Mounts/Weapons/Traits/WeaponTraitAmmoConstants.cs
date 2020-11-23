namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Constants.Loadouts.Mounts.Weapons.Traits
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
    public static class WeaponTraitAmmoConstants
    {
        // Todo
        private static readonly IDictionary<WeaponTraitAmmo, ILoadoutAttributes> weaponTraitAmmoLoadoutAttributesDictionary =
            new Dictionary<WeaponTraitAmmo, ILoadoutAttributes>()
            {
                {
                    WeaponTraitAmmo.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
                {
                    WeaponTraitAmmo.Ammo1,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetMaxRangePoints(1)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitAmmo.Ammo2,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetArmorDamagePoints(-1)
                        .SetArmorPenetrationPoints(1)
                        .SetHealthDamagePoints(-1)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitAmmo.Ammo3,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetArmorDamagePoints(1)
                        .SetArmorPenetrationPoints(-1)
                        .SetHealthDamagePoints(1)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitAmmo.Ammo4,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetMaxRangePoints(-1)
                        .SetAccuracyPoints(1)
                        .Build())
                    .Build()
                }
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponTraitAmmo"></param>
        /// <returns></returns>
        public static ILoadoutAttributes GetLoadoutAttributes(WeaponTraitAmmo weaponTraitAmmo)
        {
            // Check if the weaponTraitAmmo is supported
            if (weaponTraitAmmoLoadoutAttributesDictionary.ContainsKey(weaponTraitAmmo))
            {
                return weaponTraitAmmoLoadoutAttributesDictionary[weaponTraitAmmo];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponTraitAmmo);
            }
        }
    }
}