using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Utils.Enums;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Combatants;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Loadouts.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils
{
    public class CombatantDetailsRandomizerUtil
    {
        public static ICombatantDetails Randomize(Random random, CallSign callSign)
        {
            CombatantID combatantID = EnumUtils.GenerateRandomEnum<CombatantID>(random);
            ILoadoutDetails loadoutDetails = LoadoutDetailsRandomizerUtil.Randomize(random, combatantID);
            return CombatantDetailsImpl.Builder.Get()
                .SetCallSign(callSign)
                .SetCombatantID(combatantID)
                .SetLoadoutDetails(loadoutDetails)
                .Build();
        }
    }
}