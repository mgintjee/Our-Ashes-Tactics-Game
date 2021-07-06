using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces
{
    /// <summary>
    /// Mvc Model Interface
    /// </summary>
    public interface IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IMvcRequest> GetMvcRequests();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerRequest"></param>
        /// <returns></returns>
        void Process(IMvcRequest mvcControllerRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsProcessing();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcResponse GetMvcResponse();
    }
}