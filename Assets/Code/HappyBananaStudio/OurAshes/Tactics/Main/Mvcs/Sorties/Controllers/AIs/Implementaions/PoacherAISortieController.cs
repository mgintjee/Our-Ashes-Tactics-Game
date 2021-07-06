using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Implementaions
{
    /// <summary>
    /// Poacher AI Sortie Controller Implementation
    /// </summary>
    public class PoacherAISortieController
        : IAISortieController
    {
        /// <inheritdoc/>
        ISortieRequest IAISortieController.DetermineControllerRequest(IMvcModelResponse mvcModelResponse, ISet<ISortieRequest> sortieControllerRequests)
        {
            ISet<ISortieRequest> fireSortieControllerRequests = new HashSet<ISortieRequest>();
            foreach (ISortieRequest sortieControllerRequest in sortieControllerRequests)
            {
                if (sortieControllerRequest.GetPath().GetPathType() == PathType.Fire)
                {
                    fireSortieControllerRequests.Add(sortieControllerRequest);
                }
            }
            if (fireSortieControllerRequests.Count != 0)
            {
                int fireRandomIndex = RandomManager.GetRandom(MvcType.Sortie).Next(fireSortieControllerRequests.Count);
                return new List<ISortieRequest>(fireSortieControllerRequests)[fireRandomIndex];
            }
            int randomIndex = RandomManager.GetRandom(MvcType.Sortie).Next(sortieControllerRequests.Count);
            return new List<ISortieRequest>(sortieControllerRequests)[randomIndex];
        }
    }
}