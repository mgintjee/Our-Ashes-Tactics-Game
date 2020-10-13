/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.AIs.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using System.Collections.Generic;

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
        ITalonActionOrderReport DetermineBestAction(ISet<ITalonActionOrderReport> talonActionOrderReportSet);
    }
}
