using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Inters
{
    /// <summary>
    /// Mvc Control AI Interface
    /// </summary>
    public interface IMvcControlAI
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameState"></param>
        /// <returns></returns>
        IMvcModelRequest DetermineBestRequest(IMvcFrameState mvcFrameState);
    }
}