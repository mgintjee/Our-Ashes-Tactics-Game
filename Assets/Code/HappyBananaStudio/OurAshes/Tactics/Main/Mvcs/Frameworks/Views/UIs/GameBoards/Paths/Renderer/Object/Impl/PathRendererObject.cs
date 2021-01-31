namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Paths.Renderer.Object.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Pathing.Objects.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.HexTiles.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Paths.Renderer.Object.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.ResourceLoaders.Materials;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class PathRendererObject
        : IPathRendererObject
    {
        // Todo
        private readonly LineRenderer lineRenderer;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="parentTransform"></param>
        private PathRendererObject(Transform parentTransform)
        {
            GameObject gameObject = new GameObject(this.GetType().Name);
            gameObject.transform.SetParent(parentTransform);
            gameObject.transform.localPosition = Vector3.zero;
            this.lineRenderer = gameObject.AddComponent<LineRenderer>();
            this.lineRenderer.startWidth = 0.1f;
            this.lineRenderer.endWidth = 0.25f;
            this.lineRenderer.numCapVertices = 5;
            this.lineRenderer.numCornerVertices = 5;
            this.lineRenderer.generateLightingData = true;
        }

        /// <inheritdoc/>
        void IPathRendererObject.HidePathObject()
        {
            this.lineRenderer.positionCount = 0;
        }

        /// <inheritdoc/>
        void IPathRendererObject.ShowPathObject(IPathObject pathObject)
        {
            Material pathMaterial = this.LoadPathMaterial(pathObject);
            IList<Vector3> pathWorldPositions = this.LoadPathWorldPositions(pathObject);
            this.lineRenderer.material = pathMaterial;
            lineRenderer.positionCount = pathWorldPositions.Count;
            for (int i = 0; i < pathWorldPositions.Count; ++i)
            {
                Vector3 worldPosition = pathWorldPositions[i];
                lineRenderer.SetPosition(i, worldPosition);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        /// <returns></returns>
        private Material LoadPathMaterial(IPathObject pathObject)
        {
            if (pathObject is PathObjectMove)
            {
                return MaterialResourceLoader.Path.LoadPathMaterialResource(OrderType.Move);
            }
            else if (pathObject is PathObjectFire)
            {
                return MaterialResourceLoader.Path.LoadPathMaterialResource(OrderType.Fire);
            }
            else if (pathObject is PathObjectWait)
            {
                return MaterialResourceLoader.Path.LoadPathMaterialResource(OrderType.Wait);
            }
            else
            {
                return MaterialResourceLoader.Path.LoadPathMaterialResource(OrderType.None);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="pathObject"></param>
        /// <returns></returns>
        private IList<Vector3> LoadPathWorldPositions(IPathObject pathObject)
        {
            IList<Vector3> pathWorldPositions = new List<Vector3>();
            if (pathObject is PathObjectFire ||
                pathObject is PathObjectMove)
            {
                IList<ICubeCoordinates> cubeCoordinatesList = pathObject.GetCubeCoordinatesStepList();
                foreach (ICubeCoordinates cubeCoordinates in cubeCoordinatesList)
                {
                    Vector3 worldPosition = HexTileViewWorldPositionUtil.CubeCoordinatesToWorldVector(cubeCoordinates);
                    worldPosition.y *= -1;
                    pathWorldPositions.Add(worldPosition);
                }
            }
            else
            {
                /*
                 * Collect the vertices of the tile's hexagonal shape
                 *   Vertex4  Vertex3
                 * Vertex5      Vertex2
                 *   Vertex0  Vertex1
                 */
                // Collect the center vertex of the CubeCoordinates
                Vector3 worldPosition = HexTileViewWorldPositionUtil
                    .CubeCoordinatesToWorldVector(pathObject.GetCubeCoordinatesStart());
                // Offset the Y-Position to have the point float above the tiles
                worldPosition.y *= -1;

                Vector3 vertex0 = worldPosition;
                Vector3 vertex1 = worldPosition;
                Vector3 vertex2 = worldPosition;
                Vector3 vertex3 = worldPosition;
                Vector3 vertex4 = worldPosition;
                Vector3 vertex5 = worldPosition;

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
                pathWorldPositions.Add(vertex0);
                pathWorldPositions.Add(vertex1);
                pathWorldPositions.Add(vertex2);
                pathWorldPositions.Add(vertex3);
                pathWorldPositions.Add(vertex4);
                pathWorldPositions.Add(vertex5);
                // Have the lineRenderer finish where it started
                pathWorldPositions.Add(vertex0);
            }
            return pathWorldPositions;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private Transform parentTransform = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPathRendererObject Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    return new PathRendererObject(this.parentTransform);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="parentTransform"></param>
            /// <returns></returns>
            public Builder SetParentTransform(Transform parentTransform)
            {
                this.parentTransform = parentTransform;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.parentTransform == null)
                {
                    argumentExceptionSet.Add("Parent " + typeof(Transform).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}