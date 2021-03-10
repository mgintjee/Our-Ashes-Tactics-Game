namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils
{
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class UIGridUtil
    {
        // Todo
        private static CanvasGridConvertor uiGridConvertor;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="uiGridDimensions">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 GetUIDimensionsFrom(ICanvasGridCoordinates uiGridDimensions)
        {
            return uiGridConvertor.GetCanvasWorldDimensionsFrom(uiGridDimensions);
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
        public static Vector2 GetUIPositionFrom(ICanvasGridCoordinates uiGridPosition,
            ICanvasGridCoordinates uiGridDimensions)
        {
            return uiGridConvertor.GetCanvasWorldPositionFrom(uiGridPosition, uiGridDimensions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="uiWidth"></param>
        /// <param name="uiHeight"></param>
        public static void SetUIWorldDimensions(float uiWidth, float uiHeight)
        {
            uiGridConvertor = new CanvasGridConvertor(
                CanvasGridConstants.GetCanvasGridDimensions(), uiWidth, uiHeight);
        }
    }
}