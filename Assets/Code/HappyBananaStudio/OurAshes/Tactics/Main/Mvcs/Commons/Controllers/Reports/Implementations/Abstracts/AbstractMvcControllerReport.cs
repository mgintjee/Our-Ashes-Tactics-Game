using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Reports.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc Controller Report Implementation
    /// </summary>
    public abstract class AbstractMvcControllerReport
        : AbstractReport, IMvcControllerReport
    {
        // Todo
        private readonly IMvcRequest _confirmedMvcRequest;

        // Todo
        private readonly IMvcRequest _selectedMvcRequest;

        // Todo
        private readonly bool _isProcessing;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="confirmedMvcRequest"></param>
        /// <param name="selectedMvcRequest"> </param>
        /// <param name="isProcessing">       </param>
        protected AbstractMvcControllerReport(IMvcRequest confirmedMvcRequest, IMvcRequest selectedMvcRequest, bool isProcessing)
        {
            _confirmedMvcRequest = confirmedMvcRequest;
            _selectedMvcRequest = selectedMvcRequest;
            _isProcessing = isProcessing;
        }

        /// <inheritdoc/>
        Optional<IMvcRequest> IMvcControllerReport.GetConfirmedRequest()
        {
            return Optional<IMvcRequest>.Of(_confirmedMvcRequest);
        }

        /// <inheritdoc/>
        Optional<IMvcRequest> IMvcControllerReport.GetSelectedRequest()
        {
            return Optional<IMvcRequest>.Of(_selectedMvcRequest);
        }

        /// <inheritdoc/>
        bool IMvcControllerReport.IsProcessing()
        {
            return _isProcessing;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("_isProcessing={0}, _selectedMvcRequest={1}, _confirmedMvcRequest={2}", _isProcessing, _selectedMvcRequest, _confirmedMvcRequest);
        }
    }
}