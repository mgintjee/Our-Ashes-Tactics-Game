using System;
using System.Collections.Generic;

/// <summary>
/// </summary>
public static class WeaponAttributeConstants
{
    #region Private Fields

    // Todo
    private static readonly Random random = new Random();

    // Todo
    private static readonly Dictionary<WeaponIdEnum, WeaponAttributes> WEAPON_ID_WEAPON_ATTRIBUTES_DICTIONARY = new Dictionary<WeaponIdEnum, WeaponAttributes>()
    {
        {
            WeaponIdEnum.CreativeName1,
            new WeaponAttributes.Builder()
                .SetAccuracyPoints(65)
                .SetDamagePoints(1)
                .SetPenetrationPoints(0)
                .SetRangePoints(3)
                .SetRangeProximityPoints(30)
                .SetShotCountPoints(8)
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
        if (WEAPON_ID_WEAPON_ATTRIBUTES_DICTIONARY.ContainsKey(weaponId))
        {
            return WEAPON_ID_WEAPON_ATTRIBUTES_DICTIONARY[weaponId];
        }
        return null;
    }

    #endregion Public Methods
}