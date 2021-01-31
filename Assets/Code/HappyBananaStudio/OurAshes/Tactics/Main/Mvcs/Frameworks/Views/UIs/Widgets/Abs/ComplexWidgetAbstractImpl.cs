namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Api;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class ComplexWidgetAbstractImpl
        : BasicWidgetAbstractImpl
    {
        // Todo
        protected ISet<IWidget> childWidgetSet = new HashSet<IWidget>();

        /// <inheritdoc/>
        protected override void SetWidgetDimensions(Vector2 widgetDimensions)
        {
            this.SetChildWidgetDimensions(widgetDimensions);
            this.SetChildWidgetPosition(widgetDimensions);
            base.SetWidgetDimensions(widgetDimensions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetDimensions"></param>
        private void SetChildWidgetDimensions(Vector2 widgetDimensions)
        {
            Vector2 oldWidgetDimensions = this.widgetDimensions;
            Vector2 widgetProportions = widgetDimensions / oldWidgetDimensions;
            foreach (IWidget childWidget in this.childWidgetSet)
            {
                Vector2 newChildWidgetDimensions = childWidget.GetRectTransform().sizeDelta * widgetProportions;
                childWidget.SetWidgetDimensions(newChildWidgetDimensions);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetDimensions"></param>
        private void SetChildWidgetPosition(Vector2 widgetDimensions)
        {
            Vector2 oldWidgetDimensions = this.widgetDimensions;
            Vector2 widgetProportions = new Vector2(0, 0);
            if (oldWidgetDimensions.x != 0)
            {
                widgetProportions.x = widgetDimensions.x / oldWidgetDimensions.x;
            }
            if (oldWidgetDimensions.y != 0)
            {
                widgetProportions.y = widgetDimensions.y / oldWidgetDimensions.y;
            }
            foreach (IWidget childWidget in this.childWidgetSet)
            {
                Vector2 newChildWidgetPosition = childWidget.GetRectTransform().anchoredPosition * widgetProportions;
                childWidget.SetWidgetPosition(newChildWidgetPosition);
            }
        }
    }
}