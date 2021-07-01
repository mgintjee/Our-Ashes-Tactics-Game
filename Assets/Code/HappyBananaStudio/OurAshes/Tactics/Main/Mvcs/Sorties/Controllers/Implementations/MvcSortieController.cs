﻿using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.AIs.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Implementations
{
    /// <summary>
    /// Sortie Mvc Controller Interface
    /// </summary>
    public class MvcSortieController
        : AbstractController, IMvcSortieController
    {
        // Todo
        private readonly ILogger _logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<AIType, IAISortieController> _aiTypeAIControllers = new Dictionary<AIType, IAISortieController>()
            {
                {  AIType.Random, new PoacherAISortieController() },
                {  AIType.Poacher, new PoacherAISortieController() },
            };

        // Todo
        private readonly IDictionary<CombatantCallSign, AIType> _combatantCallSignControllerTypes =
            new Dictionary<CombatantCallSign, AIType>();

        // Todo
        private readonly ISet<ISortieControllerRequest> _sortieControllerRequests = new HashSet<ISortieControllerRequest>();

        // Todo
        private ISortieControllerRequest _confirmedSortieControllerRequest;

        // Todo
        private ISortieControllerRequest _selectedSortieControllerRequest;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcSortieFrameConstruction"></param>
        /// <param name="unityScript">               </param>
        private MvcSortieController(IMvcSortieFrameConstruction mvcSortieFrameConstruction, IUnityScript unityScript)
        {
            // Iterate over the PhalanxConstructions
            foreach (IPhalanxConstruction phalanxConstruction in
                mvcSortieFrameConstruction.GetFormationConstruction().GetPhalanxConstructions())
            {
                // Collect the PhalanxModelConstruction
                IPhalanxConstruction phalanxModelConstruction = phalanxConstruction;
                // Iterate over the CombatantCallSigns for this PhalanxConstruction
                foreach (CombatantCallSign combatantCallSign in
                    phalanxModelConstruction.GetCombatantCallSigns())
                {
                    // Map the CombatantCallSign to the Phalanx's ControllerType
                    this._combatantCallSignControllerTypes.Add(combatantCallSign,
                        phalanxModelConstruction.GetAIType());
                }
            }
        }

        /// <inheritdoc/>
        ISortieControllerRequest IMvcSortieController.GetConfirmedControllerRequest()
        {
            return _confirmedSortieControllerRequest;
        }

        /// <inheritdoc/>
        ISet<ISortieControllerRequest> IMvcSortieController.GetControllerRequests()
        {
            return new HashSet<ISortieControllerRequest>(this._sortieControllerRequests);
        }

        /// <inheritdoc/>
        ISortieControllerRequest IMvcSortieController.GetSelectedControllerRequest()
        {
            return _selectedSortieControllerRequest;
        }

        /// <inheritdoc/>
        bool IMvcSortieController.IsProcessing()
        {
            return this._sortieControllerRequests.Count != 0 &&
                (this._selectedSortieControllerRequest == null ||
                this._confirmedSortieControllerRequest == null);
        }

        /// <inheritdoc/>
        void IMvcSortieController.Process(ISet<ISortieControllerRequest> sortieControllerRequests)
        {
            if (sortieControllerRequests.Count == 0)
            {
                throw ExceptionUtil.Arguments.Build();
            }
            _logger.Info("Available {}s ({}): [" +
                "\n{}" +
                "\n]",
                typeof(ISortieControllerRequest), sortieControllerRequests.Count,
                string.Join("\n", sortieControllerRequests));
            this._sortieControllerRequests.Clear();
            this._sortieControllerRequests.UnionWith(sortieControllerRequests);
            this._selectedSortieControllerRequest = null;
            this._confirmedSortieControllerRequest = null;
            CombatantCallSign combatantCallSign = new List<ISortieControllerRequest>
                (sortieControllerRequests)[0].GetCallSign();
            AIType aiType = this._combatantCallSignControllerTypes[combatantCallSign];
            if (aiType != AIType.None)
            {
                ISortieControllerRequest sortieControllerRequest = this._aiTypeAIControllers[aiType]
                    .DetermineControllerRequest(null, sortieControllerRequests);
                this._selectedSortieControllerRequest = sortieControllerRequest;
                this._confirmedSortieControllerRequest = sortieControllerRequest;
            }
            else
            {
                // Waiting for human to do something
            }
        }

        /// <inheritdoc/>
        void IMvcSortieController.Clear()
        {
            this._sortieControllerRequests.Clear();
            this._selectedSortieControllerRequest = null;
            this._confirmedSortieControllerRequest = null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript parentUnityScript;

            // Todo
            private IMvcSortieFrameConstruction mvcSortieFrameConstruction;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcSortieController Build()
            {
                return new MvcSortieController(this.mvcSortieFrameConstruction, parentUnityScript);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                this.parentUnityScript = unityScript;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcSortieFrameConstruction"></param>
            /// <returns></returns>
            public Builder SetMvcSortieFrameConstruction(IMvcSortieFrameConstruction mvcSortieFrameConstruction)
            {
                this.mvcSortieFrameConstruction = mvcSortieFrameConstruction;
                return this;
            }
        }
    }
}