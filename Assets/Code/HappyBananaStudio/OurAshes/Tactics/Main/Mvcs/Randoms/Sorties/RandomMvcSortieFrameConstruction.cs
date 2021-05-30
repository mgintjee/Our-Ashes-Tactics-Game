using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Simulations.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Formations.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Maps.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Scores.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Randoms.Sorties
{
    /// <summary>
    /// Random Mvc Sortie Frame Construction
    /// </summary>
    public static class RandomMvcSortieFrameConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="seed">          </param>
        /// <param name="simulationType"></param>
        /// <param name="unityScript">   </param>
        /// <returns></returns>
        public static IMvcSortieFrameConstruction Generate(int seed,
            SimulationType simulationType, IUnityScript unityScript)
        {
            IFormationConstruction formationConstruction = null;
            IMapConstruction mapConstruction = null;
            IRosterConstruction rosterConstruction = null;
            IScoreConstruction scoreConstruction = null;

            return new MvcSortieFrameConstruction.Builder()
                .SetSimulationType(simulationType)
                .SetUnityScript(unityScript)
                .SetFormationConstruction(formationConstruction)
                .SetMapConstruction(mapConstruction)
                .SetRosterConstruction(rosterConstruction)
                .SetScoreConstruction(scoreConstruction)
                .Build();
        }
    }
}