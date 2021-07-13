using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Controllers.Implementations
{
    /// <summary>
    /// Home Controller Implementation
    /// </summary>
    public class HomeController : AbstractMvcController, IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeController(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
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
        public override void Process(IMvcResponse mvcResponse)
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