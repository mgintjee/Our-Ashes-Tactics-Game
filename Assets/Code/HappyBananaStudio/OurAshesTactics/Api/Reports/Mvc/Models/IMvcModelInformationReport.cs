/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Models
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
        IGameMapInformationReport GetMapInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IRosterInformationReport GetRosterInformationReport();
    }
}