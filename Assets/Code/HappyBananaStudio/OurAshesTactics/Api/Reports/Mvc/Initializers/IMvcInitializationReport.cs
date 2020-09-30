/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Mvc.Initializers
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcInitializationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapConstructionReport GetGameMapConstructionReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int GetGameRNGSeed();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IRosterConstructionReport GetRosterConstructionReport();
    }
}