using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc Model Implementation
    /// </summary>
    public abstract class AbstractMvcModel : IMvcModel
    {
        // Todo
        protected readonly ILogger _logger;

        // Todo
        protected IMvcModelReport _mvcModelReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType(), this.GetType());
        }

        /// <inheritdoc/>
        public abstract void Process(IMvcRequest mvcRequest);

        /// <inheritdoc/>
        IMvcModelReport IMvcModel.GetMvcModelReport()
        {
            return _mvcModelReport;
        }
    }
}