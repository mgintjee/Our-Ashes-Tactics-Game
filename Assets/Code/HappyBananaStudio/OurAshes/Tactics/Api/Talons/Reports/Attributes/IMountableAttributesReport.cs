/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Utilities.Reports;
using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMountableAttributesReport
    {
        /// <summary>
        /// Get the current UtilityMountPoints
        /// </summary>
        /// <returns>
        /// The int current UtilityMountPoints
        /// </returns>
        int GetCurrentUtilityMountPoints();

        /// <summary>
        /// Get the current WeaponMountPoints
        /// </summary>
        /// <returns>
        /// The int current WeaponMountPoints
        /// </returns>
        int GetCurrentWeaponMountPoints();

        /// <summary>
        /// Get the maximum UtilityMountPoints
        /// </summary>
        /// <returns>
        /// The int maximum UtilityMountPoints
        /// </returns>
        int GetMaximumUtilityMountPoints();

        /// <summary>
        /// Get the maximum WeaponMountPoints
        /// </summary>
        /// <returns>
        /// The int maximum WeaponMountPoints
        /// </returns>
        int GetMaximumWeaponMountPoints();

        /// <summary>
        /// Get the List: IUtilityInformationReport
        /// </summary>
        /// <returns>
        /// The List: IUtilityInformationReport
        /// </returns>
        IList<IUtilityInformationReport> GetUtilityInformationReportList();

        /// <summary>
        /// Get the List: IWeaponInformationReport
        /// </summary>
        /// <returns>
        /// The List: IWeaponInformationReport
        /// </returns>
        IList<IWeaponInformationReport> GetWeaponInformationReportList();
    }
}
