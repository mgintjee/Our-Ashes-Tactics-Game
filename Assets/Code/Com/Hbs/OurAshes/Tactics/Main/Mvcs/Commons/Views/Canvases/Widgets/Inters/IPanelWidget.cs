using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters
{
    /// <summary>
    /// Panel Widget Interface
    /// </summary>
    public interface IPanelWidget
        : ICanvasWidget
    {
        void AddWidget(ICanvasWidget canvasWidget);

        void AddWidgets(ICollection<ICanvasWidget> canvasWidgets);

        Optional<ICanvasWidget> GetWidgetFromInput(IMvcControlInput mvcControlInput);
    }
}