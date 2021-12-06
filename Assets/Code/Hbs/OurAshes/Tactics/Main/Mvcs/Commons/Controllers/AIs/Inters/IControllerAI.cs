using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.AIs.Inters
{
    /// <summary>
    /// Controller AI Interface
    /// </summary>
    public interface IControllerAI
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcResponse"></param>
        /// <returns></returns>
        IMvcRequest DetermineBestRequest(IMvcResponse mvcResponse);
    }
}