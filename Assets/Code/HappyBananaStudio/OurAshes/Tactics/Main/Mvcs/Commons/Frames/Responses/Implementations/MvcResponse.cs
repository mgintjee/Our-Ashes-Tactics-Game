using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Implementations
{
    /// <summary>
    /// Mvc Response Implementation
    /// </summary>
    public class MvcResponse : AbstractReport, IMvcResponse
    {
        // Todo
        private readonly IMvcRequest _mvcRequest;

        // Todo
        private readonly IMvcFrameReport _mvcFrameReport;

        // Todo
        private readonly ISet<IMvcRequest> _mvcRequests;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcRequest">    </param>
        /// <param name="mvcRequests">   </param>
        /// <param name="mvcFrameReport"></param>
        private MvcResponse(IMvcRequest mvcRequest, ISet<IMvcRequest> mvcRequests, IMvcFrameReport mvcFrameReport)
        {
            _mvcRequest = mvcRequest;
            _mvcFrameReport = mvcFrameReport;
            _mvcRequests = mvcRequests;
        }

        /// <inheritdoc/>
        IMvcRequest IMvcResponse.GetMvcRequest()
        {
            return _mvcRequest;
        }

        /// <inheritdoc/>
        ISet<IMvcRequest> IMvcResponse.GetMvcRequests()
        {
            return new HashSet<IMvcRequest>(_mvcRequests);
        }

        /// <inheritdoc/>
        IMvcFrameReport IMvcResponse.GetMvcFrameReport()
        {
            return _mvcFrameReport;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}, {2}",
                _mvcRequest, _mvcRequests, _mvcFrameReport);
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IMvcResponse>
            {
                IBuilder SetMvcRequest(IMvcRequest mvcRequest);

                IBuilder SetMvcRequests(ICollection<IMvcRequest> mvcRequests);

                IBuilder SetMvcFrameReport(IMvcFrameReport mvcFrameReport);
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
            private class InternalBuilder : AbstractBuilder<IMvcResponse>, IBuilder
            {
                // Todo
                private IMvcRequest _mvcRequest;

                // Todo
                private IMvcFrameReport _mvcFrameReport;

                // Todo
                private ISet<IMvcRequest> _mvcRequests;

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcRequest(IMvcRequest mvcRequest)
                {
                    _mvcRequest = mvcRequest;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcRequests(ICollection<IMvcRequest> mvcRequests)
                {
                    _mvcRequests = new HashSet<IMvcRequest>(mvcRequests);
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcFrameReport(IMvcFrameReport mvcFrameReport)
                {
                    _mvcFrameReport = mvcFrameReport;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcResponse BuildObj()
                {
                    // Instantiate a new attributes
                    return new MvcResponse(_mvcRequest, _mvcRequests, _mvcFrameReport);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _mvcRequest);
                    this.Validate(invalidReasons, _mvcRequests);
                    this.Validate(invalidReasons, _mvcFrameReport);
                }
            }
        }
    }
}