using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Interfaces
{
    /// <summary>
    /// Sortie Mvc Controller Interface
    /// </summary>
    public interface IMvcSortieController
        : IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieControllerRequest GetConfirmedControllerRequest();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISortieControllerRequest GetSelectedControllerRequest();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ISortieControllerRequest> GetControllerRequests();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsProcessing();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="controllerRequests"></param>
        void Process(ISet<ISortieControllerRequest> controllerRequests);

        /// <summary>
        /// Todo
        /// </summary>
        void Clear();
    }
}