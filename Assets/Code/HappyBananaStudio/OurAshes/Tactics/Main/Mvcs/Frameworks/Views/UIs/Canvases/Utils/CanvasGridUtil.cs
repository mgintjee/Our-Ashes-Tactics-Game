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
        private static ICanvasGridConvertor canvasGridConvertor;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="uiGridDimensions">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 GetCanvasWorldDimensionsFrom(ICanvasGridCoordinates uiGridDimensions)
        {
            return canvasGridConvertor.GetCanvasWorldDimensionsFrom(uiGridDimensions);
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
            return canvasGridConvertor.GetCanvasWorldPositionFrom(uiGridPosition, uiGridDimensions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="uiWidth"></param>
        /// <param name="uiHeight"></param>
        public static void SetUIWorldDimensions(float uiWidth, float uiHeight)
        {
            canvasGridConvertor = new CanvasGridConvertor.Builder()
                .SetCanvasGridDimensions(CanvasGridConstants.GetCanvasGridDimensions())
                .SetCanvasHeight(uiHeight)
                .SetCanvasWidth(uiWidth)
                .Build();
        }
    }
}