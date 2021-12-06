using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Controllers.Inputs.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Abstrs
{
    /// <summary>
    /// Abstract Mvc Controller Implementation
    /// </summary>
    public abstract class AbstractMvcController : IMvcController
    {
        // Todo
        protected readonly IClassLogger _logger;

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
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType()).GetClassLogger(this.GetType());
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