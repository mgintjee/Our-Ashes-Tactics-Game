using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Reports.Interfaces
{
    /// <summary>
    /// Mvc Controller Report Interface
    /// </summary>
    public interface IMvcControllerReport
        : IReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Optional<IMvcRequest> GetSelectedRequest();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Optional<IMvcRequest> GetConfirmedRequest();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        bool IsProcessing();
    }
}