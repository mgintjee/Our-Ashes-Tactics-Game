/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports

{
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
