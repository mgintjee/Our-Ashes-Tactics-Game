namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using HappyBananaStudio.OurAshes.Tactics.Api.Weapons.Reports;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonActionResultFireReport
        : ITalonActionResultReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonAttributesReport GetTargetTalonAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IList<IWeaponResultReport> GetWeaponResultReportList();
    }
}