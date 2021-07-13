using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Controllers.Implementations
{
    /// <summary>
    /// Central Controller Implementation
    /// </summary>
    public class CentralController
        : AbstractMvcController, IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public CentralController(IMvcFrameConstruction mvcFrameConstruction)
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

        public override void Process(IMvcResponse mvcResponse)
        {
            throw new System.NotImplementedException();
        }

        public override void Stop()
        {
            throw new System.NotImplementedException();
        }
    }
}