using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Controllers.Implementations
{
    /// <summary>
    /// Mvc Controller Report Implementation
    /// </summary>
    public class MvcControllerReport : AbstractReport, IMvcControllerReport
    {
        // Todo
        private readonly IMvcRequest _confirmedMvcRequest;

        // Todo
        private readonly IMvcRequest _selectedMvcRequest;

        // Todo
        private readonly bool _isProcessing;

        // Todo
        private readonly bool _hasRequsts;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="confirmedMvcRequest"></param>
        /// <param name="selectedMvcRequest"> </param>
        /// <param name="isProcessing">       </param>
        /// <param name="hasRequests">        </param>
        private MvcControllerReport(IMvcRequest confirmedMvcRequest,
            IMvcRequest selectedMvcRequest, bool isProcessing, bool hasRequests)
        {
            _confirmedMvcRequest = confirmedMvcRequest;
            _selectedMvcRequest = selectedMvcRequest;
            _isProcessing = isProcessing;
            _hasRequsts = hasRequests;
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
        bool IMvcControllerReport.HasRequests()
        {
            return _hasRequsts;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("_isProcessing={0}, _hasRequests={1}, _selectedMvcRequest={2}, _confirmedMvcRequest={3}",
                _isProcessing, _hasRequsts, (_selectedMvcRequest != null) ? _selectedMvcRequest.ToString() : "null",
                (_confirmedMvcRequest != null) ? _confirmedMvcRequest.ToString() : "null");
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IMvcControllerReport>
            {
                public IBuilder SetConfirmedRequest(IMvcRequest mvcRequest);

                public IBuilder SetSelectedRequest(IMvcRequest mvcRequest);

                public IBuilder SetHasRequests(bool hasRequests);

                public IBuilder SetIsProcessing(bool isProcessing);
            }

            /// <summary>
            /// Get the Builder for this object
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Builder Implementation for this object
            /// </summary>
            private class InternalBuilder : AbstractBuilder<IMvcControllerReport>, IBuilder
            {
                private IMvcRequest _confirmedMvcRequest = null;
                private IMvcRequest _selectedMvcRequest = null;
                private bool _hasRequests;
                private bool _isProcessing;

                IBuilder IBuilder.SetConfirmedRequest(IMvcRequest mvcRequest)
                {
                    _confirmedMvcRequest = mvcRequest;
                    return this;
                }

                IBuilder IBuilder.SetHasRequests(bool hasRequests)
                {
                    _hasRequests = hasRequests;
                    return this;
                }

                IBuilder IBuilder.SetIsProcessing(bool isProcessing)
                {
                    _isProcessing = isProcessing;
                    return this;
                }

                IBuilder IBuilder.SetSelectedRequest(IMvcRequest mvcRequest)
                {
                    _selectedMvcRequest = mvcRequest;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcControllerReport BuildObj()
                {
                    return new MvcControllerReport(_confirmedMvcRequest, _selectedMvcRequest, _isProcessing, _hasRequests);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                }
            }
        }
    }
}