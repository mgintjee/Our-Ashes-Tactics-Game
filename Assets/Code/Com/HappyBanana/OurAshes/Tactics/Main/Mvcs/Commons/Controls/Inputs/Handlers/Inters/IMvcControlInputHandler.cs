using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcControlInputHandler : IUnityScript
    {
        void ClearInput();

        void SetEnable(bool isEnabled);

        IOptional<IMvcControlInputClick> GetMvcControlInput();

        MvcControlInputType GetMvcControlInputType();
    }
}