namespace HappyBananaStudio.OurAshes.Tactics.Abs.Widgets
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Unity.Scripts;
    using UnityEngine;

    /// <summary>
    /// Abstract Widget Impl
    /// </summary>
    public abstract class AbstractWidgetImpl
        : UnityScriptImpl, IWidget
    {
        /// <summary>
        /// Todo
        /// </summary>
        void IWidget.UpdateWidgetDimensions()
        {
            this.GetTransform().localPosition = Vector3.zero;
        }

        /// <summary>
        /// Todo
        /// </summary>
        void IWidget.UpdateWidgetPosition()
        {
            this.GetTransform().localScale= Vector3.one;
        }
    }
}
