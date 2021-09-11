namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Configurations.Grids.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class PanelGridConfigurationReportConstants
    {
        // Todo
        private static readonly IGridDimensions ActionMenuGridDimensions =
            new GridDimensions(1.5f, 6.5f);

        // Todo
        private static readonly IGridPosition ActionMenuGridPosition =
            new GridPosition(0.0f, 1.0f);

        // Todo
        private static readonly IGridDimensions InformationalGridDimensions =
            new GridDimensions(3.5f, 7.5f);

        // Todo
        private static readonly IGridPosition InformationalGridPosition =
            new GridPosition(7.5f, 0.0f);

        // Todo
        private static readonly IGridDimensions ScoreBoardGridDimensions =
            new GridDimensions(3.5f, 1.5f);

        // Todo
        private static readonly IGridPosition ScoreBoardGridPosition =
            new GridPosition(7.5f, 7.5f);

        // Todo
        private static readonly IGridDimensions SettingMenuGridDimensions =
            new GridDimensions(1.5f, 1.0f);

        // Todo
        private static readonly IGridPosition SettingMenuGridPosition =
            new GridPosition(0.0f, 0.0f);

        // Todo
        private static readonly IGridDimensions TurnScrollerGridDimensions =
            new GridDimensions(7.5f, 1.5f);

        // Todo
        private static readonly IGridPosition TurnScrollerGridPosition =
            new GridPosition(0.0f, 7.5f);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements ActionMenuConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(ActionMenuGridDimensions)
                .SetGridPosition(ActionMenuGridPosition)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements InformationalConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(InformationalGridDimensions)
                .SetGridPosition(InformationalGridPosition)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements ScoreBoardConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(ScoreBoardGridDimensions)
                .SetGridPosition(ScoreBoardGridPosition)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements SettingMenuConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(SettingMenuGridDimensions)
                .SetGridPosition(SettingMenuGridPosition)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements TurnScrollerConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(TurnScrollerGridDimensions)
                .SetGridPosition(TurnScrollerGridPosition)
                .Build();
        }
    }
}