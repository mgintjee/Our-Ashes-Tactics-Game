using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Factions.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Phalanxes.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Units.IDs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcModelStateImpl
        : DefaultMvcModelStateImpl, IMvcModelState
    {
        private ICombatantsDetails combatantsDetails;
        private IFieldDetails fieldDetails;

        public override Commons.Models.States.Inters.IMvcModelState GetCopy()
        {
            return new MvcModelStateImpl()
                .SetFieldDetails(this.fieldDetails)
                .SetCombatantsDetails(this.combatantsDetails)
                .SetPrevMvcRequest(this.prevMvcRequest);
        }

        public MvcModelStateImpl SetCombatantsDetails(ICombatantsDetails details)
        {
            this.combatantsDetails = details;
            return this;
        }

        public MvcModelStateImpl SetFieldDetails(IFieldDetails details)
        {
            this.fieldDetails = details;
            return this;
        }


        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("\n{0}" +
                "\n{1}" +
                "\n{2}",
                this.combatantsDetails, this.fieldDetails, this.prevMvcRequest);
        }

        IFieldDetails IMvcModelState.GetFieldDetails()
        {
            return this.fieldDetails;
        }

        ICombatantsDetails IMvcModelState.GetCombatantsDetails()
        {
            return this.combatantsDetails;
        }
    }
}