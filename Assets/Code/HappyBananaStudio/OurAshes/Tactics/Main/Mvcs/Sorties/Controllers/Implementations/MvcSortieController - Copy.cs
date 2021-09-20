/*using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.AIs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
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
        private readonly ISet<ISortieRequest> _sortieControllerRequests = new HashSet<ISortieRequest>();

        // Todo
        private ISortieRequest _confirmedSortieControllerRequest;

        // Todo
        private ISortieRequest _selectedSortieControllerRequest;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcSortieFrameConstruction"></param>
        /// <param name="unityScript">               </param>
        private MvcSortieController(IMvcControllerConstruction mvcSortieFrameConstruction, IUnityScript unityScript)
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
                    _combatantCallSignControllerTypes.Add(combatantCallSign,
                        phalanxModelConstruction.GetAIType());
                }
            }
        }

        /// <inheritdoc/>
        ISortieRequest IMvcSortieController.GetConfirmedControllerRequest()
        {
            return _confirmedSortieControllerRequest;
        }

        /// <inheritdoc/>
        ISet<ISortieRequest> IMvcSortieController.GetControllerRequests()
        {
            return new HashSet<ISortieRequest>(_sortieControllerRequests);
        }

        /// <inheritdoc/>
        ISortieRequest IMvcSortieController.GetSelectedControllerRequest()
        {
            return _selectedSortieControllerRequest;
        }

        /// <inheritdoc/>
        bool IMvcSortieController.IsProcessing()
        {
            return _sortieControllerRequests.Count != 0 &&
                (_selectedSortieControllerRequest == null ||
                _confirmedSortieControllerRequest == null);
        }

        /// <inheritdoc/>
        void IMvcSortieController.Process(ISet<ISortieRequest> sortieControllerRequests)
        {
            if (sortieControllerRequests.Count == 0)
            {
                throw ExceptionUtil.Arguments.Build();
            }
            _logger.Info("Available {}s ({}): [" +
                "\n{}" +
                "\n]",
                typeof(ISortieRequest), sortieControllerRequests.Count,
                string.Join("\n", sortieControllerRequests));
            _sortieControllerRequests.Clear();
            _sortieControllerRequests.UnionWith(sortieControllerRequests);
            _selectedSortieControllerRequest = null;
            _confirmedSortieControllerRequest = null;
            CombatantCallSign combatantCallSign = new List<ISortieRequest>
                (sortieControllerRequests)[0].GetCallSign();
            AIType aiType = _combatantCallSignControllerTypes[combatantCallSign];
            if (aiType != AIType.None)
            {
                ISortieRequest sortieControllerRequest = _aiTypeAIControllers[aiType]
                    .DetermineControllerRequest(null, sortieControllerRequests);
                _selectedSortieControllerRequest = sortieControllerRequest;
                _confirmedSortieControllerRequest = sortieControllerRequest;
            }
            else
            {
                // Waiting for human to do something
            }
        }

        /// <inheritdoc/>
        void IMvcSortieController.Clear()
        {
            _sortieControllerRequests.Clear();
            _selectedSortieControllerRequest = null;
            _confirmedSortieControllerRequest = null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript _parentUnityScript;

            // Todo
            private IMvcControllerConstruction _mvcSortieFrameConstruction;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcSortieController Build()
            {
                return new MvcSortieController(_mvcSortieFrameConstruction, _parentUnityScript);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="unityScript"></param>
            /// <returns></returns>
            public Builder SetUnityScript(IUnityScript unityScript)
            {
                _parentUnityScript = unityScript;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcSortieFrameConstruction"></param>
            /// <returns></returns>
            public Builder SetMvcSortieFrameConstruction(IMvcControllerConstruction mvcSortieFrameConstruction)
            {
                _mvcSortieFrameConstruction = mvcSortieFrameConstruction;
                return this;
            }
        }
    }
}*/