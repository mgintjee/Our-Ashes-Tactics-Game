using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Implementations
{
    /// <summary>
    /// Home Mvc Controller Implementation
    /// </summary>
    public class HomeMvcController
        : AbstractMvcController, IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeMvcController(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        public override bool HasRequests()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public override bool IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public override IMvcRequest OutputConfirmedMvcRequest()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public override IMvcRequest OutputSelectedMvcRequest()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Process(ISet<IMvcRequest> requests)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Stop()
        {
            throw new System.NotImplementedException();
        }
    }
}