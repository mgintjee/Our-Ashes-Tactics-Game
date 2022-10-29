using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters
{
    public interface IMvcControlState
    {
        IOptional<IMvcRequest> GetMvcModelRequest();

        IOptional<IMvcControlInput> GetMvcControlInput();

        IMvcControlState GetCopy();
    }
}