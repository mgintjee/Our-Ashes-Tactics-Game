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
    public static class WeaponTraitMagazineConstants
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
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponTraitMagazine);
            }
        }
    }
}