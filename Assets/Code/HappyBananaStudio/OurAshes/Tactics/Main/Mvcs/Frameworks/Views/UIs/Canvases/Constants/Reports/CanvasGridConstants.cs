using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Impl;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CanvasGridConstants
    {
        // Todo
        private static readonly float rowOffset = 0.0f;

        // Todo
        private static readonly float colOffset = 0.0f;

        // Todo
        private static readonly IGridDimensions canvasGridDimensions = new GridDimensions(11, 9);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGridDimensions GetCanvasGridDimensions()
        {
            return canvasGridDimensions;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static float GetRowOffset()
        {
            return rowOffset;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static float GetColOffset()
        {
            return colOffset;
        }
    }
}