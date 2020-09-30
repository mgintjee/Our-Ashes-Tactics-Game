/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonCombatResultReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        bool GetIsTargetDestroyed();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonCombatOrderReport GetTalonCombatOrderReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        List<IWeaponResultReport> GetWeaponResultReportList();
    }
}