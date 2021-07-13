using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Constructions.Implementations
{
    /// <summary>
    /// Sortie Controller Construction Implementation
    /// </summary>
    public class SortieControllerConstruction
        : ISortieControllerConstruction
    {
        IDictionary<CombatantCallSign, AIType> ISortieControllerConstruction.GetCombatantCallSignAITypes()
        {
            throw new System.NotImplementedException();
        }
    }
}