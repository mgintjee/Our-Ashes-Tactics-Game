namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Api;
    using UnityEngine;

    /// <summary>
    /// WidgetUI Api
    /// </summary>
    public interface IWidget
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
        /// <param name="widgetDimensions">
        /// </param>
        void SetWidgetDimensions(Vector2 widgetDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetPosition">
        /// </param>
        void SetWidgetPosition(Vector2 widgetPosition);
    }
}