namespace HappyBananaStudio.OurAshes.Tactics.Abs.UIs.CanvasUIs
{
    using HappyBananaStudio.OurAshes.Tactics.Abs.Unity.Scripts;
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Canvas;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.CanvasUIs;
    using HappyBananaStudio.OurAshes.Tactics.Api.UIs.WidgetUIs.CanvasEntries;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Widgets;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Abstract CanvasUI Impl
    /// </summary>
    public abstract class AbstractCanvasUIImpl
        : AbstractUnityScriptImpl, ICanvasUI
    {
        /// <summary>
        /// Todo
        /// </summary>
        protected Image backgroundImage;

        // Todo
        protected ISet<ICanvasEntryWidget> canvasEntryWidgetSet = new HashSet<ICanvasEntryWidget>();

        // Todo
        [SerializeField] protected ICanvasGridCoordinates canvasGridDimensions;

        // Todo
        [SerializeField] protected ICanvasGridCoordinates canvasGridPosition;

        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.backgroundImage = this.GetGameObject().AddComponent<Image>();
            Color backgroundImageColor = Color.gray;
            backgroundImageColor.a = 0.75f;
            this.backgroundImage.color = backgroundImageColor;
            this.LoadChildWidgets();
        }

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
        RectTransform ICanvasUI.GetRectTransform()
        {
            return this.GetComponent<RectTransform>();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridPosition">
        /// </param>
        /// <param name="canvasGridDimensions">
        /// </param>
        void ICanvasUI.Initialize(ICanvasGridCoordinates canvasGridPosition, ICanvasGridCoordinates canvasGridDimensions)
        {
            this.canvasGridDimensions = canvasGridDimensions;
            this.canvasGridPosition = canvasGridPosition;
            this.GetComponent<RectTransform>().sizeDelta = WidgetGridUtil.GetWidgetDimensionsFrom(
                this.canvasGridDimensions);
            this.GetComponent<RectTransform>().anchoredPosition = WidgetGridUtil.GetWidgetPositionFrom(
                this.canvasGridPosition, this.canvasGridDimensions);
            this.ImplInitialization();
        }

        /// <summary>
        /// Todo
        /// </summary>
        void ICanvasUI.UpdateEntries()
        {
            this.UpdateEntries();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void ImplInitialization();

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void LoadChildWidgets();

        /// <summary>
        /// Todo
        /// </summary>
        protected virtual void UpdateEntries()
        {
            logger.Debug("Updating Children for ?", this.GetType());
            foreach (ICanvasEntryWidget canvasEntryWidget in this.canvasEntryWidgetSet)
            {
                logger.Debug("Updating Child ?", canvasEntryWidget);
                canvasEntryWidget.UpdateEntry();
            }
        }
    }
}
