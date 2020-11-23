namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Managers.Rosters.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterInformationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> GetActiveTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<IRosterFactionReport> GetRosterFactionReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> GetTotalTalonIdentificationReportSet();
    }
}