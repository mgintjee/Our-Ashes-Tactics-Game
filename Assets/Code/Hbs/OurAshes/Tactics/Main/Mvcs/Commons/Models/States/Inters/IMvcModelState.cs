using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters
{
    public interface IMvcModelState
        : IReport
    {
        ISet<IMvcControlRequest> GetMvcControlRequests();
    }
}