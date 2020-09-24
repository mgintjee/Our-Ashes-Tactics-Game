/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Manager
{
    /// <summary>
    /// Todo
    /// </summary>
    public class RosterObjectManager
    {
        #region Private Fields

        // Todo
        private static IRosterObject rosterObject;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetActiveTalonIdentificationReportSet();
            }
            else
            {
                throw new ArgumentException("Unable to GetActiveTalonIdentificationReportSet. " + typeof(IRosterObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetActiveTalonIdentificationReportSet();
            }
            else
            {
                throw new ArgumentException("Unable to GetAllTalonIdentificationReportSet. " + typeof(IRosterObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPhalanxId"></param>
        /// <returns></returns>
        public static HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet(TalonPhalanxIdEnum talonPhalanxId)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetActiveTalonIdentificationReportSet();
            }
            else
            {
                throw new ArgumentException("Unable to GetAllTalonIdentificationReportSet. " + typeof(IRosterObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonFactionId"></param>
        /// <returns></returns>
        public static HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet(TalonFactionIdEnum talonFactionId)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetActiveTalonIdentificationReportSet();
            }
            else
            {
                throw new ArgumentException("Unable to GetAllTalonIdentificationReportSet. " + typeof(IRosterObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static RosterInformationReport GetRosterInformationReport()
        {
            if (rosterObject != null)
            {
                return rosterObject.GetRosterInformationReport();
            }
            else
            {
                throw new ArgumentException("Unable to GetRosterInformationReport. " + typeof(IRosterObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newRosterObject"></param>
        public static void SetRosterObject(IRosterObject newRosterObject)
        {
            rosterObject = newRosterObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonControllerIdEnum GetTalonControllerId(TalonIdentificationReport talonIdentificationReport)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetTalonControllerId(talonIdentificationReport);
            }
            else
            {
                throw new ArgumentException("Unable to GetTalonControllerId. " + typeof(IRosterObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        public TalonInformationReport GetTalonInformationReport(TalonIdentificationReport talonIdentificationReport)
        {
            if (rosterObject != null)
            {
                return rosterObject.GetTalonInformationReport(talonIdentificationReport);
            }
            else
            {
                throw new ArgumentException("Unable to GetTalonInformationReport. " + typeof(IRosterObject) + " is null.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        public bool IsTalonIdentificationReportActive(TalonIdentificationReport talonIdentificationReport)
        {
            if (rosterObject != null)
            {
                return rosterObject.IsTalonIdentificationReportActive(talonIdentificationReport);
            }
            else
            {
                throw new ArgumentException("Unable to IsTalonIdentificationReportActive. " + typeof(IRosterObject) + " is null.");
            }
        }

        #endregion Public Methods
    }
}