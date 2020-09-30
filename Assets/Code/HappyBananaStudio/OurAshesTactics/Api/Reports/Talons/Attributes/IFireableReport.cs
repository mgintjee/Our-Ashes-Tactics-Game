/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Weapons;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IFireableReport
    {
        /// <summary>
        /// Get the current WeaponPoints
        /// </summary>
        /// <returns>
        /// The int current WeaponPoints
        /// </returns>
        int GetCurrentWeaponPoints();

        /// <summary>
        /// Get the maximum WeaponPoints
        /// </summary>
        /// <returns>
        /// The int maximum WeaponPoints
        /// </returns>
        int GetMaximumWeaponPoints();

        /// <summary>
        /// Get the List: WeaponInformationReport
        /// </summary>
        /// <returns>
        /// The List: WeaponInformationReport
        /// </returns>
        List<IWeaponInformationReport> GetWeaponInformationReportList();
    }
}