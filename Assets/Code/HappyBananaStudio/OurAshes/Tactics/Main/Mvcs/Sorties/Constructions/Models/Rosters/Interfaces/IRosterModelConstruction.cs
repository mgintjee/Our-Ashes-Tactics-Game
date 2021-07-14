using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Rosters.Interfaces
{
    /// <summary>
    /// Roster Model Construction Interface
    /// </summary>
    public interface IRosterModelConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ICombatantModelConstruction> GetCombatantModelConstructions();
    }
}