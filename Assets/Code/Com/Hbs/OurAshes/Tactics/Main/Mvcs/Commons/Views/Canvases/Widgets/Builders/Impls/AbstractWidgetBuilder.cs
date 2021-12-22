using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Inters;
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
        protected ICanvasWidgetSpec canvasWidgetSpec;

        IWidgetBuilder<T> IWidgetBuilder<T>.SetCanvasWidgetSpec(ICanvasWidgetSpec canvasWidgetSpec)
        {
            this.canvasWidgetSpec = canvasWidgetSpec;
            return this;
        }

        protected override void ValidateScriptBuilder(ISet<string> invalidReasons)
        {
            this.Validate(invalidReasons, this.canvasWidgetSpec);
            if (this.canvasWidgetSpec != null)
            {
                this.Validate(invalidReasons, this.canvasWidgetSpec.GetGridCoords());
                this.Validate(invalidReasons, this.canvasWidgetSpec.GetGridSize());
                this.Validate(invalidReasons, this.canvasWidgetSpec.GetWorldCoords());
                this.Validate(invalidReasons, this.canvasWidgetSpec.GetWorldSize());
                this.Validate(invalidReasons, this.canvasWidgetSpec.GetLevel());
                this.Validate(invalidReasons, this.canvasWidgetSpec.GetInteractable());
            }
            this.ValidateWidgetBuilder(invalidReasons);
        }

        protected virtual void ValidateWidgetBuilder(ISet<string> invalidReasons)
        {
        }

        protected void ApplyCommonValues(ICanvasWidget canvasWidget)
        {
            this.ApplyScriptValues(canvasWidget);
            canvasWidget.SetCanvasWidgetSpec(this.canvasWidgetSpec);
        }
    }
}