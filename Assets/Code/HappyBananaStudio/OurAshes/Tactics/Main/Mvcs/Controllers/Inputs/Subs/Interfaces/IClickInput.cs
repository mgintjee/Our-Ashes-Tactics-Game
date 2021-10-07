using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Subs.Interfaces
{
    /// <summary>
    /// Controller Click Input Interface
    /// </summary>
    public interface IClickInput : IUnityScript
    {
        IClick GetClick();
    }
}