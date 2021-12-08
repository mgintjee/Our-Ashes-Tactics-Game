using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Coordinates.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs
{
    /// <summary>
    /// Mvc View Canvas Interface
    /// </summary>
    public abstract class AbstractMvcViewCanvas : CanvasScript, IMvcViewCanvas
    {
        // Todo
        protected ISet<IWidget> widgets = new HashSet<IWidget>();

        // Todo
        protected ICanvasGridMeasurements canvasGridMeasurements;

        // Todo
        private IGridConvertor gridConvertor;

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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="click"></param>
        /// <returns></returns>
        Optional<Action> IMvcViewCanvas.CanvasAction(IInput click)
        {
            // Todo: Calculate where the click falls pending on the canvas
            throw new NotImplementedException();
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