using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Configurations.Grids.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class PanelCanvasGridMeasurementsConstants
    {
        // Todo
        private static readonly ICanvasGridDimensions ActionMenuGridDimensions =
            new CanvasGridDimensions(1.5f, 6.5f);

        // Todo
        private static readonly ICanvasGridCoordinates ActionMenuGridPosition =
            new CanvasGridCoordinates(0.0f, 1.0f);

        // Todo
        private static readonly ICanvasGridDimensions InformationalGridDimensions =
            new CanvasGridDimensions(3.5f, 7.5f);

        // Todo
        private static readonly ICanvasGridCoordinates InformationalGridPosition =
            new CanvasGridCoordinates(7.5f, 0.0f);

        // Todo
        private static readonly ICanvasGridDimensions ScoreBoardGridDimensions =
            new CanvasGridDimensions(3.5f, 1.5f);

        // Todo
        private static readonly ICanvasGridCoordinates ScoreBoardGridPosition =
            new CanvasGridCoordinates(7.5f, 7.5f);

        // Todo
        private static readonly ICanvasGridDimensions SettingMenuGridDimensions =
            new CanvasGridDimensions(1.5f, 1.0f);

        // Todo
        private static readonly ICanvasGridCoordinates SettingMenuGridPosition =
            new CanvasGridCoordinates(0.0f, 0.0f);

        // Todo
        private static readonly ICanvasGridDimensions TurnScrollerGridDimensions =
            new CanvasGridDimensions(7.5f, 1.5f);

        // Todo
        private static readonly ICanvasGridCoordinates TurnScrollerGridPosition =
            new CanvasGridCoordinates(0.0f, 7.5f);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements ActionMenuConfigurationReport()
        {
            return CanvasGridMeasurements.Builder.Get()
                .SetDimensions(ActionMenuGridDimensions)
                .SetCoordinates(ActionMenuGridPosition)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements InformationalConfigurationReport()
        {
            return CanvasGridMeasurements.Builder.Get()
                .SetDimensions(InformationalGridDimensions)
                .SetCoordinates(InformationalGridPosition)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements ScoreBoardConfigurationReport()
        {
            return CanvasGridMeasurements.Builder.Get()
                .SetDimensions(ScoreBoardGridDimensions)
                .SetCoordinates(ScoreBoardGridPosition)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements SettingMenuConfigurationReport()
        {
            return CanvasGridMeasurements.Builder.Get()
                .SetDimensions(SettingMenuGridDimensions)
                .SetCoordinates(SettingMenuGridPosition)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridMeasurements TurnScrollerConfigurationReport()
        {
            return CanvasGridMeasurements.Builder.Get()
                .SetDimensions(TurnScrollerGridDimensions)
                .SetCoordinates(TurnScrollerGridPosition)
                .Build();
        }
    }
}