namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class CanvasGridConvertor
        : ICanvasGridConvertor
    {
        // Todo
        private readonly ICanvasGridCoordinates canvasGridDimensions;

        // Todo
        private readonly float canvasHeight;

        // Todo
        private readonly float canvasWidth;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridDimensions"></param>
        /// <param name="canvasHeight"></param>
        /// <param name="canvasWidth"></param>
        public CanvasGridConvertor(ICanvasGridCoordinates canvasGridDimensions, float canvasWidth, float canvasHeight)
        {
            this.canvasGridDimensions = canvasGridDimensions;
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
        }

        /// <inheritdoc/>
        Vector2 ICanvasGridConvertor.GetCanvasWorldDimensionsFrom(ICanvasGridCoordinates canvasGridDimensions)
        {
            return new Vector2(canvasGridDimensions.GetColIndex() * this.GetCanvasWidthStep(),
                canvasGridDimensions.GetRowIndex() * this.GetCanvasHeightStep());
        }

        /// <inheritdoc/>
        Vector2 ICanvasGridConvertor.GetCanvasWorldPositionFrom(ICanvasGridCoordinates canvasGridPosition,
            ICanvasGridCoordinates canvasGridDimensions)
        {
            Vector2 canvasWorldPosition = new Vector2(
                    (canvasGridPosition.GetColIndex() * this.GetCanvasWidthStep()) - this.canvasWidth / 2,
                    (canvasGridPosition.GetRowIndex() * this.GetCanvasHeightStep()) - this.canvasHeight / 2);
            Vector2 canvasWorldDimensions = this.GetCanvasWorldDimensionsFrom(canvasGridDimensions);
            if (canvasWorldPosition.x > 0)
            {
                canvasWorldPosition.x -= canvasWorldDimensions.x / 2;
            }
            else
            {
                canvasWorldPosition.x += canvasWorldDimensions.x / 2;
            }
            if (canvasWorldPosition.y > 0)
            {
                canvasWorldPosition.y -= canvasWorldDimensions.y / 2;
            }
            else
            {
                canvasWorldPosition.y += canvasWorldDimensions.y / 2;
            }
            return canvasWorldPosition;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetCanvasWidthStep()
        {
            return this.canvasWidth / this.canvasGridDimensions.GetColIndex();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private float GetCanvasHeightStep()
        {
            return this.canvasHeight / this.canvasGridDimensions.GetRowIndex();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridDimensions"></param>
        /// <returns></returns>
        private Vector2 GetCanvasWorldDimensionsFrom(ICanvasGridCoordinates canvasGridDimensions)
        {
            return this.GetCanvasWorldDimensionsFrom(canvasGridDimensions);
        }
    }
}