using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Rosters.Combatants.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Rosters.Interfaces
{
    /// <summary>
    /// Roster Model Construction Interface
    /// </summary>
    public interface IRosterModelConstruction
    {
        ISet<ICombatantModelConstruction> GetCombatantModelConstructions();
    }
}