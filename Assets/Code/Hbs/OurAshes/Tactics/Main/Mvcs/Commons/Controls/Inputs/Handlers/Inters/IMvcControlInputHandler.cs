using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcControlInputHandler : IUnityScript
    {
        IInput GetInput();
    }
}