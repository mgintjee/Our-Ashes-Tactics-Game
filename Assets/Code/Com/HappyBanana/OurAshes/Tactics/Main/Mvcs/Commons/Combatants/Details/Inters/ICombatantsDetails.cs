using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Combatants.Details.Inters
{
    public interface ICombatantsDetails
    {
        IList<IFactionDetails> GetFactionDetails();

        IList<IPhalanxDetails> GetPhalanxDetails();

        IList<IUnitDetails> GetUnitDetails();
    }
}