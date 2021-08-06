using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Constructions.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Engagements.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Constructions.Controllers.Interfaces
{
    public interface ISortieControllerConstruction : IMvcControllerConstruction
    {
        IEngagementControllerConstruction GetEngagementControllerConstruction();
    }
}