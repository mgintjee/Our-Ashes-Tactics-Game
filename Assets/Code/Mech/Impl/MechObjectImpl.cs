using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class MechObjectImpl
    : MechObject
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private readonly MechBehavior mechBehavior;
    private readonly MechIdEnum mechId;
    private readonly string mechName;
    private readonly MechScript mechScript;
    private readonly MechVisual mechVisual;

    #endregion Private Fields

    #region Public Constructors

    public MechObjectImpl(MechScript mechScript, MechConstructionReport mechConstructionReport)
    {
        this.mechScript = mechScript;
        this.mechId = mechConstructionReport.GetMechId();
        this.mechName = mechConstructionReport.GetMechName();
        this.mechBehavior = new MechBehaviorImpl(mechConstructionReport);
        this.mechVisual = new MechVisualImpl(this.GetMechScript(), mechConstructionReport);
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Get the Set: ActionReport that this MechObject is capable of doing
    /// </summary>
    /// <returns>The available Set: ActionReport for this MechObject</returns>
    public override HashSet<ActionReport> GetMechActionReportSet()
    {
        // Begin pathFinding for this MechObject
        this.GetMechBehavior().BeginPathFinding();
        // Default an empty Set
        HashSet<ActionReport> mechActionReportSet = new HashSet<ActionReport>();
        // Iterate over all possible pathObjects for moving
        foreach (PathObject pathObjectMove in this.mechBehavior.GetPathObjectMoveSet())
        {
            // Add the actionReport to move
            mechActionReportSet.Add(new ActionReport(this, pathObjectMove));
        }
        // Iterate over all possible pathObjects for firing
        foreach (PathObject pathObjectFire in this.mechBehavior.GetPathObjectFireSet())
        {
            // Add the actionReport to fire
            mechActionReportSet.Add(new ActionReport(this, pathObjectFire));
        }
        // Add the actionReport to wait
        mechActionReportSet.Add(new ActionReport(this));
        // Return the Set
        return mechActionReportSet;
    }

    public override MechBehavior GetMechBehavior()
    {
        return this.mechBehavior;
    }

    public override MechIdEnum GetMechId()
    {
        return this.mechId;
    }

    public override MechInfoReport GetMechInfoReport()
    {
        return this.mechBehavior.GetMechInfoReport();
    }

    public override string GetMechName()
    {
        return this.mechName;
    }

    public override MechScript GetMechScript()
    {
        return this.mechScript;
    }

    public override TeamIdEnum GetTeamId()
    {
        return this.GetMechBehavior().GetTeamId();
    }

    public override MechVisual GetMechVisual()
    {
        return this.mechVisual;
    }

    public override HashSet<WeaponCombatReport> GetWeaponCombatReportSet(PathObjectFire pathObjectFire)
    {
        return this.GetMechBehavior().GetWeaponCombatReportSet(pathObjectFire);
    }

    public override void SetCubeCoordinates(CubeCoordinates cubeCoordinates)
    {
        logger.Debug("?: Setting Tile Position to ?", this, cubeCoordinates);
        if (this.GetMechBehavior().GetCubeCoordinates() != null)
        {
            TileObject previousTileObject = TileObjectFinderUtil.FindTileObjectFrom(this.GetMechBehavior().GetCubeCoordinates());
            previousTileObject.SetOccupyingMechObject(null);
        }

        this.GetMechBehavior().SetCubeCoordinates(cubeCoordinates);

        TileObject currentTileObject = TileObjectFinderUtil.FindTileObjectFrom(cubeCoordinates);
        this.GetMechVisual().PaintBase(currentTileObject.GetTileObjectType());

        Vector3 tileGameObjectWorldPosition = CubeCoordinatesPositionUtil.CubeCoordinatesToWorldVector(cubeCoordinates);
        tileGameObjectWorldPosition.y = 0;
        this.GetMechScript().GetGameObject().transform.position = tileGameObjectWorldPosition;

        int angle = 90;
        switch (this.GetTeamId())
        {
            case TeamIdEnum.East:
                angle = 0;
                break;

            case TeamIdEnum.SouthEast:
                angle = 60;
                break;

            case TeamIdEnum.SouthWest:
                angle = 120;
                break;

            case TeamIdEnum.West:
                angle = 180;
                break;

            case TeamIdEnum.NorthWest:
                angle = 240;
                break;

            case TeamIdEnum.NorthEast:
                angle = 300;
                break;
        }
        logger.Debug("Setting Angle: ?", angle);
        this.GetMechScript().GetGameObject().transform.localEulerAngles = new Vector3(0, angle, 0);
    }

    public override string ToString()
    {
        return this.GetMechBehavior().GetMechInfoReport().ToString();
    }

    #endregion Public Methods
}