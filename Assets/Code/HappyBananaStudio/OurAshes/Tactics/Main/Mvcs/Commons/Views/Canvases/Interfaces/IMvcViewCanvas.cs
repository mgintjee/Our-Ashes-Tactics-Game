using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Interfaces
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