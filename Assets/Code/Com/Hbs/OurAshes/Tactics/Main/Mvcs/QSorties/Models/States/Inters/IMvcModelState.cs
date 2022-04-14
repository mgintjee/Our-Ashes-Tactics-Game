using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Models.States.Inters
{
    public interface IMvcModelState
        : Commons.Models.States.Inters.IMvcModelState
    {
        IFieldDetails GetFieldDetails();

        ISet<IFactionDetails> GetFactionDetails();
    }
}