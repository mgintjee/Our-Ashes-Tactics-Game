using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.Clicks.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Subs.Inters
{
    /// <summary>
    /// Controller Click Input Interface
    /// </summary>
    public interface IClickInput : IUnityScript
    {
        IClick GetClick();
    }
}