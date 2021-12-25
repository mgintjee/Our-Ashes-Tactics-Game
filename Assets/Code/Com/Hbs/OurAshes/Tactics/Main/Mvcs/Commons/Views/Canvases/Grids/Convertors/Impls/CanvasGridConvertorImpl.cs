using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasGridConvertorImpl
        : ICanvasGridConvertor
    {
        // Todo
        private readonly Vector2 gridSize;

        // Todo
        private readonly Vector2 worldSize;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridSize"> </param>
        /// <param name="worldSize"></param>
        public CanvasGridConvertorImpl(Vector2 gridSize, Vector2 worldSize)
        {
            this.gridSize = gridSize;
            this.worldSize = worldSize;
        }

        /// <inheritdoc/>
        Vector2 ICanvasGridConvertor.GetGridSize()
        {
            return this.gridSize;
        }

        /// <inheritdoc/>
        Vector2 ICanvasGridConvertor.GetWorldSize(Vector2 gridDimensions)
        {
            return this.GetWorldDimensionsFrom(gridDimensions);
        }

        /// <inheritdoc/>
        Vector2 ICanvasGridConvertor.GetWorldCoords(Vector2 gridCoords, Vector2 gridSize)
        {
            return this.GetWorldCoords(gridCoords, gridSize);
        }

        /// <inheritdoc/>
        Vector2 ICanvasGridConvertor.GetWorldSize()
        {
            return this.worldSize;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        private Vector2 GetWorldDimensionsFrom(Vector2 gridDimensions)
        {
            return new Vector2(gridDimensions.X * this.GetWorldWidthStep(),
                   gridDimensions.Y * this.GetWorldHeightStep());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetWorldHeightStep()
        {
            return (float)(this.worldSize.Y / this.gridSize.Y);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        private Vector2 GetWorldCoords(Vector2 gridCoords, Vector2 gridSize)
        {
            // Check if the position is null
            if (gridCoords == null)
            {
                // Return centered world dimensions
                return Vector2.Zero;
            }
            else
            {
                Vector2 relativeWorldSize = this.GetWorldDimensionsFrom(gridSize);
                Vector2 worldCoords = new Vector2(-this.worldSize.X / 2, -this.worldSize.Y / 2);
                worldCoords.X += relativeWorldSize.X / 2;
                worldCoords.Y += relativeWorldSize.Y / 2;
                worldCoords.X += gridCoords.X * this.GetWorldWidthStep();
                worldCoords.Y += gridCoords.Y * this.GetWorldHeightStep();
                return worldCoords;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetWorldWidthStep()
        {
            return (float)(this.worldSize.X / this.gridSize.X);
        }
    }
}