using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Impl;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Impl.Informationals.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class PanelEntryInformationalConstants
    {
        // Todo
        private static readonly string INFORMATIONAL_PREFIX = "Informational: ";

        // Todo
        private static readonly IGridDimensions DEFAULT_GRID_DIMENSIONS = new GridDimensions(4, 1);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGridDimensions GetDefaultGridDimensions()
        {
            return DEFAULT_GRID_DIMENSIONS;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IGridConfigurationReport GetDefaultGridConfigurationReport()
        {
            return new GridConfigurationReport.Builder()
                .SetGridDimensions(DEFAULT_GRID_DIMENSIONS)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultHeaderString()
        {
            return INFORMATIONAL_PREFIX + "Default";
        }
    }
}