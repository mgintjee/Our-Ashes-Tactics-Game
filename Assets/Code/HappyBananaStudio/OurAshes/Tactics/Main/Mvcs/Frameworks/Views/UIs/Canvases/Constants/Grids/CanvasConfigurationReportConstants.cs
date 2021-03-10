namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Grids
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Impl;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CanvasConfigurationReportConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport ActionMenuConfigurationReport()
        {
            return new CanvasConfigurationReport.Builder()
                .SetCanvasGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetColIndex(2).SetRowIndex(5)
                    .Build())
                .SetCanvasGridPosition(new CanvasGridCoordinates.Builder()
                    .SetColIndex(0).SetRowIndex(1)
                    .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport GameLoggerConfigurationReport()
        {
            return new CanvasConfigurationReport.Builder()
                .SetCanvasGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetColIndex(2).SetRowIndex(2)
                    .Build())
                .SetCanvasGridPosition(new CanvasGridCoordinates.Builder()
                    .SetColIndex(0).SetRowIndex(9)
                    .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport InformationalConfigurationReport()
        {
            return new CanvasConfigurationReport.Builder()
                .SetCanvasGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetColIndex(2).SetRowIndex(6)
                    .Build())
                .SetCanvasGridPosition(new CanvasGridCoordinates.Builder()
                    .SetColIndex(11).SetRowIndex(1)
                    .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport ScoreBoardConfigurationReport()
        {
            return new CanvasConfigurationReport.Builder()
                .SetCanvasGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetColIndex(5).SetRowIndex(1)
                    .Build())
                .SetCanvasGridPosition(new CanvasGridCoordinates.Builder()
                    .SetColIndex(3).SetRowIndex(9)
                    .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport SettingMenuConfigurationReport()
        {
            return new CanvasConfigurationReport.Builder()
                .SetCanvasGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetColIndex(2).SetRowIndex(1)
                    .Build())
                .SetCanvasGridPosition(new CanvasGridCoordinates.Builder()
                    .SetColIndex(11).SetRowIndex(9)
                    .Build())
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport TurnScrollerConfigurationReport()
        {
            return new CanvasConfigurationReport.Builder()
                .SetCanvasGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetColIndex(7).SetRowIndex(2)
                    .Build())
                .SetCanvasGridPosition(new CanvasGridCoordinates.Builder()
                    .SetColIndex(2).SetRowIndex(0)
                    .Build())
                .Build();
        }
    }
}