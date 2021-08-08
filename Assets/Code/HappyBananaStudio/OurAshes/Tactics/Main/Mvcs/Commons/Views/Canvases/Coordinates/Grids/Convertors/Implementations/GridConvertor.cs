using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Positions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Reports.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Convertors.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class GridConvertor
        : IGridConvertor
    {
        // Todo
        private readonly IGridDimensions gridDimensions;

        // Todo
        private readonly float worldHeight;

        // Todo
        private readonly float worldWidth;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <param name="worldHeight">   </param>
        /// <param name="worldWidth">    </param>
        private GridConvertor(IGridDimensions gridDimensions, float worldWidth, float worldHeight)
        {
            this.gridDimensions = gridDimensions;
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
        }

        /// <inheritdoc/>
        IGridDimensions IGridConvertor.GetGridDimensions()
        {
            return this.gridDimensions;
        }

        /// <inheritdoc/>
        Vector2 IGridConvertor.GetWorldDimensionsFrom(IGridDimensions gridDimensions)
        {
            return this.GetWorldDimensionsFrom(gridDimensions);
        }

        /// <inheritdoc/>
        float IGridConvertor.GetWorldHeight()
        {
            return worldHeight;
        }

        /// <inheritdoc/>
        Vector2 IGridConvertor.GetWorldPositionFrom(IGridPosition gridPosition, IGridDimensions gridDimensions)
        {
            return this.GetWorldPositionFrom(gridPosition, gridDimensions);
        }

        /// <inheritdoc/>
        Vector2 IGridConvertor.GetWorldPositionFrom(IGridConfigurationReport gridConfigurationReport)
        {
            return this.GetWorldPositionFrom(gridConfigurationReport.GetGridPosition(),
                gridConfigurationReport.GetGridDimensions());
        }

        /// <inheritdoc/>
        float IGridConvertor.GetWorldWidth()
        {
            return this.worldWidth;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        private Vector2 GetWorldDimensionsFrom(IGridDimensions gridDimensions)
        {
            return new Vector2(gridDimensions.GetWidth() * this.GetWorldWidthStep(),
                   gridDimensions.GetHeight() * this.GetWorldHeightStep());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetWorldHeightStep()
        {
            return this.worldHeight / this.gridDimensions.GetHeight();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        private Vector2 GetWorldPositionFrom(IGridPosition gridPosition,
            IGridDimensions gridDimensions)
        {
            // Check if the position is null
            if (gridPosition == null)
            {
                // Return centered world dimensions
                return Vector2.zero;
            }
            else
            {
                Vector2 worldDimensions = this.GetWorldDimensionsFrom(gridDimensions);
                Vector2 canvasWorldStart = new Vector2(-this.worldWidth / 2, -this.worldHeight / 2);
                canvasWorldStart.x += worldDimensions.x / 2;
                canvasWorldStart.y += worldDimensions.y / 2;
                canvasWorldStart.x += gridPosition.GetCol() * this.GetWorldWidthStep();
                canvasWorldStart.y += gridPosition.GetRow() * this.GetWorldHeightStep();
                return canvasWorldStart;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetWorldWidthStep()
        {
            return this.worldWidth / this.gridDimensions.GetWidth();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IGridDimensions gridDimensions = null;

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
                    return new GridConvertor(this.gridDimensions,
                        this.worldWidth, this.worldHeight);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="gridDimensions"></param>
            /// <returns></returns>
            public Builder SetGridDimensions(IGridDimensions gridDimensions)
            {
                this.gridDimensions = gridDimensions;
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
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();

                if (this.gridDimensions == null)
                {
                    argumentExceptionSet.Add(typeof(IGridDimensions) + " cannot be null.");
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