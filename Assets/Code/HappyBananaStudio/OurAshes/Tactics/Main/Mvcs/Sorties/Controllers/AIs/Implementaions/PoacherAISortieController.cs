using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Maps.Paths.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.Requests.Interfaces;
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
        ISortieControllerRequest IAISortieController.DetermineControllerRequest(IMvcModelResponse mvcModelResponse, ISet<ISortieControllerRequest> sortieControllerRequests)
        {
            ISet<ISortieControllerRequest> fireSortieControllerRequests = new HashSet<ISortieControllerRequest>();
            foreach (ISortieControllerRequest sortieControllerRequest in sortieControllerRequests)
            {
                if (sortieControllerRequest.GetPath().GetPathType() == PathType.Fire)
                {
                    fireSortieControllerRequests.Add(sortieControllerRequest);
                }
            }
            if (fireSortieControllerRequests.Count != 0)
            {
                int fireRandomIndex = RandomManager.GetSortieRandom().Next(fireSortieControllerRequests.Count);
                return new List<ISortieControllerRequest>(fireSortieControllerRequests)[fireRandomIndex];
            }
            int randomIndex = RandomManager.GetSortieRandom().Next(sortieControllerRequests.Count);
            return new List<ISortieControllerRequest>(sortieControllerRequests)[randomIndex];
        }
    }
}