using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Positions.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Reports.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IGridConfigurationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridDimensions GetGridDimensions();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridPosition GetGridPosition();
    }
}