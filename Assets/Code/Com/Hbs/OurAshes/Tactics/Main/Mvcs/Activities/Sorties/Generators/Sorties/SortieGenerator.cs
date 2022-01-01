/*using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constrs.Inters;
using System;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Generators.Sorties
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
            IMvcControlConstruction mvcControlConstruction = null;
            IMvcModelConstruction mvcModelConstruction = null;
            IMvcViewConstruction mvcViewConstruction = null;
            return new MvcFrameConstruction.Builder()
                .SetMvcType(MvcType.Sortie)
                .SetSimulationType(simulationType)
                .SetUnityScript(unityScript)
                .SetMvcControlConstruction(mvcControlConstruction)
                .SetMvcModelConstruction(mvcModelConstruction)
                .SetMvcViewConstruction(mvcViewConstruction)
                .Build();
        }
    }
}*/