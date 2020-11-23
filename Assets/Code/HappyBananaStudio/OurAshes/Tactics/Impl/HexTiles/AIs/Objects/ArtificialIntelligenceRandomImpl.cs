namespace HappyBananaStudio.OurAshes.Tactics.Impl.HexTiles.AIs.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Workaround until I implement an actual AI
    /// </summary>
    public static class ArtificialIntelligenceRandomImpl

    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReportSet">
        /// </param>
        /// <returns>
        /// </returns>
        public static ITalonActionOrderReport DetermineBestAction(ISet<ITalonActionOrderReport> talonActionOrderReportSet)
        {
            if (talonActionOrderReportSet != null &&
                talonActionOrderReportSet.Count > 0)
            {
                int randomIndex = RandomNumberGeneratorUtil.GetNextInt(talonActionOrderReportSet.Count);
                return new List<ITalonActionOrderReport>(talonActionOrderReportSet)[randomIndex];
            }
            else
            {
                throw new ArgumentException("Unable to DetermineBestAction. Invalid Parameters." +
                    "\n\t>talonActionOrderReportSet is null/invalid: " +
                    (talonActionOrderReportSet == null || talonActionOrderReportSet.Count < 1));
            }
        }
    }
}