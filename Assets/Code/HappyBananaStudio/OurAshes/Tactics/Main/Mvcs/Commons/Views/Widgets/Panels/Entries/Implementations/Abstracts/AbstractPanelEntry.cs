using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Colors.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Entries.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Entries.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanelEntry : AbstractCanvasScript, IPanelEntry
    {
        // Todo
        protected IBasicImage basicWidgetImage;

        // Todo
        protected IGridConvertor panelEntryGridConvertor;

        // Todo
        protected IGridDimensions panelEntryGridDimensions;

        // Todo
        protected IDictionary<IWidget, ICanvasGridMeasurements> widgetConfigurationReportDictionary =
            new Dictionary<IWidget, ICanvasGridMeasurements>();

        /// <inheritdoc/>
        void IPanelEntry.Initialize(IGridConvertor panelGridConvertor,
            ICanvasGridMeasurements panelEntryConfigurationReport,
            Transform parentTransform)
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.SetParent(parentTransform);
            this.LoadPanelEntryGridDimensions();
            GridConvertorUtil.ApplyGridConfigurationReport(this,
                panelGridConvertor, panelEntryConfigurationReport);
            this.BuildPanelEntryGridConvertor();
            this.LoadBackgroundImage();
        }

        /// <inheritdoc/>
        void IPanelEntry.SetActive(bool isActive)
        {
            this.GetGameObject().SetActive(isActive);
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
        /// <param name="widget">                   </param>
        /// <param name="widgetConfigurationReport"></param>
        protected void AddWidget(IWidget widget,
            ICanvasGridMeasurements widgetConfigurationReport)
        {
            this.widgetConfigurationReportDictionary.Add(
                widget, widgetConfigurationReport);
            GridConvertorUtil.ApplyGridConfigurationReport(widget,
                this.panelEntryGridConvertor, widgetConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="headerString"></param>
        protected void BuildHeader(string headerString,
            ICanvasGridMeasurements gridConfigurationReport)
        {
            // Todo: Maybe have a default BasicImage Builder for background
            IComplexText complexWidgetHeader = new ComplexText.Builder()
                .SetParentTransform(this.GetTransform())
                .SetImageColorID(ColorID.Gray)
                .SetImageSpriteID(SpriteID.RoundedSquare)
                .SetImageTransparency(0.0f)
                .SetTextColorID(ColorID.Black)
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
        /// <param name="widget"></param>
        protected void RemoveWidget(IWidget widget)
        {
            this.widgetConfigurationReportDictionary.Remove(widget);
            widget.Destroy();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panelGridConvertor">           </param>
        /// <param name="panelEntryConfigurationReport"></param>
        private void ApplyGridConfiguration(IGridConvertor panelGridConvertor,
            ICanvasGridMeasurements panelEntryConfigurationReport)
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

        /// <summary>
        /// Todo
        /// </summary>
        private void LoadBackgroundImage()
        {
            // Todo: Maybe have a default BasicImage Builder for background
            IWidget backgroundImage = new BasicImage.Builder()
                .SetParentTransform(this.GetTransform())
                .SetSpriteID(SpriteID.Square)
                .SetTransparency(0.5f)
                .SetColorID(ColorID.Gray)
                .Build();
            // TOdo: Store in a const file
            backgroundImage.GetTransform().name = "BackgroundImage";
            this.AddWidget(backgroundImage,
                new GridConfigurationReport.Builder()
                    .SetGridDimensions(this.panelEntryGridDimensions)
                .Build());
        }
    }
}