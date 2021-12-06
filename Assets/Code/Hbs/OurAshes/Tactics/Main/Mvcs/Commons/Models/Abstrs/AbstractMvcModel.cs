using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Impls;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Abstrs
{
    /// <summary>
    /// Abstract Mvc Model Implementation
    /// </summary>
    public abstract class AbstractMvcModel : IMvcModel
    {
        // Todo
        protected readonly IClassLogger _logger;

        // Todo
        protected ISet<IMvcRequest> _mvcRequests = new HashSet<IMvcRequest>();

        // Todo
        protected bool _isProcessing = true;

        // Todo
        protected IMvcFrameConstruction _mvcFrameConstruction;

        // Todo
        private IMvcModelReport _mvcModelReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType()).GetClassLogger(this.GetType());
            _mvcFrameConstruction = mvcFrameConstruction;
            this.BuildInitialRequests();
            this.BuildReport();
        }

        /// <inheritdoc/>
        IMvcModelReport IMvcModel.GetReport()
        {
            return _mvcModelReport;
        }

        /// <inheritdoc/>
        void IMvcModel.Process(IMvcControllerReport mvcControllerReport)
        {
            if (mvcControllerReport.GetSelectedRequest().IsPresent())
            {
                if (mvcControllerReport.GetConfirmedRequest().IsPresent())
                {
                    this.ProcessConfirmedRequest(mvcControllerReport.GetConfirmedRequest().GetValue());
                }
                else
                {
                    _logger.Info("No Confirmed {}...", typeof(IMvcRequest));
                }
            }
            else
            {
                _logger.Info("No Selected {}...", typeof(IMvcRequest));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        protected void BuildReport()
        {
            _mvcModelReport = MvcModelReport.Builder.Get()
                .SetIsProcessing(_isProcessing)
                .SetMvcRequests(_mvcRequests)
                .Build();
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcRequest"></param>
        protected abstract void ProcessConfirmedRequest(IMvcRequest mvcRequest);

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void BuildInitialRequests();
    }
}