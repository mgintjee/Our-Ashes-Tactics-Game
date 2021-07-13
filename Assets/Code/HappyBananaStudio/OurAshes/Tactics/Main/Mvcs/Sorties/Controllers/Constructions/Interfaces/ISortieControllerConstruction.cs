using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Constructions.Interfaces
{
    /// <summary>
    /// Sortie Controller Constrcution Interface
    /// </summary>
    public interface ISortieControllerConstruction
        : IMvcControllerConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IDictionary<CombatantCallSign, AIType> GetCombatantCallSignAITypes();
    }
}