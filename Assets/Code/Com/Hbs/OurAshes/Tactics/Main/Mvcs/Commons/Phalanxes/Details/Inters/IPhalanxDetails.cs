using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.CallSigns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters
{
    public interface IPhalanxDetails
    {
        CallSign GetCallSign();

        ISet<ICombatantDetails> GetCombatantDetails();
    }
}