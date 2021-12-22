using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters
{
    /// <summary>
    /// Mvc View Canvas Interface
    /// </summary>
    public interface IMvcViewCanvas
        : ICanvasScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void Clear();

        /// <summary>
        /// Todo: Delete. Maybe redundant with the Build method
        /// </summary>
        void Reset();

        /// <summary>
        /// Todo
        /// </summary>
        void Build();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelState"></param>
        void Process(IMvcModelState mvcModelState);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControlInput"></param>
        /// <returns></returns>
        Optional<ICanvasWidget> GetWidget(IMvcControlInput mvcControlInput);
    }
}