using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Implementaions
{
    /// <summary>
    /// Random AI Sortie Controller Implementation
    /// </summary>
    public class RandomAISortieController
        : IAISortieController
    {
        /// <inheritdoc/>
        ISortieControllerRequest IAISortieController.DetermineControllerRequest(IMvcModelResponse mvcModelResponse, ISet<ISortieControllerRequest> mvcControllerRequests)
        {
            int randomIndex = RandomManager.GetSortieRandom().Next(mvcControllerRequests.Count);
            return new List<ISortieControllerRequest>(mvcControllerRequests)[randomIndex];
        }
    }
}