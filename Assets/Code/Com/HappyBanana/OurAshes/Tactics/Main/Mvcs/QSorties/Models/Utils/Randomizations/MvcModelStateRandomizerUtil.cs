using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations
{
    public class MvcModelStateRandomizerUtil
    {
        public static IMvcModelState Randomize(Random random)
        {
            MvcModelStateImpl mvcModelState = new MvcModelStateImpl();
            IFieldDetails fieldDetails = FieldDetailsRandomizerUtil.Randomize(random);
            ICombatantsDetails combatantsDetails = CombatantsDetailsRandomizerUtil.Randomize(random, fieldDetails.GetFieldSize());
            mvcModelState.SetFieldDetails(fieldDetails);
            mvcModelState.SetCombatantsDetails(combatantsDetails);
            return mvcModelState;
        }
    }
}