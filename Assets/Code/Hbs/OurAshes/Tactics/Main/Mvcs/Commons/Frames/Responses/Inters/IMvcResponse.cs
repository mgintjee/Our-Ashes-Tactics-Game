using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcResponse : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcRequest GetMvcRequest();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<IMvcRequest> GetMvcRequests();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcFrameReport GetMvcFrameReport();
    }
}