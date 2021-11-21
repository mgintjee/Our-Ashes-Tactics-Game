using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.Clicks.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Interfaces
{
    /// <summary>
    /// Mvc Controller Interface
    /// </summary>
    public interface IMvcControllerInput : IUnityScript
    {
        Optional<IClick> GetClick();
    }
}