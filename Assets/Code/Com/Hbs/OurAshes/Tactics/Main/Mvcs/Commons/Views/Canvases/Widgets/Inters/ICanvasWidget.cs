using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters
{
    /// <summary>
    /// Mvc View Canvas Widget Interface
    /// </summary>
    public interface ICanvasWidget
        : ICanvasScript
    {
        bool IsInputOnWidget(IMvcControlInput mvcControlInput);

        ICanvasWidgetSpec GetCanvasWidgetSpec();

        void SetCanvasWidgetSpec(ICanvasWidgetSpec canvasWidgetSpec);
    }
}