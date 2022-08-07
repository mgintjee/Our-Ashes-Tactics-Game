using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Canvases.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters
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
        /// <param name="mvcModelState"></param>
        void Process(IMvcModelState mvcModelState);

        /// <summary>
        /// Todo
        /// </summary>
        void InitialBuild();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControlInput"></param>
        /// <returns></returns>
        Optional<ICanvasWidget> GetWidget(IMvcControlInput mvcControlInput);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Vector2 GetWorldSize();
    }
}