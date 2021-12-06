using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.Clicks.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Inters
{
    /// <summary>
    /// Mvc Controller Interface
    /// </summary>
    public interface IMvcControllerInput : IUnityScript
    {
        Optional<IClick> GetClick();
    }
}