using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces
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