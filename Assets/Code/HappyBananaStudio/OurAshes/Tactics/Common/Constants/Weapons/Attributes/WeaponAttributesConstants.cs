/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Attributes;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons.Enums;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using HappyBananaStudio.OurAshesTactics.Impl.Attributes.Weapons;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WeaponAttributesConstants
    {
        // Todo
        private static readonly IDictionary<WeaponModelIdEnum, IWeaponAttributes> weaponModelIdAttributesDictionary =
                new Dictionary<WeaponModelIdEnum, IWeaponAttributes>();

        // Todo
        private static readonly ISet<WeaponModelIdEnum> weaponModelIdSet = new HashSet<WeaponModelIdEnum>()
        {
            WeaponModelIdEnum.Weapon0,
            WeaponModelIdEnum.Weapon1,
            WeaponModelIdEnum.Weapon2,
            WeaponModelIdEnum.Weapon3,
            WeaponModelIdEnum.Weapon4,
        };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponModelId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IWeaponAttributes GetAttributes(WeaponModelIdEnum weaponModelId)
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
        public static ISet<WeaponModelIdEnum> GetSupportedWeaponIds()
        {
            return new HashSet<WeaponModelIdEnum>(weaponModelIdSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponModelId">
        /// </param>
        /// <returns>
        /// </returns>
        private static IWeaponAttributes BuildAttributes(WeaponModelIdEnum weaponModelId)
        {
            switch (weaponModelId)
            {
                case WeaponModelIdEnum.Weapon0:
                    return new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(65)
                        .SetDamagePoints(1)
                        .SetNumberOfShots(8)
                        .SetPenetrationPoints(0)
                        .SetRangePoints(3)
                        .Build();

                case WeaponModelIdEnum.Weapon1:
                    return new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(85)
                        .SetDamagePoints(2)
                        .SetNumberOfShots(3)
                        .SetPenetrationPoints(1)
                        .SetRangePoints(4)
                        .Build();

                case WeaponModelIdEnum.Weapon2:
                    return new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(75)
                        .SetDamagePoints(4)
                        .SetNumberOfShots(2)
                        .SetPenetrationPoints(0)
                        .SetRangePoints(2)
                        .Build();

                case WeaponModelIdEnum.Weapon3:
                    return new WeaponAttributesImpl.Builder()
                        .SetAccuracyPoints(95)
                        .SetDamagePoints(6)
                        .SetNumberOfShots(1)
                        .SetPenetrationPoints(2)
                        .SetRangePoints(3)
                        .Build();

                case WeaponModelIdEnum.Weapon4:
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
