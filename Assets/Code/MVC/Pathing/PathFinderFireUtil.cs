using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public static class PathFinderFireUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private static PathFinderFire pathFinderFire;

    #endregion Private Fields

    #region Public Methods

    public static Dictionary<CubeCoordinates, PathObject> BeginPathfindingFor(CubeCoordinates tileCoordinatesStart, TeamIdEnum teamId)
    {
        logger.Debug("PathFinding for FIRING from CubeCoordinates: ?, for MechTeam=?", tileCoordinatesStart, teamId);
        pathFinderFire = new PathFinderFire(tileCoordinatesStart, teamId);
        pathFinderFire.BeginPathFinding();
        Dictionary<CubeCoordinates, PathObject> pathObjectDictionary = pathFinderFire.GetPathObjectDictionary();
        return pathObjectDictionary;
    }

    #endregion Public Methods
}