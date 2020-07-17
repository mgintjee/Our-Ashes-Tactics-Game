using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public class LineRendererUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    // Todo
    private static LineRendererUtilScript lineRendererUtilScript;

    #endregion Private Fields

    #region Public Methods

    public static void DrawPath(PathObject pathObject)
    {
        // Checking if the GameObjectSpawnerUtil is non-null
        if (lineRendererUtilScript == null)
        {
            CollectLineRendererUtilGameObject();
        }
        if (lineRendererUtilScript != null)
        {
            LineRenderer lineRenderer = lineRendererUtilScript.GetLineRenderer();
            List<CubeCoordinates> cubeCoordinatesStepList = pathObject.GetCubeCoordinatesStepList();
            List<Vector3> tileObjectWorldPositions = new List<Vector3>();
            lineRenderer.positionCount = cubeCoordinatesStepList.Count;
            int index = 0;
            foreach (CubeCoordinates cubeCoordinates in cubeCoordinatesStepList)
            {
                TileObject tileObject = TileObjectFinderUtil.FindTileObjectFrom(cubeCoordinates);
                TileScript tileScript = tileObject.GetTileScript();
                Vector3 tileWorldPosition = tileScript.GetGameObject().transform.position;
                tileWorldPosition.y += Mathf.Abs(TileGameObjectConstants.GetOffsetY() * 2);
                lineRenderer.SetPosition(index, tileWorldPosition);
                tileObjectWorldPositions.Add(tileWorldPosition);
                index++;
            }
            if (pathObject is PathObjectMove ||
                pathObject is PathObjectFire)
            {
            }
            else if (pathObject is PathObjectWait)
            {
                lineRenderer.positionCount++;
            }

            logger.Info("Draw ? Path: ?", pathObject.GetType(), string.Join(",", cubeCoordinatesStepList));
            logger.Info("Draw ? Path: ?", pathObject.GetType(), string.Join(",", tileObjectWorldPositions));
        }
        else
        {
            logger.Error("Error Drawing Path: LineRendererUtil Script is null");
        }
    }

    public static void ErasePath()
    {
        // Checking if the GameObjectSpawnerUtil is non-null
        if (lineRendererUtilScript == null)
        {
            CollectLineRendererUtilGameObject();
        }
        if (lineRendererUtilScript != null)
        {
            LineRenderer lineRenderer = lineRendererUtilScript.GetLineRenderer();
            lineRenderer.positionCount = 0;
        }
        else
        {
            logger.Error("Error Drawing Path: LineRendererUtil Script is null");
        }
    }

    #endregion Public Methods

    #region Private Methods

    /// </summary>
    private static void CollectLineRendererUtilGameObject()
    {
        // Find the LineRendererUtil GameObject
        GameObject lineRendererUtilGameObject = GameObject.Find(LineRendererConstants.GetLineRendererUtilGameObjectName());
        // Check if the LineRendererUtil GameObject is non-null
        if (lineRendererUtilGameObject != null)
        {
            // Collect the LineRendererUtilScript from the GameObject
            LineRendererUtilScript lineRendererUtilScript = lineRendererUtilGameObject.GetComponent<LineRendererUtilScript>();
            // Check if the LineRendererUtilScript is non-null
            if (lineRendererUtilScript != null)
            {
                LineRendererUtil.lineRendererUtilScript = lineRendererUtilScript;
                logger.Debug("Collected LineRendererUtilScript");
            }
            else
            {
                logger.Error("Error Loading Model: Loaded Null LineRendererUtilScript");
            }
        }
        else
        {
            logger.Error("Error Loading Model: Loaded Null LineRendererUtil GameObject");
        }
    }

    #endregion Private Methods
}