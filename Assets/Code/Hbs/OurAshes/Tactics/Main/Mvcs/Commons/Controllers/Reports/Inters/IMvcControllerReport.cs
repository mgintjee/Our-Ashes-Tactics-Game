using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Reports.Inters
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