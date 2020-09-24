/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class WeaponPaintConstants
    {
        #region Private Fields

        // Todo
        private static readonly string WEAPON_KEYWORD = "Weapon";

        // Todo
        private static readonly string WEAPON_MODEL_NAME_MINIGUN = "Weapon0";

        // Todo
        private static readonly int WEAPON_MODEL_PAINT_INDEX_MINIGUN = 1;

        // Todo
        private static readonly Dictionary<string, int> WEAPON_NAME_PAINT_INDEX_DICTIONARY = new Dictionary<string, int>()
        {
            { WeaponIdEnum.Weapon0.ToString(), 0 },
            { WeaponIdEnum.Weapon1.ToString(), 0 },
            { WeaponIdEnum.Weapon2.ToString(), 0 },
            { WeaponIdEnum.Weapon3.ToString(), 0 },
            { WeaponIdEnum.Weapon4.ToString(), 0 },
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
}