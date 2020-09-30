/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Builders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.Rosters;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Roster.Comparer;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Roster.Objects
{
    /// <summary>
    /// Roster Object Impl
    /// </summary>
    public class RosterObjectImpl
    : IRosterObject
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly HashSet<ITalonIdentificationReport> activeTalonIdentificationReportSet =
            new HashSet<ITalonIdentificationReport>();

        // Todo
        private readonly IRosterConstructionReport rosterConstructionReport = null;

        // Todo
        private readonly IRosterScript rosterScript = null;

        // Todo
        private readonly Dictionary<ITalonIdentificationReport, ITalonInformationReport> talonIdentificationInformationDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonInformationReport>();

        // Todo
        private readonly Dictionary<ITalonIdentificationReport, ITalonObject> talonIdentificationObjectDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterScript">
        /// </param>
        /// <param name="rosterConstructionReport">
        /// </param>
        public RosterObjectImpl(IRosterScript rosterScript, IRosterConstructionReport rosterConstructionReport)
        {
            // Check that the parameters are non-null
            if (rosterScript != null &&
                rosterConstructionReport != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                // Set the RosterScript
                this.rosterScript = rosterScript;
                // Set the RosterConstructionReport
                this.rosterConstructionReport = rosterConstructionReport;
                // Iterate over the registered Factions
                foreach (FactionIdEnum factionId in this.rosterConstructionReport.GetFactionIdPhalanxIdSetDictionary().Keys)
                {
                    // Iterate over the Phalanxes
                    foreach (PhalanxIdEnum phalanxId in this.rosterConstructionReport.GetFactionIdPhalanxIdSetDictionary()[factionId])
                    {
                        // Iterate over the TalonConstructionReports
                        foreach (ITalonConstructionReport talonConstructionReport in this.rosterConstructionReport.GetPhalanxIdTalonConstructionReportDictionary()[phalanxId])
                        {
                            // Build the TalonObject
                            ITalonObject talonObject = TalonObjectBuilderUtil.BuildTalonObject(factionId, phalanxId, talonConstructionReport);
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
                }
                RosterObjectManager.SetRosterObject(this);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters." +
                    "\n\t> ? is null: ?" +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IRosterScript), (rosterScript == null),
                    typeof(IRosterConstructionReport), (rosterConstructionReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        public void DeactivateTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
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
        /// <returns>
        /// </returns>
        public HashSet<ITalonIdentificationReport> GetActiveTalonIdentificationReportSet()
        {
            return new HashSet<ITalonIdentificationReport>(this.activeTalonIdentificationReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet()
        {
            return new HashSet<ITalonIdentificationReport>(this.talonIdentificationObjectDictionary.Keys);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonPhalanxId">
        /// </param>
        /// <returns>
        /// </returns>
        public HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(PhalanxIdEnum talonPhalanxId)
        {
            // Default an empty set
            HashSet<ITalonIdentificationReport> talonObjectSet = new HashSet<ITalonIdentificationReport>();
            // Iterate over the TalonIdentificationReports
            foreach (ITalonIdentificationReport talonIdentificationReport in this.GetAllTalonIdentificationReportSet())
            {
                // Check if the TalonPhalanxId matches
                if (talonIdentificationReport.GetPhalanxId().Equals(talonPhalanxId))
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
        /// <param name="talonFactionId">
        /// </param>
        /// <returns>
        /// </returns>
        public HashSet<ITalonIdentificationReport> GetAllTalonIdentificationReportSet(FactionIdEnum talonFactionId)
        {
            // Default an empty set
            HashSet<ITalonIdentificationReport> talonObjectSet = new HashSet<ITalonIdentificationReport>();
            // Iterate over the TalonIdentificationReports
            foreach (ITalonIdentificationReport talonIdentificationReport in this.GetAllTalonIdentificationReportSet())
            {
                // Check if the TalonFactionId matches
                if (talonIdentificationReport.GetFactionId().Equals(talonFactionId))
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
        /// <returns>
        /// </returns>
        public IComparer<ITalonIdentificationReport> GetOrderPointComparer()
        {
            return new OrderPointComparer<ITalonIdentificationReport>(this);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IRosterInformationReport GetRosterInformationReport()
        {
            return ReportBuilder.Roster.Information.GetBuilder()
                .SetActiveTalonIdentificationReportSet(this.activeTalonIdentificationReportSet)
                .SetTotalTalonIdentificationReportSet(new HashSet<ITalonIdentificationReport>(this.talonIdentificationObjectDictionary.Keys))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonInformationReport GetTalonInformationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            // Check that the activeTalonIdentificationReportSet contains the TalonIdentificationReport
            if (this.activeTalonIdentificationReportSet.Contains(talonIdentificationReport))
            {
                // Check that the TalonIdentificationObjectDictionary contains the TalonIdentificationReport
                if (this.talonIdentificationObjectDictionary.ContainsKey(talonIdentificationReport))
                {
                    if (!this.talonIdentificationInformationDictionary.ContainsKey(talonIdentificationReport))
                    {
                        logger.Debug("Caching ? for ?", typeof(ITalonInformationReport), talonIdentificationReport);
                        this.talonIdentificationInformationDictionary.Add(talonIdentificationReport,
                            this.talonIdentificationObjectDictionary[talonIdentificationReport].GetTalonInformationReport());
                    }
                    return this.talonIdentificationInformationDictionary[talonIdentificationReport];
                }
                else
                {
                    logger.Warn("Unable to GetTalonInformationReport. talonIdentificationObjectDictionary does not have ?",
                        talonIdentificationReport);
                }
            }
            else
            {
                logger.Warn("Unable to GetTalonInformationReport. activeTalonIdentificationReportSet does not have ?",
                    talonIdentificationReport);
            }
            return null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public ITalonObject GetTalonObject(ITalonIdentificationReport talonIdentificationReport)
        {
            ITalonObject talonObject = null;
            if (this.talonIdentificationObjectDictionary.ContainsKey(talonIdentificationReport))
            {
                return this.talonIdentificationObjectDictionary[talonIdentificationReport];
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
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public bool IsTalonIdentificationReportActive(ITalonIdentificationReport talonIdentificationReport)
        {
            return talonIdentificationReport != null &&
                this.activeTalonIdentificationReportSet.Contains(talonIdentificationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">
        /// </param>
        private void AddTalonObject(ITalonObject talonObject)
        {
            // Check that the TalonObject is non-null
            if (talonObject != null)
            {
                // Get the TalonInformationReport from the TalonObject
                ITalonInformationReport talonInformationReport = talonObject.GetTalonInformationReport();
                // Get the TalonIdentificationReport from the TalonInformationReport
                ITalonIdentificationReport talonIdentificationReport = talonInformationReport.GetTalonIdentificationReport();
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
                    Transform factionTransform = rosterTransform.Find(RosterConstants.Script.GetFactionIdGameObjectPrefix() + talonIdentificationReport.GetFactionId());
                    // Check that the Transform is non-null
                    if (factionTransform != null)
                    {
                        Transform phalanxTransform = factionTransform.Find(RosterConstants.Script.GetPhalanxIdGameObjectPrefix() + talonIdentificationReport.GetPhalanxId());
                        // Check that the Transform is non-null
                        if (phalanxTransform != null)
                        {
                            talonObject.GetTalonScript().GetGameObject().transform.SetParent(phalanxTransform);
                        }
                        else
                        {
                            throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. Cannot find: \"?\"." +
                                "\n\t> ? is null: ?", new StackFrame().GetMethod().Name,
                                (RosterConstants.Script.GetPhalanxIdGameObjectPrefix() + talonIdentificationReport.GetPhalanxId()));
                        }
                    }
                    else
                    {
                        throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. Cannot find: \"?\"." +
                            "\n\t> ? is null: ?", new StackFrame().GetMethod().Name,
                            (RosterConstants.Script.GetFactionIdGameObjectPrefix() + talonIdentificationReport.GetPhalanxId()));
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null." +
                        "\n\t> ? is null: ?", new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport));
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ? is null." +
                    "\n\t> ? is null: ?", new StackFrame().GetMethod().Name, typeof(ITalonObject));
            }
        }
    }
}