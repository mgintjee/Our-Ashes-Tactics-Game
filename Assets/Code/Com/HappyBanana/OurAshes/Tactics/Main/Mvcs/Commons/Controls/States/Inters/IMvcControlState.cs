using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters
{
    public interface IMvcControlState
    {
        Optional<IMvcRequest> GetMvcModelRequest();

        Optional<IMvcControlInput> GetMvcControlInput();

        IMvcControlState GetCopy();
    }
}