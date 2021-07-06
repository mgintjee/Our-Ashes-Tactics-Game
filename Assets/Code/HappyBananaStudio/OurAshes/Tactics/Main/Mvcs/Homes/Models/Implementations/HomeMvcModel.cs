using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Homes.Models.Implementations
{
    /// <summary>
    /// Home Mvc Model Implementation
    /// </summary>
    public class HomeMvcModel
        : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public HomeMvcModel(IMvcFrameConstruction mvcFrameConstruction)
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