/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterFactionReport
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
        ISet<IRosterPhalanxReport> GetPhalanxReportSet();
    }
}
