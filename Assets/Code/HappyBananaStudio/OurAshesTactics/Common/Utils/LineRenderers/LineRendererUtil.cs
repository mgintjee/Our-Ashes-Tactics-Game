/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.HexTile;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Paths.Object;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Constants.HexTiles;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Managers;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Fire;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Move;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Objects.Paths.Objects.Wait;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Utils.LineRenderers
{
    /// <summary>
    /// Todo
    /// </summary>
    public class LineRendererUtil
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        private static LineRendererUtilScript lineRendererUtilScript;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        public static void DrawPath(IPathObject pathObject)
        {
            // Checking if the GameObjectSpawnerUtil is non-null
            if (lineRendererUtilScript == null)
            {
                CollectLineRendererUtilGameObject();
            }
            if (lineRendererUtilScript != null)
            {
                ErasePath();
                LineRenderer lineRenderer = lineRendererUtilScript.GetLineRenderer();
                DetermineLineRendererMaterial(pathObject, lineRenderer);
                DetermineLineRendererPositions(pathObject, lineRenderer);
            }
            else
            {
                logger.Error("Error Drawing Path: LineRendererUtil Script is null");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
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

        /// <summary>
        /// Todo
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        private static List<Vector3> CollectTileVertexList(ICubeCoordinates cubeCoordinates)
        {
            // Default an empty list
            List<Vector3> tileVertexList = new List<Vector3>();
            // Check that the CubeCoordinates is non-null
            if (cubeCoordinates != null)
            {
                IHexTileObject hexTileObject = GameMapObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                // Check that the tileObject is non-null
                if (hexTileObject != null)
                {
                    /*
                     * Collect the vertices of the tile's hexagonal shape
                     *   Vertex4  Vertex3
                     * Vertex5      Vertex2
                     *   Vertex0  Vertex1
                     */
                    // Collect the center vertex of the CubeCoordinates
                    Vector3 tileWorldPosition = hexTileObject.GetHexTileScript().GetGameObject().transform.position;
                    // Offset the Y-Position to have the point float above the tiles
                    tileWorldPosition.y += Mathf.Abs(HexTileGameObjectConstants.GetOffsetY() * 2);

                    Vector3 vertex0 = tileWorldPosition;
                    Vector3 vertex1 = tileWorldPosition;
                    Vector3 vertex2 = tileWorldPosition;
                    Vector3 vertex3 = tileWorldPosition;
                    Vector3 vertex4 = tileWorldPosition;
                    Vector3 vertex5 = tileWorldPosition;

                    // Todo: Store in a const file
                    vertex0.x -= 2 / 2.5f;
                    vertex1.x += 2 / 2.5f;
                    vertex2.x += 3.5f / 2.5f;
                    vertex3.x += 2 / 2.5f;
                    vertex4.x -= 2 / 2.5f;
                    vertex5.x -= 3.5f / 2.5f;

                    vertex0.z -= 3 / 2.5f;
                    vertex1.z -= 3 / 2.5f;
                    vertex3.z += 3 / 2.5f;
                    vertex4.z += 3 / 2.5f;

                    // Add the vertices in order to the lineRenderer positions
                    tileVertexList.Add(vertex0);
                    tileVertexList.Add(vertex1);
                    tileVertexList.Add(vertex2);
                    tileVertexList.Add(vertex3);
                    tileVertexList.Add(vertex4);
                    tileVertexList.Add(vertex5);
                    // Have the lineRenderer finish where it started
                    tileVertexList.Add(vertex0);
                }
            }
            else
            {
                logger.Warn("Unable to collect Tile List: Vertex. CubeCoordinates is null");
            }
            return tileVertexList;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        /// <param name="lineRenderer">
        /// </param>
        private static void DetermineLineRendererMaterial(IPathObject pathObject, LineRenderer lineRenderer)
        {
            if (pathObject == null)
            {
                logger.Error("Unable to determine LineRenderer Material. Null PathObject");
            }
            else
            {
                if (pathObject is PathObjectMoveImpl)
                {
                    lineRenderer.material = MaterialResourceLoader.Path.LoadPathMaterialResource(ActionTypeEnum.Move);
                }
                else if (pathObject is PathObjectFireImpl)
                {
                    lineRenderer.material = MaterialResourceLoader.Path.LoadPathMaterialResource(ActionTypeEnum.Fire);
                }
                else if (pathObject is PathObjectWaitImpl)
                {
                    lineRenderer.material = MaterialResourceLoader.Path.LoadPathMaterialResource(ActionTypeEnum.Wait);
                }
                else
                {
                    logger.Error("Unable to determine LineRenderer Material. Invalid PathObject=?", typeof(IPathObject));
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject">
        /// </param>
        /// <param name="lineRenderer">
        /// </param>
        private static void DetermineLineRendererPositions(IPathObject pathObject, LineRenderer lineRenderer)
        {
            if (pathObject == null)
            {
                logger.Error("Unable to determine LineRenderer Positions. Null PathObject");
            }
            else
            {
                int index = 0;
                List<Vector3> lineRendererPositionList = new List<Vector3>();
                // Check if the PathObject is a waiting one
                if (pathObject is PathObjectWaitImpl)
                {
                    lineRendererPositionList = CollectTileVertexList(pathObject.GetCubeCoordinatesStart());
                }
                else if (pathObject is PathObjectFireImpl ||
                    pathObject is PathObjectMoveImpl)
                {
                    List<ICubeCoordinates> cubeCoordinatesStepList = pathObject.GetCubeCoordinatesStepList();
                    foreach (ICubeCoordinates cubeCoordinates in cubeCoordinatesStepList)
                    {
                        IHexTileObject tileObject = GameMapObjectManager.GetHexTileObjectFrom(cubeCoordinates);
                        IHexTileScript tileScript = tileObject.GetHexTileScript();
                        Vector3 tileWorldPosition = tileScript.GetGameObject().transform.position;
                        tileWorldPosition.y += Mathf.Abs(HexTileGameObjectConstants.GetOffsetY() * 2);
                        lineRendererPositionList.Add(tileWorldPosition);
                    }
                }
                else
                {
                    logger.Error("Unable to determine LineRenderer Positions. Invalid PathObject=?", typeof(IPathObject));
                }

                lineRenderer.positionCount = lineRendererPositionList.Count;
                foreach (Vector3 vector3 in lineRendererPositionList)
                {
                    lineRenderer.SetPosition(index, vector3);
                    index++;
                }
            }
        }
    }
}