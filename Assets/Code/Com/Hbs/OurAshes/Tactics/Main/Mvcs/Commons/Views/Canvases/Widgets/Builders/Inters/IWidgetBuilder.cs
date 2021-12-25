using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Builders.Inters
{
    /// <summary>
    /// Widget Builder class Interface
    /// </summary>
    public interface IWidgetBuilder<T>
        : IScriptBuilder<T>
    {
        IWidgetBuilder<T> SetWidgetGridSpec(IWidgetGridSpec widgetGridSpec);

        IWidgetBuilder<T> SetInteractable(bool interactable);

        IWidgetBuilder<T> SetCanvasLevel(int canvasLevel);

        IWidgetBuilder<T> SetMvcViewCanvas(IMvcViewCanvas mvcViewCanvas);
    }
}