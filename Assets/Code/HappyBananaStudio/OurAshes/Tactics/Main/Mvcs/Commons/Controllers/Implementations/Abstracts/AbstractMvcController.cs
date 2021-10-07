using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc Controller Implementation
    /// </summary>
    public abstract class AbstractMvcController : IMvcController
    {
        // Todo
        protected readonly ILogger _logger;

        // Todo
        protected IMvcRequest _selectedMvcRequest = null;

        // Todo
        protected IMvcRequest _confirmedMvcRequest = null;

        // Todo
        protected ISet<IMvcRequest> _mvcRequests = new HashSet<IMvcRequest>();

        // Todo
        protected bool _isProcessing = false;

        // Todo
        private IMvcControllerReport _mvcControllerReport;

        // Todo
        protected IMvcControllerInput mvcControllerInput;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcController(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType(), this.GetType());
            this.BuildReport();
        }

        /// <inheritdoc/>
        public abstract void Process(IMvcModelReport mvcModelReport);

        /// <inheritdoc/>
        IMvcControllerReport IMvcController.GetReport()
        {
            return _mvcControllerReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void BuildReport()
        {
            _mvcControllerReport = MvcControllerReport.Builder.Get()
                .SetConfirmedRequest(_confirmedMvcRequest)
                .SetSelectedRequest(_selectedMvcRequest)
                .SetHasRequests(_mvcRequests.Count != 0)
                .SetIsProcessing(_isProcessing)
                .Build();
        }
    }
}