

namespace HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Construction;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Comparer;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Rosters.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Objects;
    using System.Collections.Generic;
    using System.Diagnostics;

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
                            ITalonObject talonObject = new TalonObjectImpl(talonConstructionReport);
                            // Add the TalonIdentificationReport to the activeTalonIdentificationReportSet
                            this.activeTalonIdentificationReportSet.Add(talonConstructionReport.GetTalonIdentificationReport());
                            // Add the TalonIdentificationReport to the talonIdentificationObjectDictionary
                            this.talonIdentificationObjectDictionary.Add(talonConstructionReport.GetTalonIdentificationReport(), talonObject);
                            // Build the unity GameObject
                            TalonGameObjectManager.BuildTalonGameObject(talonConstructionReport);
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
    }
}
