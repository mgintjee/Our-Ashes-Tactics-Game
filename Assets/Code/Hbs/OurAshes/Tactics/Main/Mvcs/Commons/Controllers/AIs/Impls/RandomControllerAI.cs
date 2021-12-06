using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.AIs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.AIs.Impls
{
    /// <summary>
    /// Random Controller AI Implementation
    /// </summary>
    public class RandomControllerAI : IControllerAI
    {
        // Todo
        private readonly Random _random;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        public RandomControllerAI(Random random)
        {
            _random = random;
        }

        /// <inheritdoc/>
        IMvcRequest IControllerAI.DetermineBestRequest(IMvcResponse mvcResponse)
        {
            ISet<IMvcRequest> mvcRequests = mvcResponse.GetMvcRequests();
            return new List<IMvcRequest>(mvcRequests)[_random.Next(mvcRequests.Count)];
        }
    }
}