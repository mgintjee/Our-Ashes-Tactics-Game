/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Faction;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters

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
        HashSet<ITalonIdentificationReport> GetActiveTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HashSet<IFactionReport> GetFactionReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HashSet<ITalonIdentificationReport> GetTotalTalonIdentificationReportSet();
    }
}