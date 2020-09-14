/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api
{
    /// <summary>
    /// Weapon Behvaior Api
    /// </summary>
    public interface IWeaponBehavior
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPenalty"></param>
        /// <param name="targetRange">    </param>
        /// <returns></returns>
        WeaponCombatOrderReport GenerateWeaponReport(int accuracyPenalty, int targetRange);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetRange"></param>
        /// <returns></returns>
        int GetMaxAccuracyPenalty(int targetRange);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponAttributes GetWeaponAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponIdEnum GetWeaponId();

        #endregion Public Methods
    }
}