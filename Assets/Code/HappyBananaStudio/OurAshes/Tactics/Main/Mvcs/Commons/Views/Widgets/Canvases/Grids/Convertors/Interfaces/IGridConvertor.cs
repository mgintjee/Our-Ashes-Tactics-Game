using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Positions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Coordinates.Grids.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Coordinates.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Measures.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Grids.Convertors.Interfaces
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
        ICanvasGridDimensions GetGridDimensions();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridDimensions"></param>
        /// <returns></returns>
        Vector2 GetWorldDimensionsFrom(ICanvasGridDimensions gridDimensions);

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
        Vector2 GetWorldPositionFrom(ICanvasGridCoordinates gridPosition,
            ICanvasGridDimensions gridDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gridConfigurationReport"></param>
        /// <returns></returns>
        Vector2 GetWorldPositionFrom(ICanvasGridMeasurements gridConfigurationReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetWorldWidth();
    }
}