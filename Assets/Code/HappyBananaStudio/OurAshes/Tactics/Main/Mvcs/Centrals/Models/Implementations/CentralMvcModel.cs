using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Centrals.Models.Implementations
{
    /// <summary>
    /// Central Model Implementation
    /// </summary>
    public class CentralMvcModel : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public CentralMvcModel(IMvcFrameConstruction mvcFrameConstruction)
            : base(mvcFrameConstruction)
        {
        }

        ISet<IMvcRequest> IMvcModel.GetMvcRequests()
        {
            throw new System.NotImplementedException();
        }

        IMvcResponse IMvcModel.GetMvcResponse()
        {
            throw new System.NotImplementedException();
        }

        bool IMvcModel.IsProcessing()
        {
            throw new System.NotImplementedException();
        }

        void IMvcModel.Process(IMvcRequest mvcControllerRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}