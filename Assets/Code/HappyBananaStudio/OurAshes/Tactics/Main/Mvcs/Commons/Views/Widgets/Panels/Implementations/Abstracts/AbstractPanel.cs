using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Canvases.Entries.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Panels.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Panels.Implementations.Abstracts
{
    /// <summary>
    /// Todo
    /// </summary>
    public abstract class AbstractPanel : CanvasScript, IPanel
    {
        // Todo
        protected IImageWidget backgroundImage;

        // Todo
        protected IList<IPanelEntry> panelEntryList = new List<IPanelEntry>();

        // Todo
        protected IGridConvertor panelGridConvertor;

        // Todo
        protected ICanvasGridMeasurements panelGridDimensions;

        /// <inheritdoc/>
        void IPanel.ClearPanelEntries()
        {
            // Todo
        }

        /// <inheritdoc/>
        void IPanel.Initialize(IGridConvertor canvasGridConvertor,
            ICanvasGridMeasurements panelConfigurationReport,
            Transform parentTransform)
        {
            this.GetGameObject().AddComponent<RectTransform>();
            this.SetParent(parentTransform);
            GridConvertorUtil.ApplyCanvasGridMeasurements(this,
                canvasGridConvertor, panelConfigurationReport);
            this.BuildPanelGridConvertor();
            this.LoadBackgroundImage();
            this.LoadDefaultPanelEntry();
        }

        /// <inheritdoc/>
        void IPanel.LoadDefaultPanelEntry()
        {
            // Todo
        }

        /// <inheritdoc/>
        void IPanel.SetActive(bool isActive)
        {
            this.GetGameObject().SetActive(isActive);
        }

        /// <inheritdoc/>
        void IPanel.UpdatePanelEntries()
        {
            // Todo
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void LoadBackgroundImage()
        {
        }

        /// <inheritdoc/>
        protected abstract void LoadDefaultPanelEntry();

        /// <summary>
        /// Todo
        /// </summary>
        protected void RemovePanelEntries()
        {
            foreach (IPanelEntry panelEntry in this.panelEntryList)
            {
                panelEntry.Destroy();
            }
            this.panelEntryList.Clear();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="panelEntry"></param>
        protected void RemovePanelEntry(IPanelEntry panelEntry)
        {
            this.panelEntryList.Remove(panelEntry);
            panelEntry.Destroy();
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildPanelGridConvertor()
        {
            // Collect the SizeDelta for this Panel
            Vector2 sizeDelta = this.GetComponent<RectTransform>().sizeDelta;
            // Build the GridConvertor for this Panel
            this.panelGridConvertor = GridConvertor.Builder.Get()
                .SetDimensions(this.panelGridDimensions.GetDimensions())
                .SetWidth(sizeDelta.x)
                .SetHeight(sizeDelta.y)
                .Build();
        }
    }
}