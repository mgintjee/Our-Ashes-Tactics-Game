using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters
{
    /// <summary>
    /// Panel Widget Interface
    /// </summary>
    public interface IPanelWidget
        : ICanvasWidget
    {
        void AddWidget(ICanvasWidget canvasWidget);

        void AddWidgets(ICollection<ICanvasWidget> canvasWidgets);

        Optional<ICanvasWidget> GetWidgetFromInput(ICanvasGridConvertor canvasGridConvertor, IMvcControlInput mvcControlInput);
    }
}