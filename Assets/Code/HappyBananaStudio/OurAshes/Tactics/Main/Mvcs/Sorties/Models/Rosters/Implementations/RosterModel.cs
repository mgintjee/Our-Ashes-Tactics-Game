using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Destructibles.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combatants.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Damages.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class RosterModel
        : IRosterModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ISet<CombatantCallSign> _activeCallSigns;

        // Todo
        private readonly ISet<ICombatantModel> _models;

        // Todo
        private IRosterReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterConstruction"></param>
        public RosterModel(IRosterConstruction rosterConstruction)
        {
            _models = new HashSet<ICombatantModel>();
            _activeCallSigns = new HashSet<CombatantCallSign>();
            foreach (ICombatantConstruction construction in rosterConstruction.GetCombatantConstructions())
            {
                _activeCallSigns.Add(construction.GetCombatantCallSign());
                _models.Add(new CombatantModel(construction));
            }
        }

        /// <inheritdoc/>
        IRosterReport IRosterModel.GetReport()
        {
            if (_report == null)
            {
                this.BuildReport();
            }
            return _report;
        }

        /// <inheritdoc/>
        void IRosterModel.Process(ISortieRequest controllerRequest, ICombatReport combatReport)
        {
            if (controllerRequest != null)
            {
                CombatantCallSign callSign = controllerRequest.GetCallSign();
                IPath path = controllerRequest.GetPath();
                _report.GetCombatantReport(callSign).IfPresent((combatantReport) =>
                {
                    float actionCost = 0.0f;
                    float movementCost = 0.0f;
                    _logger.Info(" {}: Applying {}", callSign, path);
                    switch (path.GetPathType())
                    {
                        case PathType.Move:
                            actionCost -= 1;
                            movementCost -= path.GetPathCost();
                            break;

                        case PathType.Fire:
                            actionCost -= 2;
                            movementCost -= 2 * combatantReport.GetMaximumAttributes().GetMovableAttributes().GetMovement();
                            this.ApplyCombatReport(combatReport);
                            break;

                        case PathType.Wait:
                            actionCost -= combatantReport.GetCurrentAttributes().GetMovableAttributes().GetActions();
                            break;
                    }
                    this.ApplyCombatantAttributes(callSign,
                        new CombatantAttributes.Builder()
                        .SetMovableAttributes(
                            new MovableAttributes.Builder()
                            .SetActions(actionCost)
                            .SetMovements(movementCost)
                            .Build())
                         .Build());
                });
            }
            this.BuildReport();
        }

        /// <inheritdoc/>
        void IRosterModel.ResetForNewPhase()
        {
            foreach (CombatantCallSign combatantCallSign in _activeCallSigns)
            {
                GetModel(combatantCallSign).IfPresent(model =>
                {
                    model.ResetForPhase();
                });
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign"></param>
        private Optional<ICombatantModel> GetModel(CombatantCallSign callSign)
        {
            // Iterate over all of the models
            foreach (ICombatantModel model in _models)
            {
                // Check if the callSign matches the parameter
                if (model.GetReport().GetCombatantCallSign() == callSign)
                {
                    return Optional<ICombatantModel>.Of(model);
                }
            }
            return Optional<ICombatantModel>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatReport"></param>
        private void ApplyCombatReport(ICombatReport combatReport)
        {
            _logger.Info("Applying {}", combatReport);
            ISet<IDestructibleAttributes> destructibleAttributesSet = new HashSet<IDestructibleAttributes>();
            foreach (IDamageReport damageReport in combatReport.GetDamageReports())
            {
                destructibleAttributesSet.Add(new DestructibleAttributes.Builder()
                    .SetArmor(-damageReport.GetArmorDamageInflictedPerHit() * damageReport.GetActualSalvoHits())
                    .SetHealth(-damageReport.GetHealthDamageInflictedPerHit() * damageReport.GetActualSalvoHits())
                    .Build());
            }
            IDestructibleAttributes destructibleAttributes = new DestructibleAttributes.Builder().Build(destructibleAttributesSet);
            ICombatantAttributes combatantAttributes = new CombatantAttributes.Builder()
                .SetDestructibleAttributes(destructibleAttributes)
                .Build();
            this.ApplyCombatantAttributes(combatReport.GetTargetCallSign(), combatantAttributes);
        }

        /// <summary>
        /// Todo
        /// </summary>
        private void BuildReport()
        {
            ISet<CombatantCallSign> allCallSigns = new HashSet<CombatantCallSign>();
            ISet<ICombatantReport> combatantReports = new HashSet<ICombatantReport>();
            foreach (ICombatantModel combatantModel in _models)
            {
                ICombatantReport combatantReport = combatantModel.GetReport();
                allCallSigns.Add(combatantReport.GetCombatantCallSign());
                combatantReports.Add(combatantReport);
            }
            _report = new RosterReport.Builder()
                .SetActiveCallSigns(_activeCallSigns)
                .SetAllCallSigns(allCallSigns)
                .SetCombatantReports(combatantReports)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">           </param>
        /// <param name="combatantAttributes"></param>
        private void ApplyCombatantAttributes(CombatantCallSign callSign,
            ICombatantAttributes combatantAttributes)
        {
            this.GetModel(callSign).IfPresent((model) =>
            {
                _logger.Info("Applying {} to {}", combatantAttributes, callSign);
                _logger.Info("Pre Current {}", model.GetReport().GetCurrentAttributes());
                model.ApplyCombatantAttributes(combatantAttributes);
                if (model.GetReport().GetCurrentAttributes()
                    .GetDestructibleAttributes().GetHealth() <= 0.0f)
                {
                    _activeCallSigns.Remove(callSign);
                }
                _logger.Info("Post Current {}", model.GetReport().GetCurrentAttributes());
            });
        }
    }
}