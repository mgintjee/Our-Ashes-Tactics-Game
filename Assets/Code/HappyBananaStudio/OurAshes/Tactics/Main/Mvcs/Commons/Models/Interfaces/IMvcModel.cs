using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Requests.Interfaces;
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
        ISet<IRequest> GetControllerRequests();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerRequest"></param>
        /// <returns></returns>
        void Process(IRequest mvcControllerRequest);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcModelResponse GetMvcModelResponse();
    }
}