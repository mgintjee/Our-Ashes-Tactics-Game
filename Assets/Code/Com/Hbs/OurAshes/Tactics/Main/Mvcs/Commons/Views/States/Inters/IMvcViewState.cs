using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters
{
    public interface IMvcViewState
    {
        Optional<IMvcRequest> GetMvcModelRequest();

        ISet<MvcControlInputType> GetMvcControlInputTypes();

        IMvcViewState GetCopy();
    }
}