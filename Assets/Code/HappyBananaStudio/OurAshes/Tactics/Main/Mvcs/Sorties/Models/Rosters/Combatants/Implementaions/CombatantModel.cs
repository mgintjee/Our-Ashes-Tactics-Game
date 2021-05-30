﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.IDs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Gears.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loadouts.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loggers.Implementations;
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
        // Todo
        private static readonly ILogger _logger = new SortieLogger(new StackFrame().GetMethod().DeclaringType);

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

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantConstruction"></param>
        public CombatantModel(ICombatantConstruction combatantConstruction)
        {
            _logger.Info("Instantiating with {}", combatantConstruction);
            _combatantCallSign = combatantConstruction.GetCombatantCallSign();
            _combatantID = combatantConstruction.GetCombatantModelConstruction().GetCombatantID();
            _loadoutReport = combatantConstruction.GetCombatantModelConstruction().GetLoadoutReport();
            ISet<ICombatantAttributes> combatantAttributes = new HashSet<ICombatantAttributes>();
            foreach (IGearReport gearReport in _loadoutReport.GetGearReports())
            {
                ICombatantAttributes attributes = gearReport.GetCombatantAttributes();
                combatantAttributes.Add(new CombatantAttributes.Builder()
                        .SetDestructibleAttributes(attributes.GetDestructibleAttributes())
                        .SetMovableAttributes(attributes.GetMovableAttributes())
                    .Build());
            }
            _destructibleModel = new DestructibleModel(combatantAttributes);
            _fireableModel = new FireableModel(combatantAttributes);
            _movableModel = new MovableModel(combatantAttributes);
            _logger.Info("Instantiated");
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
            _movableModel.ResetForPhase();
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
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ICombatantAttributes GetMaximumCombatantAttributes()
        {
            return new CombatantAttributes.Builder()
                .SetDestructibleAttributes(_destructibleModel.GetCurrentAttributes())
                .SetFireableAttributes(_fireableModel.GetMaximumAttributes())
                .SetMovableAttributes(_movableModel.GetCurrentAttributes())
                .Build();
        }
    }
}