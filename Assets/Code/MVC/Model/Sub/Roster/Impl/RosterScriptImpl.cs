using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Roster Script Impl
/// </summary>
public class RosterScriptImpl
    : RosterScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private RosterConstructionReport rosterConstructionReport;

    // Todo
    private RosterObject rosterObject;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override RosterObject GetRosterObject()
    {
        return this.rosterObject;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="mcvModelScript">          </param>
    /// <param name="rosterConstructionReport"></param>
    public override void Initialize(MvcModelScript mcvModelScript, RosterConstructionReport rosterConstructionReport)
    {
        logger.Info("Initializing: ?.", this.GetType());
        if (!this.IsInitialized())
        {
            if (mcvModelScript != null &&
            rosterConstructionReport != null)
            {
                this.rosterConstructionReport = rosterConstructionReport;

                this.BuildFactionPhalanxGameObjects();

                this.rosterObject = new RosterObjectImpl(this, rosterConstructionReport);
            }
            else
            {
                throw new ArgumentException("Unable to initialize " + this.GetType() + ". Invalid Parameters." +
                    "\n\t>" + typeof(MvcModelScript) + "=" + mcvModelScript +
                    "\n\t>" + typeof(RosterConstructionReport) + "=" + rosterConstructionReport);
            }
        }
        else
        {
            logger.Warn("Unable to Initialize: ?. Already initialized.", this.GetType());
        }
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public override bool IsInitialized()
    {
        return this.rosterConstructionReport != null &&
            this.rosterObject != null;
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Todo
    /// </summary>
    private void BuildFactionPhalanxGameObjects()
    {
        foreach (TalonFactionIdEnum talonFactionId in this.rosterConstructionReport.GetTalonFactionPhalanxSetDictionary().Keys)
        {
            GameObject factionGameObject = new GameObject(RosterConstants.Script.GetFactionIdGameObjectPrefix() + talonFactionId);
            factionGameObject.transform.SetParent(this.transform);

            foreach (TalonPhalanxIdEnum talonPhalanxId in this.rosterConstructionReport.GetTalonFactionPhalanxSetDictionary()[talonFactionId])
            {
                GameObject phalanxGameObject = new GameObject(RosterConstants.Script.GetPhalanxIdGameObjectPrefix() + talonPhalanxId);
                phalanxGameObject.transform.SetParent(factionGameObject.transform);
            }
        }
    }

    #endregion Private Methods
}