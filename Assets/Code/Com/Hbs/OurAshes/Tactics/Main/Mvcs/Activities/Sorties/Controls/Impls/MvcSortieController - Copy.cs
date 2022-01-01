/*using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.AIs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.AIs.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.AIs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Requests.Inters;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Activities.Sorties.Controls.Impls
{
    /// <summary>
    /// Sortie Mvc Control Interface
    /// </summary>
    public class MvcSortieControl
        : AbstractControl, IMvcSortieControl
    {
        // Todo
        private readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.Sortie, new StackFrame().GetMethod().DeclaringType);

        // Todo
        private readonly IDictionary<AIType, IAISortieControl> _aiTypeAIControls = new Dictionary<AIType, IAISortieControl>()
            {
                {  AIType.Random, new PoacherAISortieControl() },
                {  AIType.Poacher, new PoacherAISortieControl() },
            };

        // Todo
        private readonly IDictionary<CombatantCallSign, AIType> _combatantCallSignControlTypes =
            new Dictionary<CombatantCallSign, AIType>();

        // Todo
        private readonly ISet<ISortieRequest> _sortieModelRequests = new HashSet<ISortieRequest>();

        // Todo
        private ISortieRequest _confirmedSortieModelRequest;

        // Todo
        private ISortieRequest _selectedSortieModelRequest;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcSortieFrameConstruction"></param>
        /// <param name="unityScript">               </param>
        private MvcSortieControl(IMvcControlConstruction mvcSortieFrameConstruction, IUnityScript unityScript)
        {
            // Iterate over the PhalanxConstrs
            foreach (IPhalanxConstruction phalanxConstruction in
                mvcSortieFrameConstruction.GetFormationConstruction().GetPhalanxConstrs())
            {
                // Collect the PhalanxModelConstruction
                IPhalanxConstruction phalanxModelConstruction = phalanxConstruction;
                // Iterate over the CombatantCallSigns for this PhalanxConstruction
                foreach (CombatantCallSign combatantCallSign in
                    phalanxModelConstruction.GetCombatantCallSigns())
                {
                    // Map the CombatantCallSign to the Phalanx's ControlType
                    _combatantCallSignControlTypes.Add(combatantCallSign,
                        phalanxModelConstruction.GetAIType());
                }
            }
        }

        /// <inheritdoc/>
        ISortieRequest IMvcSortieControl.GetConfirmedModelRequest()
        {
            return _confirmedSortieModelRequest;
        }

        /// <inheritdoc/>
        ISet<ISortieRequest> IMvcSortieControl.GetModelRequests()
        {
            return new HashSet<ISortieRequest>(_sortieModelRequests);
        }

        /// <inheritdoc/>
        ISortieRequest IMvcSortieControl.GetSelectedModelRequest()
        {
            return _selectedSortieModelRequest;
        }

        /// <inheritdoc/>
        bool IMvcSortieControl.IsProcessing()
        {
            return _sortieModelRequests.Count != 0 &&
                (_selectedSortieModelRequest == null ||
                _confirmedSortieModelRequest == null);
        }

        /// <inheritdoc/>
        void IMvcSortieControl.Process(ISet<ISortieRequest> sortieModelRequests)
        {
            if (sortieModelRequests.Count == 0)
            {
                throw ExceptionUtil.Arguments.Build();
            }
            logger.Info("Available {}s ({}): [" +
                "\n{}" +
                "\n]",
                typeof(ISortieRequest), sortieModelRequests.Count,
                string.Join("\n", sortieModelRequests));
            _sortieModelRequests.Clear();
            _sortieModelRequests.UnionWith(sortieModelRequests);
            _selectedSortieModelRequest = null;
            _confirmedSortieModelRequest = null;
            CombatantCallSign combatantCallSign = new List<ISortieRequest>
                (sortieModelRequests)[0].GetCallSign();
            AIType aiType = _combatantCallSignControlTypes[combatantCallSign];
            if (aiType != AIType.None)
            {
                ISortieRequest sortieModelRequest = _aiTypeAIControls[aiType]
                    .DetermineModelRequest(null, sortieModelRequests);
                _selectedSortieModelRequest = sortieModelRequest;
                _confirmedSortieModelRequest = sortieModelRequest;
            }
            else
            {
                // Waiting for human to do something
            }
        }

        /// <inheritdoc/>
        void IMvcSortieControl.Clear()
        {
            _sortieModelRequests.Clear();
            _selectedSortieModelRequest = null;
            _confirmedSortieModelRequest = null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IUnityScript _parentUnityScript;

            // Todo
            private IMvcControlConstruction _mvcSortieFrameConstruction;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcSortieControl Build()
            {
                return new MvcSortieControl(_mvcSortieFrameConstruction, _parentUnityScript);
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
            public Builder SetMvcSortieFrameConstruction(IMvcControlConstruction mvcSortieFrameConstruction)
            {
                _mvcSortieFrameConstruction = mvcSortieFrameConstruction;
                return this;
            }
        }
    }
}*/