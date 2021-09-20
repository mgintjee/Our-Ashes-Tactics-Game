using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces
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
        /// <param name="CanvasGridMeasurements"></param>
        /// <returns></returns>
        Vector2 GetWorldPositionFrom(ICanvasGridMeasurements CanvasGridMeasurements);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetWorldWidth();
    }
}