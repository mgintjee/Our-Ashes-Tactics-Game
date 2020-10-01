/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Attributes.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Attributes.Weapons
{
    /// <summary>
    /// Todo
    /// </summary>
    public class WeaponAttributesConstants
    {
        // Todo
        private static readonly Dictionary<WeaponModelIdEnum, IWeaponAttributes> WEAPON_ID_ATTRIBUTES_DICTIONARY =
                new Dictionary<WeaponModelIdEnum, IWeaponAttributes>()
                {
                    {
                        WeaponModelIdEnum.Weapon0,
                        AttributesBuilder.Weapon.GetBuilder()
                            .SetAccuracyPoints(65)
                            .SetDamagePoints(1)
                            .SetNumberOfShots(8)
                            .SetPenetrationPoints(0)
                            .SetRangePoints(3)
                            .SetRangeProximityPoints(20)
                            .Build()
                    },
                    {
                        WeaponModelIdEnum.Weapon1,
                        AttributesBuilder.Weapon.GetBuilder()
                            .SetAccuracyPoints(85)
                            .SetDamagePoints(2)
                            .SetNumberOfShots(3)
                            .SetPenetrationPoints(1)
                            .SetRangePoints(4)
                            .SetRangeProximityPoints(10)
                            .Build()
                    },
                    {
                        WeaponModelIdEnum.Weapon2,
                        AttributesBuilder.Weapon.GetBuilder()
                            .SetAccuracyPoints(75)
                            .SetDamagePoints(4)
                            .SetNumberOfShots(2)
                            .SetPenetrationPoints(0)
                            .SetRangePoints(2)
                            .SetRangeProximityPoints(50)
                            .Build()
                    },
                    {
                        WeaponModelIdEnum.Weapon3,
                        AttributesBuilder.Weapon.GetBuilder()
                            .SetAccuracyPoints(95)
                            .SetDamagePoints(6)
                            .SetNumberOfShots(1)
                            .SetPenetrationPoints(2)
                            .SetRangePoints(3)
                            .SetRangeProximityPoints(5)
                            .Build()
                    },
                    {
                        WeaponModelIdEnum.Weapon4,
                        AttributesBuilder.Weapon.GetBuilder()
                            .SetAccuracyPoints(105)
                            .SetDamagePoints(3)
                            .SetNumberOfShots(1)
                            .SetPenetrationPoints(4)
                            .SetRangePoints(5)
                            .SetRangeProximityPoints(10)
                            .Build()
                    },
                };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="weaponId">
        /// </param>
        /// <returns>
        /// </returns>
        public static IWeaponAttributes GetAttributes(WeaponModelIdEnum weaponId)
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
        /// <returns>
        /// </returns>
        public static HashSet<WeaponModelIdEnum> GetSupportedWeaponIds()
        {
            return new HashSet<WeaponModelIdEnum>(WEAPON_ID_ATTRIBUTES_DICTIONARY.Keys);
        }
    }
}