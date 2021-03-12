namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Reports;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Impl;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CanvasGridUtil
    {
        // Todo
        private static IGridConvertor canvasGridConvertor;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="uiGridDimensions">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 GetCanvasWorldDimensionsFrom(ICanvasGridCoordinates uiGridDimensions)
        {
            return canvasGridConvertor.GetWorldDimensionsFrom(uiGridDimensions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="uiGridPosition">
        /// </param>
        /// <param name="uiGridDimensions">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 GetCanvasWorldPositionFrom(ICanvasGridCoordinates uiGridPosition,
            ICanvasGridCoordinates uiGridDimensions)
        {
            return canvasGridConvertor.GetWorldPositionFrom(uiGridPosition, uiGridDimensions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="uiWidth"></param>
        /// <param name="uiHeight"></param>
        public static void SetUIWorldDimensions(float uiWidth, float uiHeight)
        {
            canvasGridConvertor = new GridCoordinatesConvertor.Builder()
                .SetGridDimensions(CanvasGridConstants.GetCanvasGridDimensions())
                .SetWorldHeight(uiHeight)
                .SetWorldWidth(uiWidth)
                .Build();
        }
    }
}