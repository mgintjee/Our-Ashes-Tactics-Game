namespace HappyBananaStudio.OurAshes.Tactics.Api.Widgets
{
    using UnityEngine;

    /// <summary>
    /// CanvasWidget Script Api
    /// </summary>
    public interface ICanvasWidget
        : IWidget
    {

        /// <summary>
        /// Todo
        /// </summary>
        Vector2 GetDimensionCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        Vector2 GetPositionCoordinates();
    }
}
