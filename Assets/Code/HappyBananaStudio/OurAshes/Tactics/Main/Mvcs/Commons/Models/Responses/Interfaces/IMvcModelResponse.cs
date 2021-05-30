using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces
{
    /// <summary>
    /// Mvc Model Response Interface
    /// </summary>
    public interface IMvcModelResponse
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IMvcControllerRequest> GetControllerRequests();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Optional<IMvcControllerRequest> GetMvcControllerRequest();
    }
}