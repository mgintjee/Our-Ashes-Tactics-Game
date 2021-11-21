using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.AIs.Interfaces
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