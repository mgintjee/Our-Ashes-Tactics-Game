using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using System;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Impls
{
    /// <summary>
    /// Mvc Control AI Random Implementation
    /// </summary>
    public class MvcControlAIRandomImpl : IMvcControlAI
    {
        // Todo
        private readonly Random _random;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="random"></param>
        public MvcControlAIRandomImpl(Random random)
        {
            _random = random;
        }

        /// <inheritdoc/>
        IMvcControlRequest IMvcControlAI.DetermineBestRequest(IMvcFrameState mvcFrameState)
        {
            ISet<IMvcControlRequest> mvcControlRequests = mvcFrameState
                .GetMvcModelState().GetMvcControlRequests();
            return new List<IMvcControlRequest>(mvcControlRequests)
                [_random.Next(mvcControlRequests.Count)];
        }
    }
}