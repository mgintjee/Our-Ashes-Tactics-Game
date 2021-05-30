﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Attributes.Movables.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Combats.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Combatants.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Rosters.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Loggers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Rosters.Reports.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Rosters.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
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
        // Todo
        private static readonly ILogger _logger = new SortieLogger(new StackFrame().GetMethod().DeclaringType);

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
            return _report;
        }

        /// <inheritdoc/>
        void IRosterModel.Process(ISortieControllerRequest controllerRequest, ICombatReport combatReport)
        {
            CombatantCallSign callSign = controllerRequest.GetCallSign();
            IPath path = controllerRequest.GetPath();
            _report.GetCombatantReport(callSign).IfPresent((combatantReport) =>
           {
               float actionCost = 0.0f;
               float movementCost = 0.0f;
               switch (path.GetPathType())
               {
                   case PathType.Move:
                       actionCost += 1;
                       movementCost += path.GetPathCost();
                       break;

                   case PathType.Fire:
                       actionCost += 2;
                       movementCost += 2 * combatantReport.GetMaximumAttributes().GetMovableAttributes().GetMovement();
                       break;

                   case PathType.Wait:
                       actionCost += combatantReport.GetCurrentAttributes().GetMovableAttributes().GetActions();
                       break;
               }
               this.ApplyCombatantAttributes(callSign,
                   new CombatantAttributes.Builder()
                   .SetMovableAttributes(
                       new MovableAttributes.Builder()
                       .SetAPs(actionCost)
                       .SetMPs(movementCost)
                       .Build())
                    .Build());
           });

            _report = new RosterReport.Builder()
                .SetActiveCallSigns(_activeCallSigns)
                .SetAllCallSigns(null)
                .SetCombatantReports(null)
                .Build();
        }

        /// <inheritdoc/>
        void IRosterModel.ResetForNewPhase()
        {
            foreach (ICombatantModel model in _models)
            {
                if (_activeCallSigns.Contains(model.GetReport()
                    .GetCombatantCallSign()))
                {
                    model.ResetForPhase();
                }
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
        /// <param name="controllerRequest"></param>
        private void ApplyRequestToActingCallSign(ISortieControllerRequest controllerRequest)
        {
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="targetCallSign"></param>
        /// <param name="combatReport">  </param>
        private void ApplyRequestToTargetCallSign(CombatantCallSign targetCallSign, ICombatReport combatReport)
        {
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
                model.ApplyCombatantAttributes(combatantAttributes);
                if (model.GetReport().GetCurrentAttributes()
                    .GetDestructibleAttributes().GetHealth() <= 0.0f)
                {
                    _activeCallSigns.Remove(callSign);
                }
            });
        }
    }
}