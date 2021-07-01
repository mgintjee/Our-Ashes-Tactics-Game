using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Interfaces
{
    /// <summary>
    /// AI Sortie Controller Interface
    /// </summary>
    public interface IAISortieController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelResponse">        </param>
        /// <param name="sortieControllerRequests"></param>
        /// <returns></returns>
        ISortieControllerRequest DetermineControllerRequest(IMvcModelResponse mvcModelResponse, ISet<ISortieControllerRequest> sortieControllerRequests);
    }
}