/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Api
{
    /// <summary>
    /// Roster Object Api
    /// </summary>
    public interface IRosterObject
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        void DeactivateTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPhalanxId"></param>
        /// <returns></returns>
        HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet(TalonPhalanxIdEnum talonPhalanxId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonFactionId"></param>
        /// <returns></returns>
        HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet(TalonFactionIdEnum talonFactionId);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IComparer<TalonIdentificationReport> GetOrderPointComparer();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        RosterInformationReport GetRosterInformationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonControllerIdEnum GetTalonControllerId(TalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        TalonInformationReport GetTalonInformationReport(TalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        ITalonObject GetTalonObject(TalonIdentificationReport talonIdentificationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        bool IsTalonIdentificationReportActive(TalonIdentificationReport talonIdentificationReport);

        #endregion Public Methods
    }
}