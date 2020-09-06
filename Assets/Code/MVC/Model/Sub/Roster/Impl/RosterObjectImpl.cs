using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

/// <summary>
/// Roster Object Impl
/// </summary>
public class RosterObjectImpl
    : RosterObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private readonly HashSet<TalonIdentificationReport> activeTalonIdentificationReportSet = null;

    // Todo
    private readonly RosterConstructionReport rosterConstructionReport = null;

    // Todo
    private readonly RosterScript rosterScript = null;

    // Todo
    private readonly Dictionary<TalonIdentificationReport, TalonObject> talonIdentificationObjectDictionary = null;

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
            this.talonIdentificationObjectDictionary = new Dictionary<TalonIdentificationReport, TalonObject>();
            this.activeTalonIdentificationReportSet = new HashSet<TalonIdentificationReport>();

            // Iterate over all of the TalonConstructionReports
            foreach (TalonConstructionReport talonConstructionReport in this.rosterConstructionReport.GetTalonConstructionReportSet())
            {
                TalonObject talonObject = TalonObjectBuilderUtil.BuildTalonObject(talonConstructionReport);
                if (talonObject != null)
                {
                    this.AddTalonObject(talonObject);
                }
                else
                {
                    logger.Error("Unable to add ?. ? produced null.", typeof(TalonObject), talonConstructionReport);
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
    public override void DeactivateTalonIdentificationReport(TalonIdentificationReport talonIdentificationReport)
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
    public override HashSet<TalonIdentificationReport> GetActiveTalonIdentificationReportSet()
    {
        return new HashSet<TalonIdentificationReport>(this.activeTalonIdentificationReportSet);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override HashSet<TalonObject> GetAllTalonObjectSet()
    {
        return new HashSet<TalonObject>(this.talonIdentificationObjectDictionary.Values);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonPhalanxId"></param>
    /// <returns></returns>
    public override HashSet<TalonObject> GetAllTalonObjectSet(TalonPhalanxIdEnum talonPhalanxId)
    {
        // Default an empty set
        HashSet<TalonObject> talonObjectSet = new HashSet<TalonObject>();
        // Iterate over the TalonIdentificationReports
        foreach (TalonIdentificationReport talonIdentificationReport in this.talonIdentificationObjectDictionary.Keys)
        {
            // Check if the TalonPhalanxId matches
            if (talonIdentificationReport.GetTalonPhalanxId().Equals(talonPhalanxId))
            {
                // Add the TalonObject to the set
                talonObjectSet.Add(this.talonIdentificationObjectDictionary[talonIdentificationReport]);
            }
        }
        return talonObjectSet;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonFactionId"></param>
    /// <returns></returns>
    public override HashSet<TalonObject> GetAllTalonObjectSet(TalonFactionIdEnum talonFactionId)
    {
        // Default an empty set
        HashSet<TalonObject> talonObjectSet = new HashSet<TalonObject>();
        // Iterate over the TalonIdentificationReports
        foreach (TalonIdentificationReport talonIdentificationReport in this.talonIdentificationObjectDictionary.Keys)
        {
            // Check if the TalonFactionId matches
            if (talonIdentificationReport.GetTalonFactionId().Equals(talonFactionId))
            {
                // Add the TalonObject to the set
                talonObjectSet.Add(this.talonIdentificationObjectDictionary[talonIdentificationReport]);
            }
        }
        return talonObjectSet;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override List<TalonIdentificationReport> GetOrderedTalonIdentificationReportList()
    {
        return this.activeTalonIdentificationReportSet.OrderByDescending(
            talonIdentificationReport => this.GetTalonOrderPoints(talonIdentificationReport)).ToList();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override RosterInformationReport GetRosterInformationReport()
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
    public override TalonControllerIdEnum GetTalonControllerId(TalonIdentificationReport talonIdentificationReport)
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
    public override TalonObject GetTalonObject(TalonIdentificationReport talonIdentificationReport)
    {
        TalonObject talonObject = null;
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

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="talonObject"></param>
    private void AddTalonObject(TalonObject talonObject)
    {
        // Check that the TalonObject is non-null
        if (talonObject != null)
        {
            // Get the TalonIdentificationReport from the TalonObject
            TalonIdentificationReport talonIdentificationReport = talonObject.GetTalonIdentificationReport();
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
                        logger.Error("Unable to add ?. Unable to find ?.", typeof(TalonObject),
                            RosterConstants.Script.GetPhalanxIdGameObjectPrefix() + talonIdentificationReport.GetTalonPhalanxId());
                    }
                }
                else
                {
                    logger.Error("Unable to add ?. Unable to find ?.", typeof(TalonObject),
                        RosterConstants.Script.GetFactionIdGameObjectPrefix() + talonIdentificationReport.GetTalonFactionId());
                }
            }
            else
            {
                logger.Error("Unable to add ?. ? is null.", typeof(TalonObject), typeof(TalonIdentificationReport));
            }
        }
        else
        {
            logger.Error("Unable to add ?. ? is null.", typeof(TalonObject), typeof(TalonObject));
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
        TalonObject talonObject = this.GetTalonObject(talonIdentificationReport);
        if (talonObject != null)
        {
            talonOrderPoints = talonObject.GetTalonAttributesReport().GetOrderPoints();
        }
        else
        {
            logger.Warn("Unable to GetTalonOrderPoints. ? is not tracked.", talonIdentificationReport);
        }
        return talonOrderPoints;
    }

    #endregion Private Methods
}