using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.CallSigns;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters
{
    public interface IPhalanxDetails
    {
        PhalanxCallSign GetCallSign();

        IList<ICombatantDetails> GetCombatantDetails();
    }
}