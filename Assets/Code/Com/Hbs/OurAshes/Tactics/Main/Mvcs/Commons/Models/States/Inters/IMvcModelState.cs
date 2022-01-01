using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters
{
    public interface IMvcModelState
    {
        ISet<IMvcRequest> GetMvcRequests();

        Optional<IMvcRequest> GetPrevMvcRequest();

        IMvcModelState GetCopy();
    }
}