using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.AIs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Combatants.CallSigns;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Implementaions;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Interfaces;
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
        private readonly IDictionary<AIType, IAISortieController> _aiTypeAIControllers = new Dictionary<AIType, IAISortieController>()
            {
                {  AIType.Random, new PoacherAISortieController() },
                {  AIType.Poacher, new PoacherAISortieController() },
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
        public override void Process(ISet<IMvcRequest> requests)
        {
            if (requests.Count != 0)
            {
                ((IMvcController)this).Stop();
                _sortieRequests.UnionWith((ISet<ISortieRequest>)requests);
            }
            else
            {
                // Throw an error
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