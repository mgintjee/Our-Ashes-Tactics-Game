using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Positions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Impl
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
        /// <param name="worldHeight"></param>
        /// <param name="worldWidth"></param>
        private GridConvertor(IGridDimensions gridDimensions, float worldWidth, float worldHeight)
        {
            this.gridDimensions = gridDimensions;
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
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
        Vector2 IGridConvertor.GetWorldDimensionsFrom(IGridDimensions gridDimensions)
        {
            return this.GetWorldDimensionsFrom(gridDimensions);
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
        private Vector2 GetWorldDimensionsFrom(IGridDimensions gridDimensions)
        {
            return new Vector2(gridDimensions.GetWidth() * this.GetWorldWidthStep(),
                   gridDimensions.GetHeight() * this.GetWorldHeightStep());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        private Vector2 GetWorldPositionFrom(IGridPosition gridPosition,
            IGridDimensions gridDimensions)
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
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
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