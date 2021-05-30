using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
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
        ISet<IMvcControllerRequest> GetControllerRequests();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerRequest"></param>
        /// <returns></returns>
        void Process(IMvcControllerRequest mvcControllerRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcModelResponse GetMvcModelResponse();
    }
}