using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Reports.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Abstrs
{
    /// <summary>
    /// Abstract Mvc Control Implementation
    /// </summary>
    public abstract class AbstractMvcControl : IMvcControl
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
        protected IMvcControlInput mvcControlInput;

        // Todo
        private IMvcControlReport _mvcControlReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcControl(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType()).GetClassLogger(this.GetType());
            this.BuildReport();
        }

        /// <inheritdoc/>
        public abstract void Process(IMvcModelReport mvcModelReport);

        /// <inheritdoc/>
        IMvcControlReport IMvcControl.GetReport()
        {
            return _mvcControlReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void BuildReport()
        {
            _mvcControlReport = MvcControlReport.Builder.Get()
                .SetConfirmedRequest(_confirmedMvcRequest)
                .SetSelectedRequest(_selectedMvcRequest)
                .SetHasRequests(_mvcRequests.Count != 0)
                .SetIsProcessing(_isProcessing)
                .Build();
        }
    }
}