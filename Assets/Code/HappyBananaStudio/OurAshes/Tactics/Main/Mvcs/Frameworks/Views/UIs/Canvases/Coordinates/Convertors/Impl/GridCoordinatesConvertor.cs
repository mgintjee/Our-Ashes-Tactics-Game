namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class GridCoordinatesConvertor
        : IGridConvertor
    {
        // Todo
        private readonly ICanvasGridCoordinates gridDimensions;

        // Todo
        private readonly float worldHeight;

        // Todo
        private readonly float worldWidth;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <param name="worldHeight"></param>
        /// <param name="worldWidth"></param>
        public GridCoordinatesConvertor(ICanvasGridCoordinates gridDimensions, float worldWidth, float worldHeight)
        {
            this.gridDimensions = gridDimensions;
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
        }

        /// <inheritdoc/>
        Vector2 IGridConvertor.GetWorldDimensionsFrom(ICanvasGridCoordinates gridDimensions)
        {
            return this.GetWorldDimensionsFrom(gridDimensions);
        }

        /// <inheritdoc/>
        Vector2 IGridConvertor.GetWorldPositionFrom(ICanvasGridCoordinates gridPosition,
            ICanvasGridCoordinates gridDimensions)
        {
            if (gridPosition == null)
            {
                return Vector2.zero;
            }
            Vector2 worldPosition = new Vector2(
                    (gridPosition.GetCol() * this.GetWorldWidthStep()) - this.worldWidth / 2,
                    (gridPosition.GetRow() * this.GetWorldHeightStep()) - this.worldHeight / 2);
            Vector2 worldDimensions = this.GetWorldDimensionsFrom(gridDimensions);
            if (worldPosition.x > 0)
            {
                worldPosition.x -= worldDimensions.x / 2;
            }
            else
            {
                worldPosition.x += worldDimensions.x / 2;
            }
            if (worldPosition.y > 0)
            {
                worldPosition.y -= worldDimensions.y / 2;
            }
            else
            {
                worldPosition.y += worldDimensions.y / 2;
            }
            return worldPosition;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetWorldWidthStep()
        {
            return this.worldWidth / this.gridDimensions.GetCol();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetWorldHeightStep()
        {
            return this.worldHeight / this.gridDimensions.GetRow();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        private Vector2 GetWorldDimensionsFrom(ICanvasGridCoordinates gridDimensions)
        {
            return new Vector2(gridDimensions.GetCol() * this.GetWorldWidthStep(),
                gridDimensions.GetRow() * this.GetWorldHeightStep());
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICanvasGridCoordinates gridDimensions = null;

            // Todo
            private float worldHeight = 0f;

            // Todo
            private float worldWidth = 0f;

            /// <summary>
            /// Build the implementation of the object and return it
            /// </summary>
            /// <returns>The new object's interface</returns>
            public IGridConvertor Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new GridCoordinatesConvertor(this.gridDimensions,
                        this.worldWidth, this.worldHeight);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gridDimensions"></param>
            /// <returns></returns>
            public Builder SetGridDimensions(ICanvasGridCoordinates gridDimensions)
            {
                this.gridDimensions = gridDimensions;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="worldWidth"></param>
            /// <returns></returns>
            public Builder SetWorldWidth(float worldWidth)
            {
                this.worldWidth = worldWidth;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="worldHeight"></param>
            /// <returns></returns>
            public Builder SetWorldHeight(float worldHeight)
            {
                this.worldHeight = worldHeight;
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

                if (this.gridDimensions == null)
                {
                    argumentExceptionSet.Add("Dimension " + typeof(ICanvasGridCoordinates) + " cannot be null.");
                }

                if (this.worldHeight <= 0)
                {
                    argumentExceptionSet.Add("worldHeight cannot be less than or equal to 0.");
                }

                if (this.worldWidth <= 0)
                {
                    argumentExceptionSet.Add("worldWidth cannot be less than or equal to 0.");
                }
                return argumentExceptionSet;
            }
        }
    }
}