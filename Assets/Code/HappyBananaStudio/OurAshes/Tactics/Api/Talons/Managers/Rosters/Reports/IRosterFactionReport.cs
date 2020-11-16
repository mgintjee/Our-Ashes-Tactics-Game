

namespace HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using System.Collections.Generic;

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
        FactionId GetFactionId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<IRosterPhalanxReport> GetPhalanxReportSet();
    }
}
