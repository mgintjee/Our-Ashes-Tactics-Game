﻿using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Collections.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc View Canvas Widget Collection Implementation
    /// </summary>
    public abstract class AbstractWidgetCollection : IWidgetCollection
    {
        private ISet<IWidget> widgets;

        void IWidgetCollection.AddWidget(IWidget widget)
        {
            this.widgets.Add(widget);
        }

        void IWidgetCollection.Clear()
        {
            foreach (IWidget widget in this.widgets)
            {
                widget.Destroy();
            }
            this.widgets.Clear();
        }

        void IWidgetCollection.RemoveWidget(IWidget widget)
        {
            widget.Destroy();
            this.widgets.Remove(widget);
        }
    }
}