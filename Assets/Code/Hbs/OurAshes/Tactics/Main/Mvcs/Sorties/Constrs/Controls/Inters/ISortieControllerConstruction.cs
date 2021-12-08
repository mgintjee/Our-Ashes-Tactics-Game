using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Engagements.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controls.Inters
{
    public interface ISortieControlConstruction : IMvcControlConstruction
    {
        IEngagementControlConstruction GetEngagementControlConstruction();
    }
}