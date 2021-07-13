using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Models.Implementations
{
    /// <summary>
    /// Sortie Model Implementation
    /// </summary>
    public class SortieModel : AbstractMvcModel, IMvcModel
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public SortieModel(IMvcFrameConstruction mvcFrameConstruction) : base(mvcFrameConstruction)
        {
        }

        public override void Process(IMvcRequest mvcRequest)
        {
            throw new System.NotImplementedException();
        }

        IMvcModelReport IMvcModel.GetMvcModelReport()
        {
            throw new System.NotImplementedException();
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