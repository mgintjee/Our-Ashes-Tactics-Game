/*using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Scripts.Unity.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constrs.Inters;
using System;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Generators.Sorties
{
    /// <summary>
    /// Random Sortie Construction
    /// </summary>
    public static class SortieGenerator
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static IMvcFrameConstruction Generate(Random random, IUnityScript unityScript, SimulationType simulationType)
        {
            // Todo: Build these things
            IMvcControllerConstruction mvcControllerConstruction = null;
            IMvcModelConstruction mvcModelConstruction = null;
            IMvcViewConstruction mvcViewConstruction = null;
            return new MvcFrameConstruction.Builder()
                .SetMvcType(MvcType.Sortie)
                .SetSimulationType(simulationType)
                .SetUnityScript(unityScript)
                .SetMvcControllerConstruction(mvcControllerConstruction)
                .SetMvcModelConstruction(mvcModelConstruction)
                .SetMvcViewConstruction(mvcViewConstruction)
                .Build();
        }
    }
}*/