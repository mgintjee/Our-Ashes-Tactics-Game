namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.CanvasUIs
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Canvas;
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;
    using UnityEngine;

    /// <summary>
    /// CanvasUI Api
    /// </summary>
    public interface ICanvasUI
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        RectTransform GetRectTransform();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridPosition">
        /// </param>
        /// <param name="canvasGridDimensions">
        /// </param>
        void Initialize(ICanvasGridCoordinates canvasGridPosition, ICanvasGridCoordinates canvasGridDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateEntries();
    }
}
