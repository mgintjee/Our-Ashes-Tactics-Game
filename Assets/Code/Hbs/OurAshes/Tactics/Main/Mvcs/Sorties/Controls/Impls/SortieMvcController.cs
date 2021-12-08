using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controls.AIs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.AIs.Implementaions;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Impls
{
    /// <summary>
    /// Sortie Mvc Control Interface
    /// </summary>
    public class SortieMvcControl : AbstractMvcControl, IMvcControl
    {
        // Todo
        private readonly IDictionary<AIType, IControlAI> _aiTypeAIControls = new Dictionary<AIType, IControlAI>()
            {
                {  AIType.Random, new SortieControlPoacherAI() },
                {  AIType.Poacher, new SortieControlPoacherAI() },
            };

        // Todo
        private readonly IDictionary<CombatantCallSign, AIType> _combatantCallSignControlTypes =
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
        public SortieMvcControl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
            IMvcControlConstruction mvcControlConstruction = mvcFrameConstruction.GetMvcControlConstruction();
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