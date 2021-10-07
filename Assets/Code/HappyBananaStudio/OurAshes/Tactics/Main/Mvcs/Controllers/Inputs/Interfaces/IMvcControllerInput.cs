using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Interfaces
{
    /// <summary>
    /// Mvc Controller Interface
    /// </summary>
    public interface IMvcControllerInput : IUnityScript
    {
        Optional<IClick> GetClick();
    }
}