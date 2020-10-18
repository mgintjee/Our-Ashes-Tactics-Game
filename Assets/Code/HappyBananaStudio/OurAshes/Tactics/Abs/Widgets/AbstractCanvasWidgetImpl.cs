namespace HappyBananaStudio.OurAshes.Tactics.Abs.Widgets
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using UnityEngine;

    /// <summary>
    /// Abstract CanvasWidget Impl
    /// </summary>
    public  class AbstractCanvasWidgetImpl
        : AbstractWidgetImpl, ICanvasWidget
    {
        // Todo
        protected Vector2 dimensionCoordinates;
        // Todo
        protected Vector2 positionCoordinates;
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Vector2 ICanvasWidget.GetDimensionCoordinates()
        {
            return this.dimensionCoordinates;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Vector2 ICanvasWidget.GetPositionCoordinates()
        {
            return this.positionCoordinates;
        }
    }
}
