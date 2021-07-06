using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Interfaces;
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
        ISortieRequest IAISortieController.DetermineControllerRequest(IMvcModelResponse mvcModelResponse, ISet<ISortieRequest> mvcControllerRequests)
        {
            int randomIndex = RandomManager.GetRandom(MvcType.Sortie).Next(mvcControllerRequests.Count);
            return new List<ISortieRequest>(mvcControllerRequests)[randomIndex];
        }
    }
}