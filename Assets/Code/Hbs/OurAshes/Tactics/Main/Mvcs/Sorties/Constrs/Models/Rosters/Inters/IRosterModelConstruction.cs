using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Rosters.Combatants.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Models.Rosters.Inters
{
    /// <summary>
    /// Roster Model Construction Interface
    /// </summary>
    public interface IRosterModelConstruction
    {
        ISet<ICombatantModelConstruction> GetCombatantModelConstrs();
    }
}