using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Builders.Inters
{
    /// <summary>
    /// Widget Builder class Interface
    /// </summary>
    public interface IWidgetBuilder<T>
        : IScriptBuilder<T>
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IWidgetBuilder<T> SetCanvasWidgetSpec(ICanvasWidgetSpec canvasWidgetSpec);
    }
}