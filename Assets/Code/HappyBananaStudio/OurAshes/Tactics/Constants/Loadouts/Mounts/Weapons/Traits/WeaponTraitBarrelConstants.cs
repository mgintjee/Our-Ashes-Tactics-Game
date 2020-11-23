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
    public static class WeaponTraitBarrelConstants
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
                    WeaponTraitBarrel.Barrel2,
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
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponTraitBarrel);
            }
        }
    }
}