
namespace HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using System.Collections.Generic;

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
        ISet<ITalonIdentificationReport> GetActiveTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxId">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(PhalanxIdEnum phalanxId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="factionId">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(FactionIdEnum factionId);

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
