using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// </summary>
public abstract class GameInitializerScript
    : AbstractUnityScript
{
    #region Private Fields

    // Provide Logging capability
    private readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private GameFrameworkScript gameFrameworkScript;

    #endregion Private Fields

    #region Protected Methods

    protected abstract List<MechConstructionReport> GetMechConstructionReportList();

    #endregion Protected Methods

    #region Private Methods

    private void Update()
    {
        if (this.gameFrameworkScript == null)
        {
            GameObject gameFrameworkGameObject = FinderUtil.FindGameObjectType(typeof(GameFrameworkScript));
            gameFrameworkScript = gameFrameworkGameObject.GetComponent<GameFrameworkScript>();
        }
        if (Input.GetButtonDown("Fire1") &&
            this.gameFrameworkScript != null &&
            !this.gameFrameworkScript.GameIsActive())
        {
            this.logger.Debug("Inputting Mech Roster into GameFramework");
            this.gameFrameworkScript.InputMechRoster(this.GetMechConstructionReportList());
        }
    }

    #endregion Private Methods
}