using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Models.Combatants.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.AIs.Implementaions;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controls.Impls
{
    /// <summary>
    /// Sortie Mvc Control Interface
    /// </summary>
    public class MvcControlSortieImpl : AbstractMvcControl, IMvcControl
    {
        // Todo
        private readonly IDictionary<AIType, IMvcControlAI> _aiTypeAIControls = new Dictionary<AIType, IMvcControlAI>()
            {
                {  AIType.Random, new SortieControlPoacherAI() },
                {  AIType.Poacher, new SortieControlPoacherAI() },
            };

        // Todo
        private readonly IDictionary<CombatantCallSign, AIType> _combatantCallSignControlTypes =
            new Dictionary<CombatantCallSign, AIType>();

        // Todo
        private readonly ISet<IMvcControlSortieRequest> _sortieRequests = new HashSet<IMvcControlSortieRequest>();

        // Todo
        private IMvcControlSortieRequest _confirmedSortieRequest;

        // Todo
        private IMvcControlSortieRequest _selectedSortieRequest;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public MvcControlSortieImpl(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
            IMvcControlConstruction mvcControlConstruction = mvcFrameConstruction.GetMvcControlConstruction();
        }

        public override void Process(IMvcModelState mvcModelState)
        {
            throw new System.NotImplementedException();
        }

        public override void Process(IMvcViewState mvcViewState)
        {
            throw new System.NotImplementedException();
        }

        public override void Process(IMvcControlInput mvcControlInput)
        {
            throw new System.NotImplementedException();
        }

        protected override IMvcControlState BuildInitialMvcControlState()
        {
            throw new System.NotImplementedException();
        }
    }
}