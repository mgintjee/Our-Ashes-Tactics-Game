/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponAttributesConstants
    {
        #region Private Fields


        // Todo
        private static readonly Dictionary<WeaponIdEnum, WeaponAttributes> WEAPON_ID_ATTRIBUTES_DICTIONARY = new Dictionary<WeaponIdEnum, WeaponAttributes>()
        {
            {
                WeaponIdEnum.Weapon0,
                new WeaponAttributes.Builder()
                    .SetAccuracyPoints(65)
                    .SetDamagePoints(1)
                    .SetPenetrationPoints(0)
                    .SetRangePoints(3)
                    .SetRangeProximityPoints(20)
                    .SetShotCountPoints(8)
                    .Build()
            },
            {
                WeaponIdEnum.Weapon1,
                new WeaponAttributes.Builder()
                    .SetAccuracyPoints(85)
                    .SetDamagePoints(2)
                    .SetPenetrationPoints(1)
                    .SetRangePoints(4)
                    .SetRangeProximityPoints(10)
                    .SetShotCountPoints(3)
                    .Build()
            },
            {
                WeaponIdEnum.Weapon2,
                new WeaponAttributes.Builder()
                    .SetAccuracyPoints(75)
                    .SetDamagePoints(4)
                    .SetPenetrationPoints(0)
                    .SetRangePoints(2)
                    .SetRangeProximityPoints(50)
                    .SetShotCountPoints(2)
                    .Build()
            },
            {
                WeaponIdEnum.Weapon3,
                new WeaponAttributes.Builder()
                    .SetAccuracyPoints(95)
                    .SetDamagePoints(6)
                    .SetPenetrationPoints(2)
                    .SetRangePoints(3)
                    .SetRangeProximityPoints(5)
                    .SetShotCountPoints(1)
                    .Build()
            },
            {
                WeaponIdEnum.Weapon4,
                new WeaponAttributes.Builder()
                    .SetAccuracyPoints(105)
                    .SetDamagePoints(3)
                    .SetPenetrationPoints(4)
                    .SetRangePoints(5)
                    .SetRangeProximityPoints(10)
                    .SetShotCountPoints(1)
                    .Build()
            },
        };

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public static WeaponAttributes GetImplementedWeaponAttributes(WeaponIdEnum weaponId)
        {
            if (WEAPON_ID_ATTRIBUTES_DICTIONARY.ContainsKey(weaponId))
            {
                return WEAPON_ID_ATTRIBUTES_DICTIONARY[weaponId];
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is not supported.",
                    new StackFrame().GetMethod().Name, weaponId);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static HashSet<WeaponIdEnum> GetSupportedWeaponIds()
        {
            return new HashSet<WeaponIdEnum>(WEAPON_ID_ATTRIBUTES_DICTIONARY.Keys);
        }

        #endregion Public Methods
    }
}