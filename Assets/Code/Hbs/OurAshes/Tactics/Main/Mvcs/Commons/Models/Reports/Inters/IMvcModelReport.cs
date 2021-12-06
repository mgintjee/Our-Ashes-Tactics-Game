using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters
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