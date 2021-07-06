using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc Controller Implementation
    /// </summary>
    public abstract class AbstractMvcController
        : IMvcController
    {
        // Todo
        protected readonly ILogger _logger;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcController(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType(), this.GetType());
        }

        /// <inheritdoc/>
        public abstract bool HasRequests();

        /// <inheritdoc/>
        public abstract bool IsProcessing();

        /// <inheritdoc/>
        public abstract IMvcRequest OutputConfirmedMvcRequest();

        /// <inheritdoc/>
        public abstract IMvcRequest OutputSelectedMvcRequest();

        /// <inheritdoc/>
        public abstract void Process(ISet<IMvcRequest> requests);

        /// <inheritdoc/>
        public abstract void Stop();
    }
}