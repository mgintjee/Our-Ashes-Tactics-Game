using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Contstructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Interfaces;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Interfaces
{
    public interface ISortieControllerConstruction : IMvcControllerConstruction
    {
        IEngagementControllerConstruction GetEngagementControllerConstruction();
    }
}