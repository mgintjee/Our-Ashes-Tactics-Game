namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Canvas.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Widgets.Impl.CanvasEntries.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class CanvasAbstractImpl
        : AbstractUnityScript, ICanvas
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        protected ISet<ICanvasEntryWidget> canvasEntryWidgetSet = new HashSet<ICanvasEntryWidget>();

        // Todo
        [SerializeField] protected ICanvasGridCoordinates canvasGridDimensions;

        // Todo
        [SerializeField] protected ICanvasGridCoordinates canvasGridPosition;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.GetGameObject().AddComponent<RectTransform>();
        }

        /// <inheritdoc/>
        void ICanvas.UpdateWidgets()
        {
            this.UpdateCanvasEntryWidgets();
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected virtual void UpdateCanvasEntryWidgets()
        {
            foreach (ICanvasEntryWidget canvasEntryWidget in this.canvasEntryWidgetSet)
            {
                canvasEntryWidget.UpdateEntry();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridCoordinates"></param>
        protected virtual void SetCanvasGridDimensions(ICanvasGridCoordinates canvasGridCoordinates)
        {
            logger.Debug("Setting canvasGridDimensions: ?", canvasGridCoordinates);
            this.canvasGridDimensions = canvasGridCoordinates;
            this.GetComponent<RectTransform>().sizeDelta =
                CanvasGridUtil.GetWidgetDimensionsFrom(this.canvasGridDimensions);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridCoordinates"></param>
        protected virtual void SetCanvasGridPosition(ICanvasGridCoordinates canvasGridCoordinates)
        {
            logger.Debug("Setting canvasGridPosition: ?", canvasGridCoordinates);
            this.canvasGridPosition = canvasGridCoordinates;
            this.GetComponent<RectTransform>().anchoredPosition =
                CanvasGridUtil.GetWidgetPositionFrom(this.canvasGridPosition, this.canvasGridDimensions);
        }
    }
}