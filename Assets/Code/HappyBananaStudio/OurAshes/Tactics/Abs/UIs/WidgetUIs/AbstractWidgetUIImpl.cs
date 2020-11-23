namespace HappyBananaStudio.OurAshes.Tactics.Abs.UIs.WidgetUIs
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Unity.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs;
    using UnityEngine;

    /// <summary>
    /// Abstract WidgetUI Impl
    /// </summary>
    public abstract class AbstractWidgetUIImpl
        : AbstractUnityScriptImpl, IWidgetUI
    {
        // Todo
        protected Vector2 widgetDimensions;

        // Todo
        protected Vector2 widgetPosition;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        RectTransform IWidgetUI.GetRectTransform()
        {
            return this.GetComponent<RectTransform>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetDimensions">
        /// </param>
        void IWidgetUI.UpdateWidgetDimensions(Vector2 widgetDimensions)
        {
            this.UpdateWidgetDimensions(widgetDimensions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetPosition">
        /// </param>
        void IWidgetUI.UpdateWidgetPosition(Vector2 widgetPosition)
        {
            this.UpdateWidgetPosition(widgetPosition);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetDimensions">
        /// </param>
        protected virtual void UpdateWidgetDimensions(Vector2 widgetDimensions)
        {
            this.widgetDimensions = widgetDimensions;
            this.GetComponent<RectTransform>().sizeDelta = widgetDimensions;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetPosition">
        /// </param>
        protected virtual void UpdateWidgetPosition(Vector2 widgetPosition)
        {
            this.widgetPosition = widgetPosition;
            this.GetComponent<RectTransform>().anchoredPosition = widgetPosition;
        }
    }
}