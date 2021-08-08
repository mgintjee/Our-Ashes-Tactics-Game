using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Positions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Reports.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Coordinates.Grids.Convertors.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IGridConvertor
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IGridDimensions GetGridDimensions();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        Vector2 GetWorldDimensionsFrom(IGridDimensions gridDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetWorldHeight();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridPosition">  </param>
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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetWorldWidth();
    }
}