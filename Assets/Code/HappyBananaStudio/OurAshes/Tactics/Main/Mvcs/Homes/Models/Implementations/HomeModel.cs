using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Models.Implementations
{
    /// <summary>
    /// Home Model Implementation
    /// </summary>
    public class HomeModel : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeModel(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        /// <inheritdoc/>
        ISet<IMvcRequest> IMvcModel.GetMvcRequests()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        IMvcResponse IMvcModel.GetMvcResponse()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        bool IMvcModel.IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        void IMvcModel.Process(IMvcRequest mvcControllerRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}