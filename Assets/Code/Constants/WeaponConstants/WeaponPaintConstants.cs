using System.Collections.Generic;

/// <summary>
/// </summary>
public static class WeaponPaintConstants
{
    #region Private Fields

    private static readonly string WEAPON_KEYWORD = "Weapon";
    private static readonly string WEAPON_MODEL_NAME_MINIGUN = "WeaponMinigunModel";
    private static readonly int WEAPON_MODEL_PAINT_INDEX_MINIGUN = 1;

    private static readonly Dictionary<string, int> WEAPON_NAME_PAINT_INDEX_DICTIONARY = new Dictionary<string, int>()
    {
        { WEAPON_MODEL_NAME_MINIGUN, WEAPON_MODEL_PAINT_INDEX_MINIGUN },
    };

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="weaponPartName"></param>
    /// <returns></returns>
    public static int GetPaintIndexForWeaponName(string weaponPartName)
    {
        return (WEAPON_NAME_PAINT_INDEX_DICTIONARY.ContainsKey(weaponPartName))
            ? WEAPON_NAME_PAINT_INDEX_DICTIONARY[weaponPartName]
            : -1;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string GetWeaponKeyword()
    {
        return WEAPON_KEYWORD;
    }

    #endregion Public Methods
}