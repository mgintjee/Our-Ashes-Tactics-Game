using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Dimensions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Dimensions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Configurations.Canvases.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CanvasGridConstants
    {
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
    }
}