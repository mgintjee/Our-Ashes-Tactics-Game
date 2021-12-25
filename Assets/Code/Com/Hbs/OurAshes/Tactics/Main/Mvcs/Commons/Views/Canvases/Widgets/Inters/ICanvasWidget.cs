using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Worlds.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters
{
    /// <summary>
    /// Canvas Widget Interface
    /// </summary>
    public interface ICanvasWidget
        : ICanvasScript
    {
        bool IsInputOnWidget(IMvcControlInput mvcControlInput);

        IWidgetGridSpec GetWidgetGridSpec();

        IWidgetWorldSpec GetWidgetWorldSpec();

        bool GetInteractable();

        int GetCanvasLevel();

        void SetWidgetGridSpec(IWidgetGridSpec widgetGridSpec);

        void SetInteractable(bool interactable);

        void SetCanvasLevel(int canvasLevel);

        void ApplyGridConvertor(ICanvasGridConvertor canvasGridConvertor);
    }
}