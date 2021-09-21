using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Implementations.Abstracts
{
    /// <summary>
    /// Mvc View Canvas Interface
    /// </summary>
    public abstract class AbstractMvcViewCanvas : CanvasScript, IMvcViewCanvas
    {
        // Todo
        protected ISet<IWidget> widgets = new HashSet<IWidget>();

        // Todo
        private IGridConvertor gridConvertor;

        // Todo
        protected ICanvasGridMeasurements canvasGridMeasurements;

        /// <inheritdoc/>
        void IMvcViewCanvas.Build()
        {
            ((IMvcViewCanvas)this).Clear();
            this.InternalBuild();
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Clear()
        {
            foreach (IWidget widget in this.widgets)
            {
                widget.Destroy();
            }
            this.widgets.Clear();
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Reset()
        {
            throw new System.NotImplementedException();
        }

        protected void AddWidget(IWidget widget)
        {
            // Todo: Call the other method and build the thing
            this.AddWidget(widget, CanvasGridMeasurements.Builder.Get()
                .SetCoordinates(new CanvasGridCoordinates(0, 0))
                .SetDimensions(this.gridConvertor.GetGridDimensions())
                .Build());
        }

        protected void AddWidget(IWidget widget, ICanvasGridMeasurements canvasGridMeasurements)
        {
            this.widgets.Add(widget);
            GridConvertorUtil.ApplyCanvasGridMeasurements(widget, this.gridConvertor, canvasGridMeasurements);
        }

        protected void SetMeasurements(ICanvasGridMeasurements canvasGridMeasurements)
        {
            this.canvasGridMeasurements = canvasGridMeasurements;
            this.gridConvertor = GridConvertor.Builder.Get()
                .SetDimensions(canvasGridMeasurements.GetDimensions())
                .SetHeight(((ICanvasScript)this).GetRectTransform().sizeDelta.y)
                .SetWidth(((ICanvasScript)this).GetRectTransform().sizeDelta.x)
                .Build();
        }

        protected abstract void InternalBuild();
    }
}