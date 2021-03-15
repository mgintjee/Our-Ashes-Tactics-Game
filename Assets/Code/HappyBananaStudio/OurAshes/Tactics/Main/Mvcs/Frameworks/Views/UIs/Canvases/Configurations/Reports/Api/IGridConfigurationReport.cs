using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Positions.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Reports.Api
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