/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.AIs
{
    /// <summary>
    /// Workaround until I implement an actual AI
    /// </summary>
    public interface IArtificialIntelligence
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReportSet">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonActionOrderReport DetermineBestAction(HashSet<ITalonActionOrderReport> talonActionOrderReportSet);
    }
}