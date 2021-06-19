using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.AIs.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Comparers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Comparers.Implementaions.Randoms;
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
        private static readonly ILogger _logger = LoggerManager.GetSortieLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<AIType, IControllerRequestComparer> controllerTypeRequestComparers
            = new Dictionary<AIType, IControllerRequestComparer>()
            {
                {  AIType.Random, new RandomMvcControllerRequestComparer() },
            };

        // Todo
        private readonly IDictionary<CombatantCallSign, AIType> combatantCallSignControllerTypes =
            new Dictionary<CombatantCallSign, AIType>();

        // Todo
        private ISortieControllerRequest confirmedSortieControllerRequest;

        // Todo
        private ISortieControllerRequest selectedSortieControllerRequest;

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
                    this.combatantCallSignControllerTypes.Add(combatantCallSign,
                        phalanxModelConstruction.GetAIType());
                }
            }
        }

        /// <inheritdoc/>
        ISortieControllerRequest IMvcSortieController.GetConfirmedControllerRequest()
        {
            return confirmedSortieControllerRequest;
        }

        /// <inheritdoc/>
        ISortieControllerRequest IMvcSortieController.GetSelectedControllerRequest()
        {
            return selectedSortieControllerRequest;
        }

        /// <inheritdoc/>
        bool IMvcSortieController.IsProcessing()
        {
            return this.selectedSortieControllerRequest == null ||
                this.confirmedSortieControllerRequest == null;
        }

        /// <inheritdoc/>
        void IMvcSortieController.Process(ISet<ISortieControllerRequest> sortieControllerRequests)
        {
            if (sortieControllerRequests.Count == 0)
            {
                throw ExceptionUtil.Arguments.Build();
            }
            _logger.Info(":{}", string.Join(", ", sortieControllerRequests));
            CombatantCallSign combatantCallSign = new List<ISortieControllerRequest>
                (sortieControllerRequests)[0].GetCallSign();
            AIType controllerType = this.combatantCallSignControllerTypes[combatantCallSign];
            if (controllerType != AIType.None)
            {
                IControllerRequestComparer controllerRequestComparer = this.controllerTypeRequestComparers[controllerType];
                IList<ISortieControllerRequest> sortieControllerRequestList = new List<ISortieControllerRequest>();
                ((List<ISortieControllerRequest>)sortieControllerRequestList).Sort(controllerRequestComparer);
                this.selectedSortieControllerRequest = sortieControllerRequestList[0];
                this.confirmedSortieControllerRequest = sortieControllerRequestList[0];
            }
            else
            {
                // Waiting for human to do something
            }
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