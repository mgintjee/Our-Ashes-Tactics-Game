using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Canvases.Scripts.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractWidget : AbstractCanvasScript, IWidget
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