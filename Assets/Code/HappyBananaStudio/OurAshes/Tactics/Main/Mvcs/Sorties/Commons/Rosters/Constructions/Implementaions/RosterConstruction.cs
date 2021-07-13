using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Views.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Views.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Views.Implementaions
{
    /// <summary>
    /// Roster Construction Implementation
    /// </summary>
    public struct RosterConstruction : IRosterConstruction
    {
        // Todo
        private readonly ISet<ICombatantModelConstruction> _combatantModelConstructions;
        // Todo
        private readonly ISet<ICombatantViewConstruction> _combatantViewConstructions;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantModelConstructions"></param>
        private RosterConstruction(ISet<ICombatantModelConstruction> combatantModelConstructions,
            ISet<ICombatantViewConstruction> combatantViewConstructions)
        {
            _combatantModelConstructions = combatantModelConstructions;
            _combatantViewConstructions = combatantViewConstructions;
        }

        /// <inheritdoc/>
        ISet<ICombatantModelConstruction> IRosterConstruction.GetCombatantModelConstructions()
        {
            return new HashSet<ICombatantModelConstruction>(_combatantModelConstructions);
        }
        /// <inheritdoc/>
        ISet<ICombatantViewConstruction> IRosterConstruction.GetCombatantViewConstructions()
        {
            return new HashSet<ICombatantViewConstruction>(_combatantViewConstructions);
        }
    }
}