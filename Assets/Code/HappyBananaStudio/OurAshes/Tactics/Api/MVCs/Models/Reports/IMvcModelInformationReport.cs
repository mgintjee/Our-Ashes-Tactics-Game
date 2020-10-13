/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;

namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Models.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcModelInformationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapInformationReport GetGameMapInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IRosterInformationReport GetRosterInformationReport();
    }
}
