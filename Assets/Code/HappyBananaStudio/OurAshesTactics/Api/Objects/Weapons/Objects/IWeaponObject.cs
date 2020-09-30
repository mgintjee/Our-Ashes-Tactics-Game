/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Behaviors;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Weapons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Objects
{
    /// <summary>
    /// Weapon Object Api
    /// </summary>
    public interface IWeaponObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="accuracyPenalty">
        /// </param>
        /// <param name="targetRange">
        /// </param>
        /// <returns>
        /// </returns>
        IWeaponOrderReport GenerateWeaponCombatOrderReport(int accuracyPenalty, int targetRange);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponBehavior GetWeaponBehavior();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        WeaponIdEnum GetWeaponId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponScript GetWeaponScript();

        /// <summary>
        /// Todo
        /// </summary>
        void Initialize();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool IsInitialized();
    }
}