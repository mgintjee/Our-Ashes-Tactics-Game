/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons.Enums;
using System.Collections.Generic;

/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
namespace HappyBananaStudio.OurAshes.Tactics.Common.Constants.Weapons
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponPaintConstants
    {
        // Todo
        private static readonly string WEAPON_KEYWORD = "Weapon";

        // Todo
        private static readonly string WEAPON_MODEL_NAME_MINIGUN = "Weapon0";

        // Todo
        private static readonly int WEAPON_MODEL_PAINT_INDEX_MINIGUN = 1;

        // Todo
        private static readonly IDictionary<string, int> WEAPON_NAME_PAINT_INDEX_DICTIONARY = new Dictionary<string, int>()
        {
            { WeaponModelIdEnum.Weapon0.ToString(), 0 },
            { WeaponModelIdEnum.Weapon1.ToString(), 0 },
            { WeaponModelIdEnum.Weapon2.ToString(), 0 },
            { WeaponModelIdEnum.Weapon3.ToString(), 0 },
            { WeaponModelIdEnum.Weapon4.ToString(), 0 },
        };

        /// <summary>
        /// </summary>
        /// <param name="weaponPartName">
        /// </param>
        /// <returns>
        /// </returns>
        public static int GetPaintIndexForWeaponName(string weaponPartName)
        {
            return (WEAPON_NAME_PAINT_INDEX_DICTIONARY.ContainsKey(weaponPartName))
                ? WEAPON_NAME_PAINT_INDEX_DICTIONARY[weaponPartName]
                : -1;
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static string GetWeaponKeyword()
        {
            return WEAPON_KEYWORD;
        }
    }
}
