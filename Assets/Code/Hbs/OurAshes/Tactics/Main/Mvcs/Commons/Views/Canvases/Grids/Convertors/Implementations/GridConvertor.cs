using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class GridConvertor : IGridConvertor
    {
        // Todo
        private readonly ICanvasGridDimensions gridDimensions;

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
        private GridConvertor(ICanvasGridDimensions gridDimensions, float worldWidth, float worldHeight)
        {
            this.gridDimensions = gridDimensions;
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
        }

        /// <inheritdoc/>
        ICanvasGridDimensions IGridConvertor.GetGridDimensions()
        {
            return this.gridDimensions;
        }

        /// <inheritdoc/>
        Vector2 IGridConvertor.GetWorldDimensionsFrom(ICanvasGridDimensions gridDimensions)
        {
            return this.GetWorldDimensionsFrom(gridDimensions);
        }

        /// <inheritdoc/>
        float IGridConvertor.GetWorldHeight()
        {
            return worldHeight;
        }

        /// <inheritdoc/>
        Vector2 IGridConvertor.GetWorldPositionFrom(ICanvasGridCoordinates gridPosition, ICanvasGridDimensions gridDimensions)
        {
            return this.GetWorldPositionFrom(gridPosition, gridDimensions);
        }

        /// <inheritdoc/>
        Vector2 IGridConvertor.GetWorldPositionFrom(ICanvasGridMeasurements CanvasGridMeasurements)
        {
            return this.GetWorldPositionFrom(CanvasGridMeasurements.GetCoordinates(),
                CanvasGridMeasurements.GetDimensions());
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
        private Vector2 GetWorldDimensionsFrom(ICanvasGridDimensions gridDimensions)
        {
            return new Vector2((float)(gridDimensions.GetWidth() * this.GetWorldWidthStep()),
                   (float)(gridDimensions.GetHeight() * this.GetWorldHeightStep()));
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetWorldHeightStep()
        {
            return (float)(this.worldHeight / this.gridDimensions.GetHeight());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        private Vector2 GetWorldPositionFrom(ICanvasGridCoordinates gridPosition, ICanvasGridDimensions gridDimensions)
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
                canvasWorldStart.x += (float)(gridPosition.GetX() * this.GetWorldWidthStep());
                canvasWorldStart.y += (float)(gridPosition.GetY() * this.GetWorldHeightStep());
                return canvasWorldStart;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetWorldWidthStep()
        {
            return (float)(this.worldWidth / this.gridDimensions.GetWidth());
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : IBuilder<IGridConvertor>
            {
                IBuilder SetDimensions(ICanvasGridDimensions canvasGridDimensions);

                IBuilder SetWidth(float width);

                IBuilder SetHeight(float height);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IGridConvertor>, IBuilder
            {
                // Todo
                private ICanvasGridDimensions canvasGridDimensions = null;

                // Todo
                private float height = 0f;

                // Todo
                private float width = 0f;

                /// <inheritdoc/>
                protected override IGridConvertor BuildObj()
                {
                    return new GridConvertor(this.canvasGridDimensions, this.width, this.height);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, canvasGridDimensions);
                    this.Validate(invalidReasons, width);
                    this.Validate(invalidReasons, height);
                }

                IBuilder IBuilder.SetDimensions(ICanvasGridDimensions canvasGridDimensions)
                {
                    this.canvasGridDimensions = canvasGridDimensions;
                    return this;
                }

                IBuilder IBuilder.SetHeight(float height)
                {
                    this.height = height;
                    return this;
                }

                IBuilder IBuilder.SetWidth(float width)
                {
                    this.width = width;
                    return this;
                }
            }
        }
    }
}