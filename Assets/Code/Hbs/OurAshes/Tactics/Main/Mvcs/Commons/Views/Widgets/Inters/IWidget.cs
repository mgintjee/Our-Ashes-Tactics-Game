using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Inters;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Inters
{
    /// <summary>
    /// Mvc View Canvas Widget Interface
    /// </summary>
    public interface IWidget : ICanvasScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetDimensions"></param>
        void SetWidgetDimensions(Vector2 widgetDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetPosition"></param>
        void SetWidgetPosition(Vector2 widgetPosition);
    }
}