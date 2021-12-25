using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Builders.Impls
{
    /// <summary>
    /// Abstract Widget Builder Impl
    /// </summary>
    public abstract class AbstractWidgetBuilder<T>
        : AbstractScriptBuilder<T>, IWidgetBuilder<T>
    {
        // Todo
        protected IWidgetGridSpec widgetGridSpec;

        // Todo
        protected bool interactable;

        // Todo
        protected int canvasLevel;

        // Todo
        protected IMvcViewCanvas mvcViewCanvas;

        IWidgetBuilder<T> IWidgetBuilder<T>.SetWidgetGridSpec(IWidgetGridSpec widgetGridSpec)
        {
            this.widgetGridSpec = widgetGridSpec;
            return this;
        }

        IWidgetBuilder<T> IWidgetBuilder<T>.SetInteractable(bool interactable)
        {
            this.interactable = interactable;
            return this;
        }

        IWidgetBuilder<T> IWidgetBuilder<T>.SetCanvasLevel(int canvasLevel)
        {
            this.canvasLevel = canvasLevel;
            return this;
        }

        IWidgetBuilder<T> IWidgetBuilder<T>.SetMvcViewCanvas(IMvcViewCanvas mvcViewCanvas)
        {
            this.mvcViewCanvas = mvcViewCanvas;
            return this;
        }

        protected override void ValidateScriptBuilder(ISet<string> invalidReasons)
        {
            this.Validate(invalidReasons, this.widgetGridSpec);
            if (this.widgetGridSpec != null)
            {
                this.Validate(invalidReasons, this.widgetGridSpec.GetGridCoords());
                this.Validate(invalidReasons, this.widgetGridSpec.GetGridSize());
            }
            this.Validate(invalidReasons, this.interactable);
            this.Validate(invalidReasons, this.canvasLevel);
            this.Validate(invalidReasons, this.mvcViewCanvas);
            this.ValidateWidgetBuilder(invalidReasons);
        }

        protected virtual void ValidateWidgetBuilder(ISet<string> invalidReasons)
        {
        }

        protected void ApplyCommonValues(ICanvasWidget canvasWidget)
        {
            this.ApplyScriptValues(canvasWidget);
            canvasWidget.SetWidgetGridSpec(this.widgetGridSpec);
            canvasWidget.SetInteractable(this.interactable);
            canvasWidget.SetCanvasLevel(this.canvasLevel);
        }
    }
}