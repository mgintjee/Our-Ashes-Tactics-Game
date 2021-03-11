namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Reports
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Impl;

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
        private static readonly ICanvasGridCoordinates canvasGridDimensions =
            new CanvasGridCoordinates.Builder()
                .SetCol(11)
                .SetRow(9)
                .Build();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridCoordinates GetCanvasGridDimensions()
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