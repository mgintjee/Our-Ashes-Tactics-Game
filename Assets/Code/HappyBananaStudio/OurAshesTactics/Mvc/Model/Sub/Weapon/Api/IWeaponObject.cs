/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api
{
    /// <summary>
    /// Weapon Object Api
    /// </summary>
    public interface IWeaponObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPenalty"></param>
        /// <param name="targetRange">    </param>
        /// <returns></returns>
        WeaponCombatOrderReport GenerateWeaponCombatOrderReport(int accuracyPenalty, int targetRange);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWeaponBehavior GetWeaponBehavior();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponIdEnum GetWeaponId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        WeaponScript GetWeaponScript();

        /// <summary>
        /// Todo
        /// </summary>
        void Initialize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsInitialized();

        #endregion Public Methods
    }
}