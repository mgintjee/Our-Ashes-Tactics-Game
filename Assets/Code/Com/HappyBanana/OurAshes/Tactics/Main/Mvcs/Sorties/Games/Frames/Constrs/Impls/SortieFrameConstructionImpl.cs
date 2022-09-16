using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Games.Frames.Constrs.Impls
{
    /// <summary>
    /// Sortie Frame Construction Implementation
    /// </summary>
    public class SortieFrameConstructionImpl
        : MvcFrameConstructionImpl, ISortieFrameConstruction
    {
        private readonly IFieldDetails fieldDetails;
        private readonly ICombatantsDetails combatantsDetails;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="combatantsDetails"></param>
        /// <param name="fieldDetails">     </param>
        /// <param name="mvcType">          </param>
        /// <param name="simulationType">   </param>
        /// <param name="unityScript">      </param>
        /// <param name="random">           </param>
        public SortieFrameConstructionImpl(ICombatantsDetails combatantsDetails, IFieldDetails fieldDetails,
            MvcType mvcType, SimType simulationType, IUnityScript unityScript, Random random)
            : base(mvcType, simulationType, unityScript, random)
        {
            this.fieldDetails = fieldDetails;
            this.combatantsDetails = combatantsDetails;
        }

        public ICombatantsDetails GetCombatantsDetails()
        {
            return this.combatantsDetails;
        }

        public IFieldDetails GetFieldDetails()
        {
            return this.fieldDetails;
        }
    }
}