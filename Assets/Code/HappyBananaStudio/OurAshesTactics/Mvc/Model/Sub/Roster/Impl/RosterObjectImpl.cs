/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Constants;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Impl
{
    /// <summary>
    /// Roster Object Impl
    /// </summary>
    public class RosterObjectImpl
    : IRosterObject
    {
        #region Private Fields

        // Provide logging capability
        private static readonly Common.Logging.Logger logger = new Common.Logging.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly HashSet<TalonIdentificationReport> activeTalonIdentificationReportSet =
            new HashSet<TalonIdentificationReport>();

        // Todo
        private readonly RosterConstructionReport rosterConstructionReport = null;

        // Todo
        private readonly RosterScript rosterScript = null;

        // Todo
        private readonly Dictionary<TalonIdentificationReport, TalonInformationReport> talonIdentificationInformationDictionary =
            new Dictionary<TalonIdentificationReport, TalonInformationReport>();

        // Todo
        private readonly Dictionary<TalonIdentificationReport, ITalonObject> talonIdentificationObjectDictionary =
            new Dictionary<TalonIdentificationReport, ITalonObject>();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterScript">            </param>
        /// <param name="rosterConstructionReport"></param>
        public RosterObjectImpl(RosterScript rosterScript, RosterConstructionReport rosterConstructionReport)
        {
            if (rosterScript != null &&
                rosterConstructionReport != null)
            {
                logger.Info("Contructing: ?", this.GetType());

                this.rosterScript = rosterScript;
                this.rosterConstructionReport = rosterConstructionReport;

                // Iterate over all of the TalonConstructionReports
                foreach (TalonConstructionReport talonConstructionReport in this.rosterConstructionReport.GetTalonConstructionReportSet())
                {
                    // Build the TalonObject
                    ITalonObject talonObject = TalonObjectBuilderUtil.BuildTalonObject(talonConstructionReport);
                    // Check that the TalonObject was built successfully
                    if (talonObject != null)
                    {
                        // Add the TalonObject to the Roster
                        this.AddTalonObject(talonObject);
                    }
                    else
                    {
                        logger.Error("Unable to add ?. ? produced null.", typeof(ITalonObject), talonConstructionReport);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(RosterScript) + " is null: " + (rosterScript == null) +
                    "\n\t>" + typeof(RosterConstructionReport) + " is null: " + (rosterConstructionReport == null));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        public void DeactivateTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
        {
            if (this.activeTalonIdentificationReportSet.Contains(talonIdentificationReport))
            {
                this.activeTalonIdentificationReportSet.Remove(talonIdentificationReport);
            }
            else
            {
                logger.Warn("Unable to RemoveActiveTalonIdentificationReport. ? is not tracked.", talonIdentificationReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet()
        {
            return new HashSet<TalonIdentificationReport>(this.activeTalonIdentificationReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet()
        {
            return new HashSet<TalonIdentificationReport>(this.talonIdentificationObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPhalanxId"></param>
        /// <returns></returns>
        public HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet(TalonPhalanxIdEnum talonPhalanxId)
        {
            // Default an empty set
            HashSet<TalonIdentificationReport> talonObjectSet = new HashSet<TalonIdentificationReport>();
            // Iterate over the TalonIdentificationReports
            foreach (TalonIdentificationReport talonIdentificationReport in this.talonIdentificationObjectDictionary.Keys)
            {
                // Check if the TalonPhalanxId matches
                if (talonIdentificationReport.GetTalonPhalanxId().Equals(talonPhalanxId))
                {
                    // Add the TalonObject to the set
                    talonObjectSet.Add(talonIdentificationReport);
                }
            }
            return talonObjectSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonFactionId"></param>
        /// <returns></returns>
        public HashSet<TalonIdentificationReport> GetAllTalonIdentificationReportSet(TalonFactionIdEnum talonFactionId)
        {
            // Default an empty set
            HashSet<TalonIdentificationReport> talonObjectSet = new HashSet<TalonIdentificationReport>();
            // Iterate over the TalonIdentificationReports
            foreach (TalonIdentificationReport talonIdentificationReport in this.talonIdentificationObjectDictionary.Keys)
            {
                // Check if the TalonFactionId matches
                if (talonIdentificationReport.GetTalonFactionId().Equals(talonFactionId))
                {
                    // Add the TalonObject to the set
                    talonObjectSet.Add(talonIdentificationReport);
                }
            }
            return talonObjectSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public List<TalonIdentificationReport> GetOrderedTalonIdentificationReportList()
        {
            return this.activeTalonIdentificationReportSet.OrderByDescending(
                talonIdentificationReport => this.GetTalonOrderPoints(talonIdentificationReport)).ToList();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public RosterInformationReport GetRosterInformationReport()
        {
            return new RosterInformationReport.Builder()
                .SetActiveTalonIdentificationReportSet(this.activeTalonIdentificationReportSet)
                .SetTotalTalonIdentificationReportSet(new HashSet<TalonIdentificationReport>(this.talonIdentificationObjectDictionary.Keys))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        public TalonControllerIdEnum GetTalonControllerId(TalonIdentificationReport talonIdentificationReport)
        {
            foreach (TalonControllerIdEnum controllerId in this.rosterConstructionReport.GetTalonControllerPhalanxSetDictionary().Keys)
            {
                if (this.rosterConstructionReport.GetTalonControllerPhalanxSetDictionary()[controllerId]
                    .Contains(talonIdentificationReport.GetTalonPhalanxId()))
                {
                    return controllerId;
                }
            }
            logger.Warn("Unable to GetTalonOrderPoints. ? is not tracked.", talonIdentificationReport);
            return TalonControllerIdEnum.NULL;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        public TalonInformationReport GetTalonInformationReport(TalonIdentificationReport talonIdentificationReport)
        {
            // Check that the activeTalonIdentificationReportSet contains the TalonIdentificationReport
            if (this.activeTalonIdentificationReportSet.Contains(talonIdentificationReport))
            {
                // Check that the TalonIdentificationObjectDictionary contains the TalonIdentificationReport
                if (this.talonIdentificationObjectDictionary.ContainsKey(talonIdentificationReport))
                {
                    if (!this.talonIdentificationInformationDictionary.ContainsKey(talonIdentificationReport))
                    {
                        logger.Debug("Caching ? for ?", typeof(TalonInformationReport), talonIdentificationReport);
                        this.talonIdentificationInformationDictionary.Add(talonIdentificationReport,
                            this.talonIdentificationObjectDictionary[talonIdentificationReport].GetTalonInformationReport());
                    }
                    return this.talonIdentificationInformationDictionary[talonIdentificationReport];
                }
                else
                {
                    logger.Warn("Unable to GetTalonInformationReport. talonIdentificationObjectDictionary does not have ?", talonIdentificationReport);
                }
            }
            else
            {
                logger.Warn("Unable to GetTalonInformationReport. activeTalonIdentificationReportSet does not have ?", talonIdentificationReport);
            }
            return null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        public ITalonObject GetTalonObject(TalonIdentificationReport talonIdentificationReport)
        {
            ITalonObject talonObject = null;
            if (this.talonIdentificationObjectDictionary.ContainsKey(talonIdentificationReport))
            {
                talonObject = this.talonIdentificationObjectDictionary[talonIdentificationReport];
            }
            else
            {
                logger.Warn("Unable to GetTalonObject. ? is not tracked", talonIdentificationReport);
            }
            return talonObject;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        public bool IsTalonIdentificationReportActive(TalonIdentificationReport talonIdentificationReport)
        {
            return this.activeTalonIdentificationReportSet.Contains(talonIdentificationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ResetAllTalonBehaviorMoveable()
        {
            // Iterate over all of the Active TalonIdentificationReport
            foreach (TalonIdentificationReport talonIdentificationReport in this.activeTalonIdentificationReportSet)
            {
                // Check that the TalonIdentificationObjectDictionary contains the TalonIdentificationReport
                if (this.talonIdentificationObjectDictionary.ContainsKey(talonIdentificationReport))
                {
                    // Rest the TalonBehaviorMoveable
                    this.talonIdentificationObjectDictionary[talonIdentificationReport].ResetTalonBehaviorMoveable();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void ResetAllTalonInformationReport()
        {
            logger.Debug("ResetTalonInformationReportCollection");
            this.talonIdentificationInformationDictionary.Clear();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject"></param>
        private void AddTalonObject(ITalonObject talonObject)
        {
            // Check that the TalonObject is non-null
            if (talonObject != null)
            {
                // Get the TalonInformationReport from the TalonObject
                TalonInformationReport talonInformationReport = talonObject.GetTalonInformationReport();
                // Get the TalonIdentificationReport from the TalonInformationReport
                TalonIdentificationReport talonIdentificationReport = talonInformationReport.GetTalonIdentificationReport();
                // Check that the TalonIdentificationReport is non-null
                if (talonIdentificationReport != null)
                {
                    // Add the TalonIdentificationReport to the activeTalonIdentificationReportList
                    this.activeTalonIdentificationReportSet.Add(talonIdentificationReport);
                    // Add the TalonIdentificationReport to the activeTalonIdentificationReportList
                    this.talonIdentificationObjectDictionary.Add(talonIdentificationReport, talonObject);
                    // Get the Transform for this Roster
                    Transform rosterTransform = this.rosterScript.GetGameObject().transform;
                    // Get the Transform for the FactionId
                    Transform factionTransform = rosterTransform.Find(RosterConstants.Script.GetFactionIdGameObjectPrefix() + talonIdentificationReport.GetTalonFactionId());
                    // Check that the Transform is non-null
                    if (factionTransform != null)
                    {
                        Transform phalanxTransform = factionTransform.Find(RosterConstants.Script.GetPhalanxIdGameObjectPrefix() + talonIdentificationReport.GetTalonPhalanxId());
                        // Check that the Transform is non-null
                        if (phalanxTransform != null)
                        {
                            talonObject.GetTalonScript().GetGameObject().transform.SetParent(phalanxTransform);
                        }
                        else
                        {
                            logger.Error("Unable to add ?. Unable to find ?.", typeof(ITalonObject),
                                RosterConstants.Script.GetPhalanxIdGameObjectPrefix() + talonIdentificationReport.GetTalonPhalanxId());
                        }
                    }
                    else
                    {
                        logger.Error("Unable to add ?. Unable to find ?.", typeof(ITalonObject),
                            RosterConstants.Script.GetFactionIdGameObjectPrefix() + talonIdentificationReport.GetTalonFactionId());
                    }
                }
                else
                {
                    logger.Error("Unable to add ?. ? is null.", typeof(ITalonObject), typeof(TalonIdentificationReport));
                }
            }
            else
            {
                logger.Error("Unable to add ?. ? is null.", typeof(ITalonObject), typeof(ITalonObject));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport"></param>
        /// <returns></returns>
        private int GetTalonOrderPoints(TalonIdentificationReport talonIdentificationReport)
        {
            int talonOrderPoints = int.MinValue;
            ITalonObject talonObject = this.GetTalonObject(talonIdentificationReport);
            if (talonObject != null)
            {
                // Get the TalonInformationReport from the TalonObject
                TalonInformationReport talonInformationReport = talonObject.GetTalonInformationReport();
                // Get the TalonAttributesReport from the TalonInformationReport
                TalonAttributesReport talonAttributesReport = talonInformationReport.GetTalonAttributesReport();
                // Collect the Current OrderPoints from the TalonAttributesReport
                talonOrderPoints = talonAttributesReport.GetCurrentOrderPoints();
            }
            else
            {
                logger.Warn("Unable to GetTalonOrderPoints. ? is not tracked.", talonIdentificationReport);
            }
            return talonOrderPoints;
        }

        #endregion Private Methods
    }
}