using System.Diagnostics;
using UnityEngine;

/// <summary>
/// MapControllerScript Impl
/// </summary>
public class MapControllerScriptImpl
    : MapControllerScript
{
    #region Protected Fields

    // Todo
    protected MapControllerObject mapControllerObject;

    #endregion Protected Fields

    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private GameFrameworkObject gameFrameworkObject;

    // Todo
    private MechActionReport mechActionReport;

    // Todo
    private bool pendingMechActionReport = false;

    // Todo
    private TeamControllerTypeEnum teamControllerType;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override MechActionReport CollectMechActionReport()
    {
        MechActionReport mechActionReport = this.mechActionReport;
        if (this.mechActionReport != null)
        {
            this.mechActionReport = null;
            this.pendingMechActionReport = false;
        }
        return mechActionReport;
    }

    /// <summary>
    /// </summary>
    /// <param name="gameFrameworkObject"></param>
    public override void DetermineNextMechActionReport(GameFrameworkObject gameFrameworkObject)
    {
        this.mechActionReport = null;
        this.pendingMechActionReport = true;
        this.gameFrameworkObject = gameFrameworkObject;
        MechObject mechObject = gameFrameworkObject.GetNextMechObject();
        if (mechObject.GetMechTeam() == 1)
        {
            this.teamControllerType = gameFrameworkObject.GetTeam1Controller();
        }
        else if (mechObject.GetMechTeam() == 2)
        {
            this.teamControllerType = gameFrameworkObject.GetTeam2Controller();
        }
        logger.Debug("Determining Next MechActionReport for MechObject=? from Controller=?", mechObject, this.teamControllerType.ToString());
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override MapControllerObject GetMapControllerObject()
    {
        return this.mapControllerObject;
    }

    /// <summary>
    /// MapControllerScript Method, to initialize the MapControllerScript
    /// </summary>
    /// <param name="mapControllerObject">Todo</param>
    public override void Initialize(MapControllerObject mapControllerObject)
    {
        logger.Debug("Initializing Script=?", this.GetType().ToString());
        this.mapControllerObject = mapControllerObject;
        logger.Debug("Initialized Script=?", this.GetType().ToString());
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override bool MechActionReportIsAvailable()
    {
        return this.mechActionReport != null;
    }

    /// <summary>
    /// </summary>
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            logger.Debug("? will determine MechActionReport", this.teamControllerType);
            switch (this.teamControllerType)
            {
                case TeamControllerTypeEnum.HUMAN:
                    if (this.pendingMechActionReport)
                    {
                        logger.Debug("Waiting for User to input order");
                    }
                    break;

                case TeamControllerTypeEnum.ROBOT:
                    MechObject mechObject = this.gameFrameworkObject.GetNextMechObject();
                    this.mechActionReport = ArtificialIntelligence.DetermineBestAction(mechObject.GetMechActionReportSet());
                    logger.Debug("Determined MechActionReport=?", this.mechActionReport);
                    break;
            }
        }
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override bool WaitingForMechActionReport()
    {
        return this.pendingMechActionReport;
    }

    #endregion Public Methods
}