using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Models.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Combats.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Damages.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Reports.Models.Rosters.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Rosters.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class RosterModel : IRosterModel
    {
        // Provides logging capability to the SORTIE logs
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly ISet<CombatantCallSign> _activeCallSigns;

        // Todo
        private readonly ISet<ICombatantModel> _models;

        // Todo
        private IRosterModelReport _report;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="rosterConstruction"></param>
        public RosterModel(IRosterModelConstruction rosterConstruction)
        {
            _models = new HashSet<ICombatantModel>();
            _activeCallSigns = new HashSet<CombatantCallSign>();
        }

        /// <inheritdoc/>
        IRosterModelReport IRosterModel.GetReport()
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
                ISortieMapPath path = controllerRequest.GetPath();
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
                        CombatantAttributes.Builder.Get()
                        .SetMovableAttributes(
                            MovableAttributes.Builder.Get()
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
                destructibleAttributesSet.Add(DestructibleAttributes.Builder.Get()
                    .SetArmor(-damageReport.GetArmorDamageInflictedPerHit() * damageReport.GetActualSalvoHits())
                    .SetHealth(-damageReport.GetHealthDamageInflictedPerHit() * damageReport.GetActualSalvoHits())
                    .Build());
            }
            IDestructibleAttributes destructibleAttributes = DestructibleAttributesUtil.Build(destructibleAttributesSet);
            ICombatantAttributes combatantAttributes = CombatantAttributes.Builder.Get()
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
            _report = RosterModelReport.Builder.Get()
                .SetActiveCombatantCallSigns(_activeCallSigns)
                .SetAllCombatantCallSigns(allCallSigns)
                .SetAllCombatantReports(combatantReports)
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