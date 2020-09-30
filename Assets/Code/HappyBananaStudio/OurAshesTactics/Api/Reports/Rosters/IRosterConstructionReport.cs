/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters
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
        Dictionary<FactionIdEnum, HashSet<PhalanxIdEnum>> GetFactionIdPhalanxIdSetDictionary();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        Dictionary<PhalanxIdEnum, HashSet<ITalonConstructionReport>> GetPhalanxIdTalonConstructionReportDictionary();
    }
}