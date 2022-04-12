using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Impls;
using System;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Utils
{
    public class MvcModelStateRandomizerUtil
    {
        public static IMvcModelState Randomize(Random random)
        {
            MvcModelStateImpl mvcModelState = new MvcModelStateImpl();
            IFieldDetails fieldDetails = FieldDetailsRandomizerUtil.Randomize(random);
            ISet<IPhalanxDetails> phalanxDetails = PhalanxDetailsRandomizerUtil.Randomize(random, fieldDetails);
            mvcModelState.SetFieldDetails(fieldDetails);
            mvcModelState.SetPhalanxDetails(phalanxDetails);
            return mvcModelState;
        }
    }
}