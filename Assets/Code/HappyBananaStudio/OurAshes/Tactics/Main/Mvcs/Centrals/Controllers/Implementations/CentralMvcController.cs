using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Controllers.Implementations
{
    /// <summary>
    /// Central Mvc Controller Implementation
    /// </summary>
    public class CentralMvcController
        : AbstractMvcController, IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public CentralMvcController(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        public override bool HasRequests()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        public override IMvcRequest OutputConfirmedMvcRequest()
        {
            throw new System.NotImplementedException();
        }

        public override IMvcRequest OutputSelectedMvcRequest()
        {
            throw new System.NotImplementedException();
        }

        public override void Process(ISet<IMvcRequest> requests)
        {
            throw new System.NotImplementedException();
        }

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }
    }
}