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
    public interface ITalonCombatOrderReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        List<IWeaponOrderReport> GetWeaponOrderReportList();
    }
}