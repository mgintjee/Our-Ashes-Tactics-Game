using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Impls
{
    /// <summary>
    /// Random Control AI Implementation
    /// </summary>
    public class RandomControlAI : IControlAI
    {
        // Todo
        private readonly Random _random;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        public RandomControlAI(Random random)
        {
            _random = random;
        }

        /// <inheritdoc/>
        IMvcRequest IControlAI.DetermineBestRequest(IMvcResponse mvcResponse)
        {
            ISet<IMvcRequest> mvcRequests = mvcResponse.GetMvcRequests();
            return new List<IMvcRequest>(mvcRequests)[_random.Next(mvcRequests.Count)];
        }
    }
}