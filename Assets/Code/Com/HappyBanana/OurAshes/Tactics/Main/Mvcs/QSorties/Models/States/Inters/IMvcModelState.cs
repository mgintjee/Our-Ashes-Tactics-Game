using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters
{
    public interface IMvcModelState
        : Commons.Models.States.Inters.IMvcModelState
    {
        IFieldDetails GetFieldDetails();

        IList<IFactionDetails> GetFactionDetails();
    }
}