using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces
{
    /// <summary>
    /// Mvc Model Report Interface
    /// </summary>
    public interface IMvcModelReport
        : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IMvcRequest> GetMvcRequests();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsProcessing();
    }
}