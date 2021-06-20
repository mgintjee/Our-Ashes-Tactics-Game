using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Loadouts.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Stats.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Gears.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Destructables.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Destructables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Fireables.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Fireables.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Movables.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Movables.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Implementaions
{
    /// <summary>
    /// Combatant Model Implementation
    /// </summary>
    public class CombatantModel
        : ICombatantModel
    {
        // Provides logging capability to the SORTIE logs
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly CombatantCallSign _combatantCallSign;

        // Todo
        private readonly CombatantID _combatantID;

        // Todo
        private readonly IDestructibleModel _destructibleModel;

        // Todo
        private readonly IFireableModel _fireableModel;

        // Todo
        private readonly ILoadoutReport _loadoutReport;

        // Todo
        private readonly IMovableModel _movableModel;

        // Todo
        private readonly ILoadoutAttributes _loadoutAttributes;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantConstruction"></param>
        public CombatantModel(ICombatantConstruction combatantConstruction)
        {
            _logger.Info("Instantiating with {}", combatantConstruction);
            _combatantCallSign = combatantConstruction.GetCombatantCallSign();
            _combatantID = combatantConstruction.GetCombatantID();
            _loadoutReport = combatantConstruction.GetLoadoutReport();
            ICombatantAttributes baseCombatantAttributes = CombatantStatsManager.GetStats(_combatantID).GetValue().GetCombatantAttributes();
            _loadoutAttributes = baseCombatantAttributes.GetLoadoutAttributes();
            ISet<ICombatantAttributes> combatantAttributes = new HashSet<ICombatantAttributes>() { baseCombatantAttributes };
            foreach (IGearReport gearReport in _loadoutReport.GetGearReports())
            {
                ICombatantAttributes attributes = gearReport.GetCombatantAttributes();
                if (gearReport.GetGearID().ToString().Contains("Weapon"))
                {
                    combatantAttributes.Add(new CombatantAttributes.Builder()
                            .SetDestructibleAttributes(attributes.GetDestructibleAttributes())
                            .SetMovableAttributes(attributes.GetMovableAttributes())
                        .Build());
                }
                else
                {
                    combatantAttributes.Add(attributes);
                }
            }
            _destructibleModel = new DestructibleModel(combatantAttributes);
            _fireableModel = new FireableModel(combatantAttributes);
            _movableModel = new MovableModel(combatantAttributes);
            _logger.Info("Current {}", _destructibleModel.GetCurrentAttributes());
            _logger.Info("Current {}", _fireableModel.GetCurrentAttributes());
            _logger.Info("Current {}", _movableModel.GetCurrentAttributes());
        }

        /// <inheritdoc/>
        void ICombatantModel.ApplyCombatantAttributes(ICombatantAttributes combatantAttributes)
        {
            _destructibleModel.ApplyCombatantAttributes(combatantAttributes);
            _fireableModel.ApplyCombatantAttributes(combatantAttributes);
            _movableModel.ApplyCombatantAttributes(combatantAttributes);
        }

        /// <inheritdoc/>
        ICombatantReport ICombatantModel.GetReport()
        {
            return new CombatantReport.Builder()
                .SetCurrentCombatantAttributes(this.GetCurrentCombatantAttributes())
                .SetMaximumCombatantAttributes(this.GetMaximumCombatantAttributes())
                .SetLoadoutReport(_loadoutReport)
                .SetCombatantCallSign(_combatantCallSign)
                .SetCombatantID(_combatantID)
                .Build();
        }

        /// <inheritdoc/>
        void ICombatantModel.ResetForPhase()
        {
            _logger.Info("Resetting {}", _combatantCallSign);
            _logger.Info("Pre {}", _movableModel.GetCurrentAttributes());
            _movableModel.ResetForPhase();
            _logger.Info("Post {}", _movableModel.GetCurrentAttributes());
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ICombatantAttributes GetCurrentCombatantAttributes()
        {
            return new CombatantAttributes.Builder()
                .SetDestructibleAttributes(_destructibleModel.GetCurrentAttributes())
                .SetFireableAttributes(_fireableModel.GetCurrentAttributes())
                .SetMovableAttributes(_movableModel.GetCurrentAttributes())
                .SetLoadoutAttributes(_loadoutAttributes)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ICombatantAttributes GetMaximumCombatantAttributes()
        {
            return new CombatantAttributes.Builder()
                .SetDestructibleAttributes(_destructibleModel.GetMaximumAttributes())
                .SetFireableAttributes(_fireableModel.GetMaximumAttributes())
                .SetMovableAttributes(_movableModel.GetMaximumAttributes())
                .SetLoadoutAttributes(_loadoutAttributes)
                .Build();
        }
    }
}