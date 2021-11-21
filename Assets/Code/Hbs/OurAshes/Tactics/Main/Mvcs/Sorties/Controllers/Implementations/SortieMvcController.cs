using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.AIs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.AIs.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Contstructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Implementaions;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Implementations
{
    /// <summary>
    /// Sortie Mvc Controller Interface
    /// </summary>
    public class SortieMvcController : AbstractMvcController, IMvcController
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
        }

        /// <inheritdoc/>
        public override void Process(IMvcModelReport mvcModelReport)
        {
            if (mvcModelReport is IMvcResponse sortieResponse)
            {
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
    }
}