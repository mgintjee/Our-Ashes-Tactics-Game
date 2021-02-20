namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblem.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Canvas.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.ResourceLoaders.Sprites;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractCanvas
        : AbstractUnityScript, ICanvas
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        protected ISet<IComplexWidget> complexWidgetSet = new HashSet<IComplexWidget>();

        // Todo
        protected ICanvasGridCoordinates canvasGridDimensions;

        // Todo
        protected ICanvasGridCoordinates canvasGridPosition;

        // Todo
        protected IBasicWidgetImage basicWidgetImage;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.basicWidgetImage = new BasicWidgetImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSprite(SpriteResourceLoader.LoadSpriteResource(EmblemId.Square))
                .SetTransparency(0.5f)
                .SetColor(Color.gray)
                .Build();
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
            foreach (IComplexWidget complexWidget in this.complexWidgetSet)
            {
                complexWidget.UpdateValues();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasConfigurationReport"></param>
        protected virtual void SetCanvasConfigurationReport(ICanvasConfigurationReport canvasConfigurationReport)
        {
            this.SetDimensionCanvasGridCoordinates(canvasConfigurationReport.GetDimensionCanvasGridCoordinates());
            this.SetPositionCanvasGridCoordinates(canvasConfigurationReport.GetPositionCanvasGridCoordinates());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridCoordinates"></param>
        protected virtual void SetDimensionCanvasGridCoordinates(ICanvasGridCoordinates canvasGridCoordinates)
        {
            logger.Debug("Setting canvasGridDimensions: ?", canvasGridCoordinates);
            this.canvasGridDimensions = canvasGridCoordinates;
            Vector2 worldDimensions = CanvasGridUtil.GetWidgetDimensionsFrom(this.canvasGridDimensions);
            logger.Debug("Setting worldDimensions: ?", worldDimensions);
            this.GetComponent<RectTransform>().sizeDelta = worldDimensions;
            worldDimensions.x -= CanvasGridConstants.GetColOffset();
            worldDimensions.y -= CanvasGridConstants.GetRowOffset();
            this.basicWidgetImage.SetWidgetDimensions(worldDimensions);
            logger.Debug("?", this.basicWidgetImage.GetRectTransform().sizeDelta);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridCoordinates"></param>
        protected virtual void SetPositionCanvasGridCoordinates(ICanvasGridCoordinates canvasGridCoordinates)
        {
            logger.Debug("Setting canvasGridPosition: ?", canvasGridCoordinates);
            this.canvasGridPosition = canvasGridCoordinates;
            this.GetComponent<RectTransform>().anchoredPosition =
                CanvasGridUtil.GetWidgetPositionFrom(this.canvasGridPosition, this.canvasGridDimensions);
        }
    }
}