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

    public override HashSet<ActionReport> GetMechActionReportSet()
    {
        this.GetMechBehavior().BeginPathFinding();
        HashSet<ActionReport> mechActionReportSet = new HashSet<ActionReport>();

        foreach (PathObject pathObjectMove in this.mechBehavior.GetPathObjectMoveSet())
        {
            mechActionReportSet.Add(new ActionReport(this, pathObjectMove));
        }
        foreach (PathObject pathObjectFire in this.mechBehavior.GetPathObjectFireSet())
        {
            mechActionReportSet.Add(new ActionReport(this, pathObjectFire));
        }
        mechActionReportSet.Add(new ActionReport(this));

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

    public override int GetMechTeam()
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
        if (this.GetMechTeam() == 1)
        {
            this.GetMechScript().GetGameObject().transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

    public override string ToString()
    {
        return this.GetMechBehavior().GetMechInfoReport().ToString();
    }

    #endregion Public Methods
}