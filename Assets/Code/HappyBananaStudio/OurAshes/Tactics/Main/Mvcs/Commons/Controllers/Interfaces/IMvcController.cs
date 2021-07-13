using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces
{
    /// <summary>
    /// Mvc Controller Interface
    /// </summary>
    public interface IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcRequest OutputConfirmedMvcRequest();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcRequest OutputSelectedMvcRequest();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcResponse"></param>
        void Process(IMvcResponse mvcResponse);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsProcessing();

        /// <summary>
        /// Todo
        /// </summary>
        void Stop();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool HasRequests();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcControllerReport GetMvcControllerReport();
    }
}