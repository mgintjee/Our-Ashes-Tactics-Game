/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Weapons.Behaviors
{
    /// <summary>
    /// Weapon Behavior Api
    /// </summary>
    public interface IWeaponBehavior
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
        IWeaponOrderReport GenerateWeaponReport(int accuracyPenalty, int targetRange);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetRange">
        /// </param>
        /// <returns>
        /// </returns>
        int GetMaxAccuracyPenalty(int targetRange);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IWeaponInformationReport GetWeaponInformationReport();
    }
}