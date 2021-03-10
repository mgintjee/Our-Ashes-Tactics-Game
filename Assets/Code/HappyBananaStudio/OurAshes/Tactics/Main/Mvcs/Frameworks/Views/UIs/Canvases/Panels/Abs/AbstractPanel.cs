namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Abs
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Loggers.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants.Reports;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Panels.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Colors.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Sprites.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Scripts.Unity.Abs;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanel
        : AbstractUnityScript, IPanel
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        protected ISet<IComplexWidget> complexWidgetSet = new HashSet<IComplexWidget>();

        // Todo
        protected IBasicImage basicWidgetImage;

        // Todo
        protected ICanvasConfigurationReport canvasConfigurationReport;

        /// <summary>
        /// Todo
        /// </summary>
        public void Awake()
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.basicWidgetImage = new BasicImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSpriteId(SpriteId.Square)
                .SetTransparency(0.5f)
                .SetColorId(ColorId.Gray)
                .Build();
        }

        /// <inheritdoc/>
        void IPanel.UpdatePanelEntries()
        {
            this.UpdateCanvasEntryWidgets();
        }

        /// <inheritdoc/>
        ICanvasConfigurationReport IPanel.GetCanvasConfigurationReport()
        {
            return this.canvasConfigurationReport;
        }

        /// <inheritdoc/>
        protected void AddWidget(IComplexWidget complexWidget, ICanvasConfigurationReport canvasConfigurationReport)
        {
            this.complexWidgetSet.Add(complexWidget);
            complexWidget.SetWidgetDimensions(this.canvasGridConvertor.GetWidgetDimensionsFrom(
                canvasConfigurationReport.GetCanvasGridDimensions()));
            complexWidget.SetWidgetPosition(this.canvasGridConvertor.GetWidgetPositionFrom(
                canvasConfigurationReport.GetCanvasGridPosition(), canvasConfigurationReport.GetCanvasGridDimensions()));
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected virtual void UpdateCanvasEntryWidgets()
        {
            foreach (IComplexWidget complexWidget in this.complexWidgetSet)
            {
                complexWidget.UpdateWidgets();
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasConfigurationReport"></param>
        protected virtual void SetCanvasConfigurationReport(ICanvasConfigurationReport canvasConfigurationReport)
        {
            this.canvasConfigurationReport = canvasConfigurationReport;
            this.SetCanvasGridDimensions(canvasConfigurationReport.GetCanvasGridDimensions());
            this.SetCanvasGridPosition(canvasConfigurationReport.GetCanvasGridPosition());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridDimensions"></param>
        protected virtual void SetCanvasGridDimensions(ICanvasGridCoordinates canvasGridDimensions)
        {
            Vector2 worldDimensions = UIGridUtil.GetUIDimensionsFrom(canvasGridDimensions);
            this.GetComponent<RectTransform>().sizeDelta = worldDimensions;
            worldDimensions.x -= CanvasGridConstants.GetColOffset();
            worldDimensions.y -= CanvasGridConstants.GetRowOffset();
            this.basicWidgetImage.SetWidgetDimensions(worldDimensions);
            logger.Debug("?", this.basicWidgetImage.GetRectTransform().sizeDelta);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridPosition"></param>
        protected virtual void SetCanvasGridPosition(ICanvasGridCoordinates canvasGridPosition)
        {
            this.GetComponent<RectTransform>().anchoredPosition =
                UIGridUtil.GetUIPositionFrom(canvasGridPosition, this.canvasConfigurationReport.GetCanvasGridDimensions());
        }
    }
}