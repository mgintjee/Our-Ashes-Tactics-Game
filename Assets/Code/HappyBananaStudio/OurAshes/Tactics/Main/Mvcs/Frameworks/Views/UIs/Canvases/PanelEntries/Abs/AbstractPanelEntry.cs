using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Colors.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Convertors.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Grids.Dimensions.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Loggers.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Sprites.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Grids.Reports.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Unity.Abs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Basics.Images.Impl;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Texts.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Widgets.Complex.Texts.Impl;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.PanelEntries.Abs
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanelEntry
        : AbstractCanvasScript, IPanelEntry
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        protected IDictionary<IWidget, IGridConfigurationReport> widgetConfigurationReportDictionary =
            new Dictionary<IWidget, IGridConfigurationReport>();

        // Todo
        protected IBasicImage basicWidgetImage;

        // Todo
        protected IGridConvertor panelEntryGridConvertor;

        // Todo
        protected IGridDimensions panelEntryGridDimensions;

        /// <inheritdoc/>
        void IPanelEntry.Initialize(IGridConvertor panelGridConvertor,
            IGridConfigurationReport panelEntryConfigurationReport,
            Transform parentTransform)
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.SetParentTransform(parentTransform);
            this.LoadPanelEntryGridDimensions();
            GridConvertorUtil.ApplyGridConfigurationReport(this,
                panelGridConvertor, panelEntryConfigurationReport);
            this.BuildPanelEntryGridConvertor();
            this.LoadBackgroundImage();
        }

        /// <inheritdoc/>
        void IPanelEntry.UpdateWidgets()
        {
            foreach (IWidget widget in this.widgetConfigurationReportDictionary.Keys)
            {
                if (widget is IComplexWidget complexWidget)
                {
                    complexWidget.UpdateWidgets();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widget"></param>
        /// <param name="widgetConfigurationReport"></param>
        protected void AddWidget(IWidget widget,
            IGridConfigurationReport widgetConfigurationReport)
        {
            this.widgetConfigurationReportDictionary.Add(
                widget, widgetConfigurationReport);
            GridConvertorUtil.ApplyGridConfigurationReport(widget,
                this.panelEntryGridConvertor, widgetConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="widget"></param>
        protected void RemoveWidget(IWidget widget)
        {
            this.widgetConfigurationReportDictionary.Remove(widget);
            widget.Destroy();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panelGridConvertor"></param>
        /// <param name="panelEntryConfigurationReport"></param>
        private void ApplyGridConfiguration(IGridConvertor panelGridConvertor,
            IGridConfigurationReport panelEntryConfigurationReport)
        {
            RectTransform rectTransform = this.GetComponent<RectTransform>();
            // Find the WorldDimensions for this panel
            Vector2 worldDimensions = panelGridConvertor.GetWorldDimensionsFrom(
                panelEntryConfigurationReport.GetGridDimensions());
            // Apply an offset
            // TODO: Store in a const file
            worldDimensions *= 0.95f;
            // Set the WorldDimensions for this panel
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this panel
            rectTransform.anchoredPosition = panelGridConvertor.GetWorldPositionFrom(
                    panelEntryConfigurationReport.GetGridPosition(),
                    panelEntryConfigurationReport.GetGridDimensions());
            // Collect the SizeDelta for this Panel
            Vector2 sizeDelta = rectTransform.sizeDelta;
            // Build the CanvasGridConvertor for this Panel
            this.panelEntryGridConvertor = new GridConvertor.Builder()
                .SetGridDimensions(this.panelEntryGridDimensions)
                .SetWorldWidth(sizeDelta.x)
                .SetWorldHeight(sizeDelta.y)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void LoadBackgroundImage()
        {
            // Todo: Maybe have a default BasicImage Builder for background
            IWidget backgroundImage = new BasicImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSpriteId(SpriteId.Square)
                .SetTransparency(0.5f)
                .SetColorId(ColorId.Gray)
                .Build();
            // TOdo: Store in a const file
            backgroundImage.GetTransform().name = "BackgroundImage";
            this.AddWidget(backgroundImage,
                new GridConfigurationReport.Builder()
                    .SetGridDimensions(this.panelEntryGridDimensions)
                .Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="headerString"></param>
        protected void BuildHeader(string headerString,
            IGridConfigurationReport gridConfigurationReport)
        {
            // Todo: Maybe have a default BasicImage Builder for background
            IComplexText complexWidgetHeader = new ComplexText.Builder()
                .SetParentTransform(this.GetTransform())
                .SetImageColorId(ColorId.Gray)
                .SetImageSpriteId(SpriteId.RoundedSquare)
                .SetImageTransparency(0.0f)
                .SetTextColorId(ColorId.Black)
                .SetTextFontSize(15)
                .SetTextFontStyle(FontStyle.Bold)
                .SetTextString(headerString)
                .Build();
            // TOdo: Store in a const file
            complexWidgetHeader.GetTransform().name = "HeaderText";
            this.AddWidget(complexWidgetHeader, gridConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void LoadPanelEntryGridDimensions();

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildPanelEntryGridConvertor()
        {
            // Collect the SizeDelta for this PanelEntry
            Vector2 sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
            // Build the GridConvertor for this PanelEntry
            this.panelEntryGridConvertor = new GridConvertor.Builder()
                .SetGridDimensions(this.panelEntryGridDimensions)
                .SetWorldWidth(sizeDelta.x)
                .SetWorldHeight(sizeDelta.y)
                .Build();
        }
    }
}