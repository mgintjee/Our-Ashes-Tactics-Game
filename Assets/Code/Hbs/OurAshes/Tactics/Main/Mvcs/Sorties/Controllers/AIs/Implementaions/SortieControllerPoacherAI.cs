using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Sorties.Maps.Paths.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Randoms.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.AIs.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Frames.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Sorties.Controllers.AIs.Implementaions
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SortieControllerPoacherAI : IControllerAI
    {
        /// <inheritdoc/>
        IMvcRequest IControllerAI.DetermineBestRequest(IMvcResponse mvcResponse)
        {
            ISet<ISortieRequest> mvcRequests = new HashSet<ISortieRequest>((ISet<ISortieRequest>)mvcResponse.GetMvcRequest());
            ISet<ISortieRequest> fireSortieRequests = new HashSet<ISortieRequest>();
            foreach (ISortieRequest sortieRequest in mvcRequests)
            {
                if (sortieRequest.GetPath().GetPathType() == PathType.Fire)
                {
                    fireSortieRequests.Add(sortieRequest);
                }
            }
            if (fireSortieRequests.Count != 0)
            {
                int fireRandomIndex = RandomManager.GetRandom(MvcType.Sortie).Next(fireSortieRequests.Count);
                return new List<ISortieRequest>(fireSortieRequests)[fireRandomIndex];
            }
            int randomIndex = RandomManager.GetRandom(MvcType.Sortie).Next(mvcRequests.Count);
            return new List<ISortieRequest>(mvcRequests)[randomIndex];
        }
    }
}