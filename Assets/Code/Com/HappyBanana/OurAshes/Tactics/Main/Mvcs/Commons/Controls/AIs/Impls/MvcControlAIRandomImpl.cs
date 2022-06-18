using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.AIs.Impls
{
    /// <summary>
    /// Mvc Control AI Random Impl
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
        IMvcRequest IMvcControlAI.DetermineBestRequest(IMvcFrameState mvcFrameState)
        {
            return null;
        }
    }
}