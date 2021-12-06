using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Rosters.Combatants.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Views.Rosters.Inters
{
    /// <summary>
    /// Roster View Construction Interface
    /// </summary>
    public interface IRosterViewConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ICombatantViewConstruction> GetCombatantViewConstrs();
    }
}