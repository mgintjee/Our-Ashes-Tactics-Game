using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Positions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Reports;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils
{
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
        public static Vector2 GetCanvasWorldDimensionsFrom(IGridDimensions uiGridDimensions)
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
        public static Vector2 GetCanvasWorldPositionFrom(IGridPosition uiGridPosition,
            IGridDimensions uiGridDimensions)
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
            canvasGridConvertor = new GridConvertor.Builder()
                .SetGridDimensions(CanvasGridConstants.GetCanvasGridDimensions())
                .SetWorldHeight(uiHeight)
                .SetWorldWidth(uiWidth)
                .Build();
        }
    }
}