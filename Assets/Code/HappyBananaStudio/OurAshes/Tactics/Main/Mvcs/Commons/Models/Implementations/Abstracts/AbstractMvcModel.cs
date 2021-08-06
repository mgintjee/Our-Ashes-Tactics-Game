using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Constructions.Frames.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces;
using System.Collections.Generic;

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
        protected ISet<IMvcRequest> _mvcRequests = new HashSet<IMvcRequest>();

        // Todo
        protected bool _isProcessing = true;

        // Todo
        private IMvcModelReport _mvcModelReport;

        // Todo
        protected IMvcFrameConstruction _mvcFrameConstruction;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameConstruction"></param>
        public AbstractMvcModel(IMvcFrameConstruction mvcFrameConstruction)
        {
            _logger = LoggerManager.GetLogger(mvcFrameConstruction.GetMvcType(), this.GetType());
            _mvcFrameConstruction = mvcFrameConstruction;
            this.BuildInitialRequests();
            this.BuildReport();
        }


        /// <inheritdoc/>
        IMvcModelReport IMvcModel.GetReport()
        {
            return _mvcModelReport;
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

        /// <inheritdoc/>
        void IMvcModel.Process(IMvcControllerReport mvcControllerReport)
        {
            if(mvcControllerReport.GetSelectedRequest().IsPresent())
            {
                if(mvcControllerReport.GetConfirmedRequest().IsPresent())
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
        /// <param name="mvcRequest"></param>
        protected abstract void ProcessConfirmedRequest(IMvcRequest mvcRequest);

        /// <summary>
        /// Todo
        /// </summary>
        protected abstract void BuildInitialRequests();
    }
}