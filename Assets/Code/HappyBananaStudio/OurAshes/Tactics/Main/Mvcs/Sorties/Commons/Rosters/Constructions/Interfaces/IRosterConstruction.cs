using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IRosterConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ICombatantConstruction> GetCombatantConstructions();
    }
}