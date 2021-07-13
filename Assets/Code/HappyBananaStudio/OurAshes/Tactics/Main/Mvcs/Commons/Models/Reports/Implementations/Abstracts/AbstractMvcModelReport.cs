using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Reports.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc Model Report Implementation
    /// </summary>
    public abstract class AbstractMvcModelReport
        : AbstractReport, IMvcModelReport
    {
        // Todo
        private readonly ISet<IMvcRequest> _mvcRequests;

        // Todo
        private readonly bool _isProcessing;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcRequests"> </param>
        /// <param name="isProcessing"></param>
        protected AbstractMvcModelReport(ISet<IMvcRequest> mvcRequests, bool isProcessing)
        {
            _mvcRequests = mvcRequests;
            _isProcessing = isProcessing;
        }

        /// <inheritdoc/>
        ISet<IMvcRequest> IMvcModelReport.GetMvcRequests()
        {
            return new HashSet<IMvcRequest>(_mvcRequests);
        }

        /// <inheritdoc/>
        bool IMvcModelReport.IsProcessing()
        {
            return _isProcessing;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("_isProcessing={0}, _mvcRequests={1}", _isProcessing, _mvcRequests);
        }
    }
}