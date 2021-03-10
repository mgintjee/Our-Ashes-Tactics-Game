namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractBasicWidget
        : AbstractUnityScript, IWidget
    {
        // Todo
        protected Vector2 widgetDimensions;

        // Todo
        protected Vector2 widgetPosition;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.GetGameObject().AddComponent<RectTransform>();
        }

        /// <inheritdoc/>
        RectTransform IWidget.GetRectTransform()
        {
            return this.GetComponent<RectTransform>();
        }

        /// <inheritdoc/>
        void IWidget.SetWidgetDimensions(Vector2 widgetDimensions)
        {
            this.SetWidgetDimensions(widgetDimensions);
        }

        /// <inheritdoc/>
        void IWidget.SetWidgetPosition(Vector2 widgetPosition)
        {
            this.SetWidgetPosition(widgetPosition);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetDimensions"></param>
        protected virtual void SetWidgetDimensions(Vector2 widgetDimensions)
        {
            this.widgetDimensions = widgetDimensions;
            this.GetComponent<RectTransform>().sizeDelta = widgetDimensions;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetPosition"></param>
        protected virtual void SetWidgetPosition(Vector2 widgetPosition)
        {
            this.widgetPosition = widgetPosition;
            this.GetComponent<RectTransform>().anchoredPosition = widgetPosition;
        }
    }
}