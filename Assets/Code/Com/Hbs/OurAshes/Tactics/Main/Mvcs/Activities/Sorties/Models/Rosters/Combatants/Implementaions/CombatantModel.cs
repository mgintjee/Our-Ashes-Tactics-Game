using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.Attributes.Loadouts.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Combatants.Models.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Constrs.Models.Rosters.Combatants.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Destructables.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Destructables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Fireables.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Fireables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Movables.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Movables.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Combatants.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Combatants.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Gears.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Reports.Models.Loadouts.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Models.Rosters.Combatants.Implementaions
{
    /// <summary>
    /// Combatant Model Impl
    /// </summary>
    public class CombatantModel
        : ICombatantModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Sortie)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

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
        public CombatantModel(ICombatantModelConstruction combatantConstruction)
        {
            logger.Info("Instantiating with {}", combatantConstruction);
            _combatantCallSign = combatantConstruction.GetCombatantCallSign();
            _combatantID = combatantConstruction.GetCombatantID();
            _loadoutReport = combatantConstruction.GetLoadoutReport();
            ICombatantAttributes baseCombatantAttributes = CombatantModelConstantsManager.GetConstants(_combatantID).GetValue().GetCombatantAttributes();
            _loadoutAttributes = baseCombatantAttributes.GetLoadoutAttributes();
            ISet<ICombatantAttributes> combatantAttributes = new HashSet<ICombatantAttributes>() { baseCombatantAttributes };
            foreach (IGearReport gearReport in _loadoutReport.GetGearReports())
            {
                ICombatantAttributes attributes = gearReport.GetCombatantAttributes();
                if (gearReport.GetGearID().ToString().Contains("Weapon"))
                {
                    combatantAttributes.Add(CombatantAttributes.Builder.Get()
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
            logger.Info("Current {}", _destructibleModel.GetCurrentAttributes());
            logger.Info("Current {}", _fireableModel.GetCurrentAttributes());
            logger.Info("Current {}", _movableModel.GetCurrentAttributes());
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
            logger.Info("Resetting {} for phase", _combatantCallSign);
            _movableModel.ResetForPhase();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        private ICombatantAttributes GetCurrentCombatantAttributes()
        {
            return CombatantAttributes.Builder.Get()
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
            return CombatantAttributes.Builder.Get()
                .SetDestructibleAttributes(_destructibleModel.GetMaximumAttributes())
                .SetFireableAttributes(_fireableModel.GetMaximumAttributes())
                .SetMovableAttributes(_movableModel.GetMaximumAttributes())
                .SetLoadoutAttributes(_loadoutAttributes)
                .Build();
        }
    }
}