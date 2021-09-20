using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Dimensions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Canvases.Scripts.Implementations.Abstract;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Entries.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Entries.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanelEntry : AbstractCanvasScript, IPanelEntry
    {
        // Todo
        protected IImageWidget basicWidgetImage;

        // Todo
        protected IGridConvertor panelEntryGridConvertor;

        // Todo
        protected ICanvasGridDimensions panelEntryGridDimensions;

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
            GridConvertorUtil.ApplyCanvasGridMeasurements(this,
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
                /*
                if (widget is IComplexWidget complexWidget)
                {
                    complexWidget.UpdateWidgets();
                }
                */
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
            GridConvertorUtil.ApplyCanvasGridMeasurements(widget,
                this.panelEntryGridConvertor, widgetConfigurationReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="headerString"></param>
        protected void BuildHeader(string headerString,
            ICanvasGridMeasurements CanvasGridMeasurements)
        {
            /*
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
            this.AddWidget(complexWidgetHeader, CanvasGridMeasurements);
            */
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
                panelEntryConfigurationReport.GetDimensions());
            // Apply an offset
            // TODO: Store in a const file
            worldDimensions *= 0.95f;
            // Set the WorldDimensions for this panel
            rectTransform.sizeDelta = worldDimensions;
            // Set the WorldPosition of this panel
            rectTransform.anchoredPosition = panelGridConvertor.GetWorldPositionFrom(
                    panelEntryConfigurationReport.GetCoordinates(),
                    panelEntryConfigurationReport.GetDimensions());
            // Collect the SizeDelta for this Panel
            Vector2 sizeDelta = rectTransform.sizeDelta;
            // Build the CanvasGridConvertor for this Panel
            this.panelEntryGridConvertor = new GridConvertor.Builder()
                .SetDimensions(this.panelEntryGridDimensions)
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
                .SetDimensions(this.panelEntryGridDimensions)
                .SetWorldWidth(sizeDelta.x)
                .SetWorldHeight(sizeDelta.y)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void LoadBackgroundImage()
        {
        }
    }
}