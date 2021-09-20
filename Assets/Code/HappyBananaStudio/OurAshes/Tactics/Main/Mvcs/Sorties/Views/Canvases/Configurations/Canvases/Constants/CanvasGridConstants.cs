using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Configurations.Canvases.Constants
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class CanvasGridConstants
    {
        // Todo
        private static readonly ICanvasGridDimensions canvasGridDimensions = new CanvasGridDimensions(11, 9);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasGridDimensions GetCanvasGridDimensions()
        {
            return canvasGridDimensions;
        }
    }
}