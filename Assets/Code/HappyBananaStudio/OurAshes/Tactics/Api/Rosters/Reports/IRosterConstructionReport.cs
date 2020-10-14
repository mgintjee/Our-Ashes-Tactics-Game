
namespace HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using System.Collections.Generic;

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
