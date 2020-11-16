namespace HappyBananaStudio.OurAshes.Tactics.Abs.UIs.WidgetUIs.Complex
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Abstract ComplexWidget Impl
    /// </summary>
    public abstract class AbstractComplexWidgetImpl
        : AbstractWidgetUIImpl
    {
        // Todo
        protected ISet<IWidgetUI> childWidgetSet = new HashSet<IWidgetUI>();

        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.LoadChildWidgets();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void LoadChildWidgets();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="dimensionVector">
        /// </param>
        protected override void UpdateWidgetDimensions(Vector2 dimensionVector)
        {
            this.UpdateChildWidgetDimensions(dimensionVector);
            this.UpdateChildWidgetPosition(dimensionVector);
            base.UpdateWidgetDimensions(dimensionVector);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newDimensions">
        /// </param>
        private void UpdateChildWidgetDimensions(Vector2 newDimensions)
        {
            Vector2 oldDimensions = this.GetComponent<RectTransform>().sizeDelta;
            Vector2 newProportions = newDimensions / oldDimensions;
            foreach (IWidgetUI childWidgetUI in this.childWidgetSet)
            {
                Vector2 newChildDimensions = childWidgetUI.GetRectTransform().sizeDelta * newProportions;
                childWidgetUI.UpdateWidgetDimensions(newChildDimensions);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newDimensions">
        /// </param>
        private void UpdateChildWidgetPosition(Vector2 newDimensions)
        {
            Vector2 oldDimensions = this.GetComponent<RectTransform>().sizeDelta;
            Vector2 dimensionsProportions = new Vector2(0, 0);
            if (oldDimensions.x != 0)
            {
                dimensionsProportions.x = newDimensions.x / oldDimensions.x;
            }
            if (oldDimensions.y != 0)
            {
                dimensionsProportions.y = newDimensions.y / oldDimensions.y;
            }
            logger.Debug("Update=?, oldDimensions=?, newDimensions=?, dimensionsProportions: ?",
                this.GetType(), oldDimensions, newDimensions, dimensionsProportions);
            foreach (IWidgetUI childWidgetUI in this.childWidgetSet)
            {
                Vector2 newChildPosition = childWidgetUI.GetRectTransform().anchoredPosition * dimensionsProportions;
                logger.Debug("Update=?, oldChildPosition=?, newChildPosition=?", childWidgetUI.GetType(),
                    childWidgetUI.GetRectTransform().anchoredPosition, newChildPosition);
                childWidgetUI.UpdateWidgetPosition(newChildPosition);
            }
        }
    }
}
