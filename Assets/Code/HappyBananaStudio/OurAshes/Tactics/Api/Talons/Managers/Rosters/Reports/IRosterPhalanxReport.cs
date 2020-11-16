
namespace HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using System.Collections.Generic;

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
        FactionId GetFactionId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PhalanxId GetPhalanxId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> GetTalonIdentificationReportSet();
    }
}
