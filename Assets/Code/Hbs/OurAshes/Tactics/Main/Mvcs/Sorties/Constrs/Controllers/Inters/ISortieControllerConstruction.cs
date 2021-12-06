using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Contstructions.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controllers.Engagements.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constrs.Controllers.Inters
{
    public interface ISortieControllerConstruction : IMvcControllerConstruction
    {
        IEngagementControllerConstruction GetEngagementControllerConstruction();
    }
}