namespace HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;
    using UnityEngine;

    /// <summary>
    /// WidgetUI Api
    /// </summary>
    public interface IWidgetUI
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
        void UpdateWidgetDimensions(Vector2 widgetDimensions);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetPosition">
        /// </param>
        void UpdateWidgetPosition(Vector2 widgetPosition);
    }
}
