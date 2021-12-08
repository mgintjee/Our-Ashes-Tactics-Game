using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Inters
{
    /// <summary>
    /// Control AI Interface
    /// </summary>
    public interface IControlAI
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcResponse"></param>
        /// <returns></returns>
        IMvcRequest DetermineBestRequest(IMvcResponse mvcResponse);
    }
}