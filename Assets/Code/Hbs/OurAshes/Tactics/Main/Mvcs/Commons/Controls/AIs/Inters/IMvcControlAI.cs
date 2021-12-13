using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Inters
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
        IMvcControlRequest DetermineBestRequest(IMvcFrameState mvcFrameState);
    }
}