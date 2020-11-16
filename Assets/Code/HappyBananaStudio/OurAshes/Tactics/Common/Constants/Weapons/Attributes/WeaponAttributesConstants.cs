
namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Weapons;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Weapons.Attributes;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Todo
    /// </summary>
    public class WeaponAttributesConstants
    {
        // Todo
        private static readonly IDictionary<WeaponModelId, IWeaponAttributes> weaponModelIdAttributesDictionary =
                new Dictionary<WeaponModelId, IWeaponAttributes>();

        // Todo
        private static readonly ISet<WeaponModelId> weaponModelIdSet = new HashSet<WeaponModelId>()
        {
            WeaponModelId.Weapon0,
            WeaponModelId.Weapon1,
            WeaponModelId.Weapon2,
            WeaponModelId.Weapon3,
            WeaponModelId.Weapon4,
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponModelId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IWeaponAttributes GetAttributes(WeaponModelId weaponModelId)
        {
            if (weaponModelIdSet.Contains(weaponModelId))
            {
                if (!weaponModelIdAttributesDictionary.ContainsKey(weaponModelId))
                {
                    weaponModelIdAttributesDictionary.Add(weaponModelId, BuildAttributes(weaponModelId));
                }
                return weaponModelIdAttributesDictionary[weaponModelId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponModelId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static ISet<WeaponModelId> GetSupportedWeaponIds()
        {
            return new HashSet<WeaponModelId>(weaponModelIdSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponModelId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IWeaponAttributes BuildAttributes(WeaponModelId weaponModelId)
        {
            switch (weaponModelId)
            {
                case WeaponModelId.Weapon0:
                    return new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(65)
                        .SetDamagePoints(1)
                        .SetNumberOfShots(8)
                        .SetPenetrationPoints(0)
                        .SetRangePoints(3)
                        .Build();

                case WeaponModelId.Weapon1:
                    return new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(85)
                        .SetDamagePoints(2)
                        .SetNumberOfShots(3)
                        .SetPenetrationPoints(1)
                        .SetRangePoints(4)
                        .Build();

                case WeaponModelId.Weapon2:
                    return new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(75)
                        .SetDamagePoints(4)
                        .SetNumberOfShots(2)
                        .SetPenetrationPoints(0)
                        .SetRangePoints(2)
                        .Build();

                case WeaponModelId.Weapon3:
                    return new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(95)
                        .SetDamagePoints(6)
                        .SetNumberOfShots(1)
                        .SetPenetrationPoints(2)
                        .SetRangePoints(3)
                        .Build();

                case WeaponModelId.Weapon4:
                    return new WeaponAttributesImpl.Builder()
                         .SetAccuracyPoints(105)
                         .SetDamagePoints(3)
                         .SetNumberOfShots(1)
                         .SetPenetrationPoints(4)
                         .SetRangePoints(5)
                         .Build();

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                        new StackFrame().GetMethod().Name, weaponModelId);
            }
        }
    }
}
