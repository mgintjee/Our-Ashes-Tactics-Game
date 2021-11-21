using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.Clicks.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Subs.Interfaces
{
    /// <summary>
    /// Controller Click Input Interface
    /// </summary>
    public interface IClickInput : IUnityScript
    {
        IClick GetClick();
    }
}