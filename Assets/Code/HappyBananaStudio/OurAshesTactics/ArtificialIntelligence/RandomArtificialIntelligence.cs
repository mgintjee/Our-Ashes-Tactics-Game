/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Util.RandomNumberGenerator;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.ArtificialIntelligence.Api
{
    /// <summary>
    /// Workaround until I implement an actual AI
    /// </summary>
    public static class RandomArtificialIntelligence
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReportSet"></param>
        /// <returns></returns>
        public static TalonActionOrderReport DetermineBestAction(HashSet<TalonActionOrderReport> talonActionOrderReportSet)
        {
            if (talonActionOrderReportSet != null &&
                talonActionOrderReportSet.Count > 0)
            {
                int randomIndex = RandomNumberGeneratorUtil.GetNextInt(talonActionOrderReportSet.Count);
                return new List<TalonActionOrderReport>(talonActionOrderReportSet)[randomIndex];
            }
            else
            {
                throw new ArgumentException("Unable to DetermineBestAction. Invalid Parameters." +
                    "\n\t>talonActionOrderReportSet is null/invalid: " +
                    (talonActionOrderReportSet == null || talonActionOrderReportSet.Count < 1));
            }
        }

        #endregion Public Methods
    }
}