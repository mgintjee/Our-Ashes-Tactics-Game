namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Common.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Attributes.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Mounts.Weapons.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponTraitConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        public static class Ammo
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
                    throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, weaponTraitAmmo);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Barrel
        {
            // Todo
            private static readonly IDictionary<WeaponTraitBarrel, ILoadoutAttributes> weaponTraitBarrelLoadoutAttributesDictionary =
                new Dictionary<WeaponTraitBarrel, ILoadoutAttributes>()
                {
                {
                    WeaponTraitBarrel.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
                {
                    WeaponTraitBarrel.Barrel1,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(1)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitBarrel.Barrel3,
                    new LoadoutAttributesImpl.Builder()
                    .SetEngineAttributes(new EngineAttributesImpl.Builder()
                        .SetMovementPoints(2)
                        .Build())
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetMaxRangePoints(-1)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitBarrel.Barrel2,
                    new LoadoutAttributesImpl.Builder()
                    .SetEngineAttributes(new EngineAttributesImpl.Builder()
                        .SetMovementPoints(-1)
                        .Build())
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetMaxRangePoints(2)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitBarrel.Barrel4,
                    new LoadoutAttributesImpl.Builder()
                    .SetEngineAttributes(new EngineAttributesImpl.Builder()
                        .SetMovementPoints(-1)
                        .Build())
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetMaxRangePoints(2)
                        .Build())
                    .Build()
                }
                };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponTraitBarrel"></param>
            /// <returns></returns>
            public static ILoadoutAttributes GetLoadoutAttributes(WeaponTraitBarrel weaponTraitBarrel)
            {
                // Check if the weaponTraitBarrel is supported
                if (weaponTraitBarrelLoadoutAttributesDictionary.ContainsKey(weaponTraitBarrel))
                {
                    return weaponTraitBarrelLoadoutAttributesDictionary[weaponTraitBarrel];
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, weaponTraitBarrel);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Magazine
        {
            // Todo
            private static readonly IDictionary<WeaponTraitMagazine, ILoadoutAttributes> weaponTraitMagazineLoadoutAttributesDictionary =
                new Dictionary<WeaponTraitMagazine, ILoadoutAttributes>()
                {
                {
                    WeaponTraitMagazine.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
                {
                    WeaponTraitMagazine.Magazine1,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetVolleySize(1)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitMagazine.Magazine2,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetVolleySize(1)
                        .Build())
                    .SetEngineAttributes(new EngineAttributesImpl.Builder()
                        .SetMovementPoints(2)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitMagazine.Magazine3,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetVolleySize(2)
                        .Build())
                    .SetEngineAttributes(new EngineAttributesImpl.Builder()
                        .SetMovementPoints(-1)
                        .Build())
                    .Build()
                },
                };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponTraitMagazine"></param>
            /// <returns></returns>
            public static ILoadoutAttributes GetLoadoutAttributes(WeaponTraitMagazine weaponTraitMagazine)
            {
                // Check if the weaponTraitMagazine is supported
                if (weaponTraitMagazineLoadoutAttributesDictionary.ContainsKey(weaponTraitMagazine))
                {
                    return weaponTraitMagazineLoadoutAttributesDictionary[weaponTraitMagazine];
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, weaponTraitMagazine);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public static class Targeting
        {
            // Todo
            private static readonly IDictionary<WeaponTraitTargeting, ILoadoutAttributes> weaponTraitTargetingLoadoutAttributesDictionary =
                new Dictionary<WeaponTraitTargeting, ILoadoutAttributes>()
                {
                {
                    WeaponTraitTargeting.None,
                    new LoadoutAttributesImpl.Builder().Build()
                },
                {
                    WeaponTraitTargeting.Targeting1,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetMaxRangePoints(-1)
                        .SetAccuracyPoints(2)
                        .Build())
                    .Build()
                },
                {
                    WeaponTraitTargeting.Targeting2,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetMaxRangePoints(2)
                        .Build())
                    .SetEngineAttributes(new EngineAttributesImpl.Builder()
                        .SetMovementPoints(-1)
                        .Build())
                    .Build()
                },
                };

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="weaponTraitTargeting"></param>
            /// <returns></returns>
            public static ILoadoutAttributes GetLoadoutAttributes(WeaponTraitTargeting weaponTraitTargeting)
            {
                // Check if the weaponTraitTargeting is supported
                if (weaponTraitTargetingLoadoutAttributesDictionary.ContainsKey(weaponTraitTargeting))
                {
                    return weaponTraitTargetingLoadoutAttributesDictionary[weaponTraitTargeting];
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, weaponTraitTargeting);
                }
            }
        }
    }
}