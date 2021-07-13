using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Controllers.AIs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.AIs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Constructions.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Implementations
{
    /// <summary>
    /// Sortie Mvc Controller Interface
    /// </summary>
    public class SortieMvcController
        : AbstractMvcController, IMvcController
    {
        // Todo
        private readonly IDictionary<AIType, IControllerAI> _aiTypeAIControllers = new Dictionary<AIType, IControllerAI>()
            {
                {  AIType.Random, new SortieControllerPoacherAI() },
                {  AIType.Poacher, new SortieControllerPoacherAI() },
            };

        // Todo
        private readonly IDictionary<CombatantCallSign, AIType> _combatantCallSignControllerTypes =
            new Dictionary<CombatantCallSign, AIType>();

        // Todo
        private readonly ISet<ISortieRequest> _sortieRequests = new HashSet<ISortieRequest>();

        // Todo
        private ISortieRequest _confirmedSortieRequest;

        // Todo
        private ISortieRequest _selectedSortieRequest;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SortieMvcController(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
            IMvcControllerConstruction mvcControllerConstruction = mvcFrameConstruction.GetMvcControllerConstruction();
            if (mvcControllerConstruction is ISortieControllerConstruction sortieControllerConstruction)
            {
                _combatantCallSignControllerTypes = sortieControllerConstruction.GetCombatantCallSignAITypes();
            }
        }

        /// <inheritdoc/>
        public override bool HasRequests()
        {
            return _sortieRequests.Count != 0;
        }

        /// <inheritdoc/>
        public override bool IsProcessing()
        {
            return _sortieRequests.Count != 0 &&
                (_selectedSortieRequest == null ||
                _confirmedSortieRequest == null);
        }

        /// <inheritdoc/>
        public override IMvcRequest OutputConfirmedMvcRequest()
        {
            return _confirmedSortieRequest;
        }

        /// <inheritdoc/>
        public override IMvcRequest OutputSelectedMvcRequest()
        {
            return _selectedSortieRequest;
        }

        /// <inheritdoc/>
        public override void Process(IMvcResponse mvcResponse)
        {
            if (mvcResponse is IMvcResponse sortieResponse)
            {
                ((IMvcController)this).Stop();
                _sortieRequests.UnionWith((ISet<ISortieRequest>)sortieResponse.GetMvcRequests());
                _logger.Info("Available {} actions", _sortieRequests.Count);
                if (_sortieRequests.Count != 0)
                {
                    CombatantCallSign combatantCallSign = new List<ISortieRequest>
                        (_sortieRequests)[0].GetCallSign();
                }
                else
                {
                    // throw an error
                }
            }
        }

        /// <inheritdoc/>
        public override void Stop()
        {
            _selectedSortieRequest = null;
            _confirmedSortieRequest = null;
            _sortieRequests.Clear();
        }
    }
}