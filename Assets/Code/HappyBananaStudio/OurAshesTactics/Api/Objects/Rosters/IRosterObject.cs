/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Rosters
{
    /// <summary>
    /// Roster Object Api
    /// </summary>
    public interface IRosterObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void DeactivateTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HashSet<ITalonIdentificationReport> GetActiveTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxId">
        /// </param>
        /// <returns>
        /// </returns>
        HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(PhalanxIdEnum phalanxId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(FactionIdEnum factionId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IComparer<ITalonIdentificationReport> GetOrderPointComparer();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IRosterInformationReport GetRosterInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonInformationReport GetTalonInformationReport(ITalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonObject GetTalonObject(ITalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        bool IsTalonIdentificationReportActive(ITalonIdentificationReport talonIdentificationReport);
    }
}