using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// </summary>
public static class WeaponAttributeConstants
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private static readonly Random random = new Random();

    // Todo
    private static readonly Dictionary<WeaponIdEnum, WeaponAttributes> WEAPON_ID_WEAPON_ATTRIBUTES_DICTIONARY = new Dictionary<WeaponIdEnum, WeaponAttributes>()
    {
        {WeaponIdEnum.Minigun, new WeaponAttributes.MinigunImpl()},
    };

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="weaponId"></param>
    /// <returns></returns>
    public static WeaponAttributes GetImplementedWeaponAttributes(WeaponIdEnum weaponId)
    {
        logger.Debug("Attempting to Get Implemented WeaponAttributes: WeaponIdEnum=?", weaponId);
        if (WEAPON_ID_WEAPON_ATTRIBUTES_DICTIONARY.ContainsKey(weaponId))
        {
            return WEAPON_ID_WEAPON_ATTRIBUTES_DICTIONARY[weaponId];
        }
        else
        {
            logger.Warn("Unable to get WeaponAttributes. WeaponIdEnum=? is not supported.", weaponId);
        }
        return null;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static WeaponIdEnum GetRandomWeaponId()
    {
        Array enumValues = Enum.GetValues(typeof(WeaponIdEnum));
        return (WeaponIdEnum)enumValues.GetValue(random.Next(enumValues.Length));
    }

    #endregion Public Methods
}