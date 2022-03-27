using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSortieMenus.Models.States.Inters
{
    public interface IMvcModelState
        : Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters.IMvcModelState
    {
        IFieldDetails GetFieldDetails();

        ISet<IPhalanxDetails> GetPhalanxDetails();
    }
}