namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Convertors.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Api;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IGridConvertor
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridDimensions"></param>
        /// <returns></returns>
        Vector2 GetWorldDimensionsFrom(ICanvasGridCoordinates canvasGridDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridPosition"></param>
        /// <param name="canvasGridDimensions"></param>
        /// <returns></returns>
        Vector2 GetWorldPositionFrom(ICanvasGridCoordinates canvasGridPosition,
            ICanvasGridCoordinates canvasGridDimensions);
    }
}