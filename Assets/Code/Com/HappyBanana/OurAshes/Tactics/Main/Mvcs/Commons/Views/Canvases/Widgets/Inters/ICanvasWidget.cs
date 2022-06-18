using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Grids.Convertors.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Worlds.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters
{
    /// <summary>
    /// Canvas Widget Interface
    /// </summary>
    public interface ICanvasWidget
        : ICanvasScript
    {
        void SetEnabled(bool enabled);

        bool IsInputOnWidget(IMvcControlInput mvcControlInput);

        IWidgetGridSpec GetWidgetGridSpec();

        IWidgetWorldSpec GetWidgetWorldSpec();

        void Process(IMvcModelState mvcModelState);

        bool GetInteractable();

        bool GetEnabled();

        int GetCanvasLevel();

        void SetWidgetGridSpec(IWidgetGridSpec widgetGridSpec);

        void SetInteractable(bool interactable);

        void SetCanvasLevel(int canvasLevel);

        void ApplyGridConvertor(ICanvasGridConvertor canvasGridConvertor);
    }
}