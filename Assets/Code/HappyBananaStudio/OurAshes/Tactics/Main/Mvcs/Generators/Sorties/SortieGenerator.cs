using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constructions.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Generators.Sorties
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
}