/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Phalanxes.Enums;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterConstructionReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<FactionIdEnum, ISet<PhalanxIdEnum>> GetFactionIdPhalanxIdSetIDictionary();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDictionary<PhalanxIdEnum, ISet<ITalonConstructionReport>> GetPhalanxIdTalonConstructionReportIDictionary();
    }
}
