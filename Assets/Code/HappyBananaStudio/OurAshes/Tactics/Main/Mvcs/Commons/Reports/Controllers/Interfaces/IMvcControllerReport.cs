using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Interfaces
{
    /// <summary>
    /// Mvc Controller Report Interface
    /// </summary>
    public interface IMvcControllerReport
        : IReport
    {
        Optional<IMvcRequest> GetSelectedRequest();

        Optional<IMvcRequest> GetConfirmedRequest();

        bool HasRequests();

        bool IsProcessing();
    }
}