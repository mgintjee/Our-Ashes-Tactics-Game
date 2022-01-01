using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters
{
    public interface IMvcControlState
    {
        Optional<IMvcRequest> GetMvcModelRequest();

        Optional<IMvcControlInput> GetMvcControlInput();

        IMvcControlState GetCopy();
    }
}