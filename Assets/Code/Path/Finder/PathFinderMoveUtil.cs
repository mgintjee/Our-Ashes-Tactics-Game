using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Todo
/// </summary>
public static class PathFinderMoveUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    private static PathFinderMove pathFinderMove;

    #endregion Private Fields

    #region Public Methods

    public static Dictionary<CubeCoordinates, PathObject> BeginPathfindingFor(CubeCoordinates tileCoordinatesStart, int pathObjectCostThreshold)
    {
        pathFinderMove = new PathFinderMove(tileCoordinatesStart, pathObjectCostThreshold);
        pathFinderMove.BeginPathFinding();
        Dictionary<CubeCoordinates, PathObject> pathObjectDictionary = pathFinderMove.GetPathObjectDictionary();
        return pathObjectDictionary;
    }

    #endregion Public Methods
}