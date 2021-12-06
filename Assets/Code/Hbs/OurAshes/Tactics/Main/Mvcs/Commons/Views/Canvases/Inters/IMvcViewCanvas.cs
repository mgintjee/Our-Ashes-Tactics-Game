using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.Clicks.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Inters;
using System;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters
{
    /// <summary>
    /// Mvc View Canvas Interface
    /// </summary>
    public interface IMvcViewCanvas : ICanvasScript
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
        /// <param name="click"></param>
        /// <returns></returns>
        Optional<Action> CanvasAction(IClick click);
    }
}