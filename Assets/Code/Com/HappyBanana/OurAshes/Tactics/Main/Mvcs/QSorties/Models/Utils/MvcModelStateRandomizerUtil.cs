using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Mods;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.Utils.Randomizations
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcModelStateRandomizerUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static IMvcModelState Randomize(Random random)
        {
            IFieldDetails fieldDetails = FieldDetailsRandomizerUtil.Randomize(random);
            ICombatantsDetails combatantsDetails = CombatantsRandomizerUtil.Randomize(random, fieldDetails.GetFieldSize());
            FieldModUtil.UpdateTileDetailsUnitIDs(fieldDetails, combatantsDetails.GetUnitDetails());
            return new MvcModelStateImpl()
                .SetCombatantsDetails(combatantsDetails)
                .SetFieldDetails(fieldDetails);
        }
    }
}