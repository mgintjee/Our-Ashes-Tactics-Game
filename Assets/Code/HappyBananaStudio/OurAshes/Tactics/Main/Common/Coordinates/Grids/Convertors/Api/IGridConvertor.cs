using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Positions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IGridConvertor
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        Vector2 GetWorldDimensionsFrom(IGridDimensions gridDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridPosition"></param>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        Vector2 GetWorldPositionFrom(IGridPosition gridPosition,
            IGridDimensions gridDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridConfigurationReport"></param>
        /// <returns></returns>
        Vector2 GetWorldPositionFrom(IGridConfigurationReport gridConfigurationReport);
    }
}