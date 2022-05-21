using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils.Randomizations
{
    public class MvcModelStateRandomizerUtil
    {
        public static IMvcModelState Randomize(Random random)
        {
            MvcModelStateImpl mvcModelState = new MvcModelStateImpl();
            IFieldDetails fieldDetails = FieldDetailsRandomizerUtil.Randomize(random);
            ISet<IFactionDetails> factionDetails = FactionDetailsRandomizerUtil.Randomize(random, fieldDetails);
            mvcModelState.SetFieldDetails(fieldDetails);
            mvcModelState.SetFactionDetails(factionDetails);
            return mvcModelState;
        }
    }
}