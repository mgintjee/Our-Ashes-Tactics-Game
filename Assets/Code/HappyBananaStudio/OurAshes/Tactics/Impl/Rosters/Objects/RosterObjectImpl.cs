/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Objects;
using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Phalanxes.Enums;
using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using HappyBananaStudio.OurAshesTactics.Impl.Objects.Rosters.Comparer;
using HappyBananaStudio.OurAshesTactics.Impl.Objects.Talons;
using HappyBananaStudio.OurAshesTactics.Impl.Reports.Rosters;
using System.Collections.Generic;
using System.Diagnostics;

namespace HappyBananaStudio.OurAshesTactics.Impl.Objects.Rosters
{
    /// <summary>
    /// Roster Object Impl
    /// </summary>
    public class RosterObjectImpl
    : IRosterObject
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ISet<ITalonIdentificationReport> activeTalonIdentificationReportSet =
            new HashSet<ITalonIdentificationReport>();

        // Todo
        private readonly IRosterConstructionReport rosterConstructionReport = null;

        // Todo
        private readonly IDictionary<ITalonIdentificationReport, ITalonInformationReport> talonIdentificationInformationDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonInformationReport>();

        // Todo
        private readonly IDictionary<ITalonIdentificationReport, ITalonObject> talonIdentificationObjectDictionary =
            new Dictionary<ITalonIdentificationReport, ITalonObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterScript">
        /// </param>
        /// <param name="rosterConstructionReport">
        /// </param>
        public RosterObjectImpl(IRosterConstructionReport rosterConstructionReport)
        {
            // Check that the parameters are non-null
            if (rosterConstructionReport != null)
            {
                logger.Info("Constructing: ?", this.GetType());
                // Set the RosterConstructionReport
                this.rosterConstructionReport = rosterConstructionReport;
                logger.Info("?", rosterConstructionReport);
                // Iterate over the registered Factions
                foreach (FactionIdEnum factionId in this.rosterConstructionReport.GetFactionIdPhalanxIdSetIDictionary().Keys)
                {
                    logger.Info("Building ?'s ?s", factionId, typeof(ITalonConstructionReport));
                    // Iterate over the Phalanxes
                    foreach (PhalanxIdEnum phalanxId in this.rosterConstructionReport.GetFactionIdPhalanxIdSetIDictionary()[factionId])
                    {
                        logger.Info("Building ?'s ?s", phalanxId, typeof(ITalonConstructionReport));
                        // Iterate over the TalonConstructionReports
                        foreach (ITalonConstructionReport talonConstructionReport in this.rosterConstructionReport.GetPhalanxIdTalonConstructionReportIDictionary()[phalanxId])
                        {
                            logger.Info("Building ?", talonConstructionReport);
                            this.AddTalonObject(new TalonObjectImpl(talonConstructionReport));
                        }
                    }
                }
                RosterObjectManager.SetRosterObject(this);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters." +
                    "\n\t> ? is null: ?", this.GetType(),
                    typeof(IRosterConstructionReport), (rosterConstructionReport == null));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        void IRosterObject.DeactivateTalonIdentificationReport(ITalonIdentificationReport talonIdentificationReport)
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
        ISet<ITalonIdentificationReport> IRosterObject.GetActiveTalonIdentificationReportSet()
        {
            return new HashSet<ITalonIdentificationReport>(this.activeTalonIdentificationReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonIdentificationReport> IRosterObject.GetAllTalonIdentificationReportSet()
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
        ISet<ITalonIdentificationReport> IRosterObject.GetAllTalonIdentificationReportSet(PhalanxIdEnum talonPhalanxId)
        {
            // Default an empty set
            ISet<ITalonIdentificationReport> talonObjectSet = new HashSet<ITalonIdentificationReport>();
            // Iterate over the TalonIdentificationReports
            foreach (ITalonIdentificationReport talonIdentificationReport in this.talonIdentificationObjectDictionary.Keys)
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
        ISet<ITalonIdentificationReport> IRosterObject.GetAllTalonIdentificationReportSet(FactionIdEnum talonFactionId)
        {
            // Default an empty set
            ISet<ITalonIdentificationReport> talonObjectSet = new HashSet<ITalonIdentificationReport>();
            // Iterate over the TalonIdentificationReports
            foreach (ITalonIdentificationReport talonIdentificationReport in this.talonIdentificationObjectDictionary.Keys)
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
        IComparer<ITalonIdentificationReport> IRosterObject.GetOrderPointComparer()
        {
            return new OrderPointComparer<ITalonIdentificationReport>(this);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IRosterInformationReport IRosterObject.GetRosterInformationReport()
        {
            return new RosterInformationReportImpl.Builder()
                .SetActiveTalonIdentificationReportSet(this.activeTalonIdentificationReportSet)
                .SetTotalTalonIdentificationReportSet(new HashSet<ITalonIdentificationReport>(
                    this.talonIdentificationObjectDictionary.Keys))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonInformationReport IRosterObject.GetTalonInformationReport(ITalonIdentificationReport talonIdentificationReport)
        {
            // Check that the activeTalonIdentificationReportSet contains the TalonIdentificationReport
            if (this.activeTalonIdentificationReportSet.Contains(talonIdentificationReport))
            {
                // Check that the TalonIdentificationObjectIDictionary contains the TalonIdentificationReport
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
                    logger.Warn("Unable to GetTalonInformationReport. talonIdentificationObjectIDictionary does not have ?",
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
        ITalonObject IRosterObject.GetTalonObject(ITalonIdentificationReport talonIdentificationReport)
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
        bool IRosterObject.IsTalonIdentificationReportActive(ITalonIdentificationReport talonIdentificationReport)
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
                    //TalonGameObjectManager.AddTalonGameObject(talonObject);

                    /*
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
                    */
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
