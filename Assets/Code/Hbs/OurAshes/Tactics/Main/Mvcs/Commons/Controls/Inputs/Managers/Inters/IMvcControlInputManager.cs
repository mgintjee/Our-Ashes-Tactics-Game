using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Managers.Inters
{
    /// <summary>
    /// Mvc Control Interface
    /// </summary>
    public interface IMvcControlInputManager : IUnityScript
    {
        void SetMvcControlInputs(ISet<MvcControlInputType> mvcControlInputTypes);
    }
}