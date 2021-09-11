using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Worlds.Widgets.Implementations.Complexes.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractComplexWidget : AbstractWidget
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
            Vector2 widgetProportions = (oldWidgetDimensions != Vector2.zero) ?
            widgetDimensions / oldWidgetDimensions
                : Vector2.one;
            foreach (IWidget childWidget in this.childWidgetSet)
            {
                Vector2 childSizeDelta = childWidget.GetRectTransform().sizeDelta;
                Vector2 newChildWidgetDimensions = (childSizeDelta != Vector2.zero) ?
                childSizeDelta * widgetProportions
                    : widgetDimensions;
                childWidget.SetWidgetDimensions(newChildWidgetDimensions);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widgetPosition"></param>
        private void SetChildWidgetPosition(Vector2 widgetPosition)
        {
            Vector2 oldWidgetDimensions = this.widgetDimensions;
            Vector2 widgetProportions = new Vector2(0, 0);
            if (oldWidgetDimensions.x != 0)
            {
                widgetProportions.x = widgetPosition.x / oldWidgetDimensions.x;
            }
            if (oldWidgetDimensions.y != 0)
            {
                widgetProportions.y = widgetPosition.y / oldWidgetDimensions.y;
            }
            foreach (IWidget childWidget in this.childWidgetSet)
            {
                Vector2 newChildWidgetPosition = childWidget.GetRectTransform().anchoredPosition * widgetProportions;
                childWidget.SetWidgetPosition(newChildWidgetPosition);
            }
        }
    }
}