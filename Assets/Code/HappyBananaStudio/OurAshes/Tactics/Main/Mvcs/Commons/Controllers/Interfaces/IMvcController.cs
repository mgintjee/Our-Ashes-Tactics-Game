using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using System.Collections.Generic;

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
        /// <param name="requests"></param>
        void Process(ISet<IMvcRequest> requests);

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
    }
}