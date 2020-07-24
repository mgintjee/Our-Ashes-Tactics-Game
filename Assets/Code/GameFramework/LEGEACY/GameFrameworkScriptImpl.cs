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

    // Todo
    private ControllerScript mapControllerScript;

    // Todo
    private ViewScript mapModelScript;

    #endregion Private Fields

    #region Public Methods

    public override bool GameIsActive()
    {
        return this.gameFrameworkObject != null &&
            this.gameFrameworkObject.GameIsActive();
    }

    public override GameFrameworkObject GetGameFrameworkObject()
    {
        return this.gameFrameworkObject;
    }

    public override ControllerScript GetMapControllerScript()
    {
        return this.mapControllerScript;
    }

    public override ViewScript GetMapModelScript()
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
    }

    public void LateUpdate()
    {
        if (this.gameFrameworkObject.GameIsActive())
        {
            if (!this.gameFrameworkObject.ProcessingActionReport())
            {
            }
        }
        else
        {
            logger.Debug("Game is not currently active");
        }
        // Check that the game is currently active and not currently processing an ActionReport
        if (this.gameFrameworkObject.GameIsActive() &&
            !this.gameFrameworkObject.ProcessingActionReport())
        {
            // Check if the MapController Script is not currently processing the Input
            if (!this.mapControllerScript.ProcessingInput())
            {
                // Check if the the MapControllerScript has a new ActionReport available
                if (this.mapControllerScript.ActionReportIsAvailable())
                {
                    ActionReport actionReport = this.mapControllerScript.CollectActionReport();
                    if (actionReport != null)
                    {
                        this.gameFrameworkObject.InputMechActionReport(actionReport);
                    }
                    else
                    {
                        logger.Warn("? returned a null ?", typeof(ControllerScript), typeof(ActionReport));
                    }
                }
                else
                {
                    logger.Info("? is ready to determine next ?", typeof(ControllerScript), typeof(ActionReport));
                    this.mapControllerScript.DetermineNextActionReport();
                }
            }
            // Otherwise inform the MapController Script to start processing the Input
            else
            {
                logger.Debug("? is determining next ?", typeof(ControllerScript), typeof(ActionReport));
            }
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void GenerateMapControllerScript()
    {
        logger.Debug("Generating GameObject=?", GameFrameworkScriptConstants.GetMapControllerGameObjectName());
        GameObject mapControllerGameObject = new GameObject(GameFrameworkScriptConstants.GetMapControllerGameObjectName());
        mapControllerGameObject.transform.parent = this.GetGameObject().transform;
        this.mapControllerScript = mapControllerGameObject.AddComponent<ControllerScriptImpl>();
        this.mapControllerScript.Initialize(this);
        logger.Debug("Generated GameObject=?", GameFrameworkScriptConstants.GetMapControllerGameObjectName());
    }

    private void GenerateMapModelScript()
    {
        logger.Debug("Generating GameObject=?", GameFrameworkScriptConstants.GetMapModelGameObjectName());
        GameObject mapModelGameObject = new GameObject(GameFrameworkScriptConstants.GetMapModelGameObjectName());
        mapModelGameObject.transform.parent = this.GetGameObject().transform;
        this.mapModelScript = mapModelGameObject.AddComponent<ViewScriptImpl>();
        this.mapModelScript.Initialize(this);
        logger.Debug("Generated GameObject=?", GameFrameworkScriptConstants.GetMapModelGameObjectName());
    }

    #endregion Private Methods
}