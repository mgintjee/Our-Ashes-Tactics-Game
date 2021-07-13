using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces
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