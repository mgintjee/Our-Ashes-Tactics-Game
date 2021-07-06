using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc Model Implementation
    /// </summary>
    public abstract class AbstractMvcModel
        : IMvcModel
    {
        // Todo
        protected readonly ILogger _logger;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType(), this.GetType());
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