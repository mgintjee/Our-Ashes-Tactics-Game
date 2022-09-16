using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.States.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils.Combatants;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils.Fields;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Models.Utils
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