using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

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
        logger.Debug("PathFinding for MOVING from CubeCoordinates: ?, with a PathObjectCostThreshold=?", tileCoordinatesStart, pathObjectCostThreshold);
        pathFinderMove = new PathFinderMove(tileCoordinatesStart, pathObjectCostThreshold);
        pathFinderMove.BeginPathFinding();
        Dictionary<CubeCoordinates, PathObject> pathObjectDictionary = pathFinderMove.GetPathObjectDictionary();
        DebugDrawPathLines(pathObjectDictionary);
        return pathObjectDictionary;
    }

    #endregion Public Methods

    #region Private Methods

    private static void DebugDrawPathLines(Dictionary<CubeCoordinates, PathObject> pathObjectDictionary)
    {
        foreach (CubeCoordinates cubeCoordinates in pathObjectDictionary.Keys)
        {
            PathObject pathObject = pathObjectDictionary[cubeCoordinates];
            logger.Debug("Path to CubeCoordinates: ?, is the following:", cubeCoordinates, pathObject.ToString());
            TileObject previousTileObject = TileObjectFinderUtil.FindTileObjectFrom(pathObject.GetCubeCoordinatesStart());
            foreach (CubeCoordinates cubeCoordinatesStep in pathObject.GetCubeCoordinatesStepList())
            {
                TileObject currentTileObject = TileObjectFinderUtil.FindTileObjectFrom(cubeCoordinatesStep);
                Vector3 previousTilePosition = previousTileObject.GetTileScript().GetGameObject().transform.position;
                Vector3 currentTilePosition = currentTileObject.GetTileScript().GetGameObject().transform.position;
                previousTilePosition.y = 2.5f;
                currentTilePosition.y = 2.5f;
                //Debug.DrawLine(previousTilePosition, currentTilePosition, Color.green, 100f);
                previousTileObject = currentTileObject;
            }
        }
    }

    #endregion Private Methods
}