namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Grids
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Impl;

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
                .SetGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetCol(2).SetRow(5)
                    .Build())
                .SetGridPosition(new CanvasGridCoordinates.Builder()
                    .SetCol(0).SetRow(1)
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
                .SetGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetCol(2).SetRow(2)
                    .Build())
                .SetGridPosition(new CanvasGridCoordinates.Builder()
                    .SetCol(0).SetRow(9)
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
                .SetGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetCol(2).SetRow(6)
                    .Build())
                .SetGridPosition(new CanvasGridCoordinates.Builder()
                    .SetCol(11).SetRow(1)
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
                .SetGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetCol(5).SetRow(1)
                    .Build())
                .SetGridPosition(new CanvasGridCoordinates.Builder()
                    .SetCol(3).SetRow(9)
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
                .SetGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetCol(2).SetRow(1)
                    .Build())
                .SetGridPosition(new CanvasGridCoordinates.Builder()
                    .SetCol(11).SetRow(9)
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
                .SetGridDimensions(new CanvasGridCoordinates.Builder()
                    .SetCol(7).SetRow(2)
                    .Build())
                .SetGridPosition(new CanvasGridCoordinates.Builder()
                    .SetCol(2).SetRow(0)
                    .Build())
                .Build();
        }
    }
}