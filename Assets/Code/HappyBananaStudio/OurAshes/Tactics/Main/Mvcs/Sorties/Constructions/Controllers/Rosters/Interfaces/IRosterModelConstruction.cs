using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Rosters.Interfaces
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