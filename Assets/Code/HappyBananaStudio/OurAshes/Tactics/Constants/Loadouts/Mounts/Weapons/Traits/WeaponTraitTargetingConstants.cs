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
    public static class WeaponTraitTargetingConstants
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
                {
                    WeaponTraitTargeting.Targeting1,
                    new LoadoutAttributesImpl.Builder()
                    .SetWeaponAttributes(new WeaponAttributesImpl.Builder()
                        .SetMaxRangePoints(-1)
                        .SetAccuracyPoints(2)
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
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponTraitTargeting);
            }
        }
    }
}