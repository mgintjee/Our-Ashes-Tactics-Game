namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Constants
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Positions.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Impl;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CanvasConfigurationReportConstants
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGridConfigurationReport ActionMenuConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(new GridDimensions(2, 6))
                .SetGridPosition(new GridPosition(0, 1))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGridConfigurationReport InformationalConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(new GridDimensions(2, 6))
                .SetGridPosition(new GridPosition(11, 1))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGridConfigurationReport ScoreBoardConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(new GridDimensions(5, 1))
                .SetGridPosition(new GridPosition(3, 9))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGridConfigurationReport SettingMenuConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(new GridDimensions(2, 1))
                .SetGridPosition(new GridPosition(11, 9))
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGridConfigurationReport TurnScrollerConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(new GridDimensions(7, 2))
                .SetGridPosition(new GridPosition(2, 0))
                .Build();
        }
    }
}