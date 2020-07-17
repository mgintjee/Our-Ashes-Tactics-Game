using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// GameFrameworkScript Impl
/// </summary>
public class GameFrameworkScriptImpl
    : GameFrameworkScript
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private GameFrameworkObject gameFrameworkObject;

    private bool gameIsActive = false;

    // Todo
    private MapControllerScript mapControllerScript;

    // Todo
    private MapModelScript mapModelScript;

    #endregion Private Fields

    #region Public Methods

    public void FixedUpdate()
    {
        if (this.gameIsActive)
        {
            if (this.mapControllerScript.MechActionReportIsAvailable())
            {
                MechActionReport mechActionReport = this.mapControllerScript.CollectMechActionReport();
                if (mechActionReport != null)
                {
                    this.gameFrameworkObject.InputMechActionReport(mechActionReport);
                }
                else
                {
                    logger.Warn("Controller returned a null MechActionReport");
                }
            }
            else if (!this.mapControllerScript.WaitingForMechActionReport())
            {
                logger.Info("Controller is ready to determine next MechActionReport");
                this.mapControllerScript.DetermineNextMechActionReport(this.GetGameFrameworkObject());
            }
            else
            {
                logger.Info("Controller is determining next MechActionReport");
            }
        }
    }

    public override GameFrameworkObject GetGameFrameworkObject()
    {
        return this.gameFrameworkObject;
    }

    public override bool GetGameIsActive()
    {
        return this.gameIsActive;
    }

    public override MapControllerScript GetMapControllerScript()
    {
        return this.mapControllerScript;
    }

    public override MapModelScript GetMapModelScript()
    {
        return this.mapModelScript;
    }

    public override void Initialize()
    {
        logger.Debug("Initializing Script=?", this.GetType().ToString());
        this.gameFrameworkObject = new GameFrameworkObjectImpl.Builder()
            .SetMapModelSeed(GameFrameworkObjectConstants.GetMapModelObjectSeed())
            .SetMapModelRadius(GameFrameworkObjectConstants.GetMapModelObjectRadius())
            .SetMapModelMirrored(GameFrameworkObjectConstants.GetMapMirrored())
            .SetMaxMechPerTeam(GameFrameworkObjectConstants.GetMaxMechPerTeam())
            .SetTeam1Controller(GameFrameworkObjectConstants.GetTeam1Controller())
            .SetTeam2Controller(GameFrameworkObjectConstants.GetTeam2Controller())
            .SetGameFrameworkScript(this)
            .Build();
        this.GenerateMapControllerScript();
        this.GenerateMapModelScript();
        logger.Debug("Initialized Script=?", this.GetType().ToString());
    }

    public override void InputMechRoster(List<MechConstructionReport> mechCreationReportList)
    {
        foreach (MechConstructionReport mechCreationReport in mechCreationReportList)
        {
            logger.Info("Inputting a new Mech from ?", mechCreationReport);
            this.gameFrameworkObject.CreateNewMechFrom(mechCreationReport);
        }
        this.gameFrameworkObject.InitializeNewGame();
        this.gameIsActive = true;
    }

    #endregion Public Methods

    #region Private Methods

    private void GenerateMapControllerScript()
    {
        logger.Debug("Generating GameObject=?", GameFrameworkScriptConstants.GetMapControllerGameObjectName());
        GameObject mapControllerGameObject = new GameObject(GameFrameworkScriptConstants.GetMapControllerGameObjectName());
        mapControllerGameObject.transform.parent = this.GetGameObject().transform;
        this.mapControllerScript = mapControllerGameObject.AddComponent<MapControllerScriptImpl>();
        //mapControllerScript.Initialize(this.gameFrameworkObject.GetMapControllerObject());
        logger.Debug("Generated GameObject=?", GameFrameworkScriptConstants.GetMapControllerGameObjectName());
    }

    private void GenerateMapModelScript()
    {
        logger.Debug("Generating GameObject=?", GameFrameworkScriptConstants.GetMapModelGameObjectName());
        GameObject mapModelGameObject = new GameObject(GameFrameworkScriptConstants.GetMapModelGameObjectName());
        mapModelGameObject.transform.parent = this.GetGameObject().transform;
        this.mapModelScript = mapModelGameObject.AddComponent<MapModelScriptImpl>();
        this.mapModelScript.Initialize(this);
        logger.Debug("Generated GameObject=?", GameFrameworkScriptConstants.GetMapModelGameObjectName());
    }

    #endregion Private Methods
}