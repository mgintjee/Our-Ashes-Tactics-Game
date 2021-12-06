using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Widgets.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Measurements.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Widgets.Impls
{
    /// <summary>
    /// Abstract Widget Builder Implementation
    /// </summary>
    public abstract class AbstractWidgetBuilder<T> : AbstractBuilder<T>, IWidgetBuilder<T>
    {
        // Todo
        protected string name;

        // Todo
        protected IUnityScript unityScript;

        // Todo
        protected ICanvasGridMeasurements canvasGridMeasurements;

        protected override void Validate(ISet<string> invalidReasons)
        {
            this.Validate(invalidReasons, this.name);
            this.Validate(invalidReasons, this.unityScript);
            this.Validate(invalidReasons, this.canvasGridMeasurements);
        }

        IWidgetBuilder<T> IWidgetBuilder<T>.SetName(string name)
        {
            this.name = name;
            return this;
        }

        IWidgetBuilder<T> IWidgetBuilder<T>.SetParent(IUnityScript unityScript)
        {
            this.unityScript = unityScript;
            return this;
        }

        IWidgetBuilder<T> IWidgetBuilder<T>.SetMeasurements(ICanvasGridMeasurements WidgetGridMeasurements)
        {
            this.canvasGridMeasurements = WidgetGridMeasurements;
            return this;
        }

        protected void ApplyCommonParams(IWidget widget)
        {
            widget.GetGameObject().name = this.name;
            widget.SetParent(this.unityScript);
            // Todo: Apply dimensions
        }
    }
}