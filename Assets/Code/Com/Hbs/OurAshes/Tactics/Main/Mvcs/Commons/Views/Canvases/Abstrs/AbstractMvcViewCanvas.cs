using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Inters;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs
{
    /// <summary>
    /// Mvc View Canvas Interface
    /// </summary>
    public abstract class AbstractMvcViewCanvas
        : AbstractCanvasScript, IMvcViewCanvas
    {
        // Todo
        protected ICanvasScript mvcViewCanvasScript;

        // Todo
        protected IDictionary<int, ISet<ICanvasWidget>> canvasLevelWidgets = new Dictionary<int, ISet<ICanvasWidget>>();

        // Todo
        protected ICanvasGridConvertor gridConvertor;

        // Todo
        protected Vector2 gridSize;

        public void SetGridSize(Vector2 gridSize)
        {
            this.gridSize = gridSize;
            Vector2 worldSize = new Vector2(this.GetRectTransform().sizeDelta.x,
                this.GetRectTransform().sizeDelta.y);
            this.gridConvertor = new CanvasGridConvertorImpl(gridSize, worldSize);
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Build()
        {
            ((IMvcViewCanvas)this).Clear();
            this.InternalBuild();
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Clear()
        {
            foreach (int canvasLevel in this.canvasLevelWidgets.Keys)
            {
                foreach (ICanvasWidget canvasWidget in this.canvasLevelWidgets[canvasLevel])
                {
                    canvasWidget.Destroy();
                }
            }
            this.canvasLevelWidgets.Clear();
        }

        /// <inheritdoc/>
        void IMvcViewCanvas.Reset()
        {
            throw new System.NotImplementedException();
        }

        void IMvcViewCanvas.Process(IMvcModelState mvcModelState)
        {
            throw new NotImplementedException();
        }

        Optional<ICanvasWidget> IMvcViewCanvas.GetWidget(IMvcControlInput mvcControlInput)
        {
            List<int> canvasLevels = new List<int>(this.canvasLevelWidgets.Keys);
            canvasLevels.Sort();
            canvasLevels.Reverse();
            foreach (int canvasLevel in canvasLevels)
            {
                foreach (ICanvasWidget canvasWidget in this.canvasLevelWidgets[canvasLevel])
                {
                    if (canvasWidget.IsInputOnWidget(mvcControlInput))
                    {
                        return Optional<ICanvasWidget>.Of(canvasWidget);
                    }
                }
            }
            return Optional<ICanvasWidget>.Empty();
        }

        protected void AddWidget(ICanvasWidget widget)
        {
            ICanvasWidgetSpec canvasWidgetSpec = widget.GetCanvasWidgetSpec();
            if (!this.canvasLevelWidgets.ContainsKey(canvasWidgetSpec.GetLevel()))
            {
                this.canvasLevelWidgets[canvasWidgetSpec.GetLevel()] = new HashSet<ICanvasWidget>();
            }
            this.canvasLevelWidgets[canvasWidgetSpec.GetLevel()].Add(widget);
            CanvasGridConvertorUtil.ApplyCanvasGridMeasurements(widget,
                this.gridConvertor, canvasWidgetSpec.GetGridSize(), canvasWidgetSpec.GetGridCoords());
        }

        protected abstract void InternalBuild();
    }
}