/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Phalanxes.Enums;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterPhalanxReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        FactionIdEnum GetFactionId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PhalanxIdEnum GetPhalanxId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> GetTalonIdentificationReportSet();
    }
}
