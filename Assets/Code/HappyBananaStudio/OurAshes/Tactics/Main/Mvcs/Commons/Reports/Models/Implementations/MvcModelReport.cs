using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Reports.Models.Implementations
{
    /// <summary>
    /// Mvc Model Report Implementation
    /// </summary>
    public class MvcModelReport : AbstractReport, IMvcModelReport
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
        private MvcModelReport(ISet<IMvcRequest> mvcRequests, bool isProcessing)
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
            string mvcRequestString = (_mvcRequests.Count != 0) ? "" : "Empty";
            foreach (IMvcRequest mvcRequest in _mvcRequests)
            {
                mvcRequestString += mvcRequest.ToString() + ", ";
            }
            return string.Format("_isProcessing={0}, _mvcRequests({1})=[{2}]", _isProcessing, _mvcRequests.Count, mvcRequestString);
        }

        /// <summary>
        /// Builder class for this object
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Builder Interface for this object
            /// </summary>
            public interface IBuilder : IBuilder<IMvcModelReport>
            {
                public IBuilder SetMvcRequests(ISet<IMvcRequest> mvcRequests);

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
            private class InternalBuilder : AbstractBuilder<IMvcModelReport>, IBuilder
            {
                private ISet<IMvcRequest> _mvcRequests = null;
                private bool _isProcessing;

                /// <inheritdoc/>
                IBuilder IBuilder.SetIsProcessing(bool isProcessing)
                {
                    _isProcessing = isProcessing;
                    return this;
                }

                /// <inheritdoc/>
                IBuilder IBuilder.SetMvcRequests(ISet<IMvcRequest> mvcRequests)
                {
                    if (mvcRequests != null)
                    {
                        _mvcRequests = new HashSet<IMvcRequest>(mvcRequests);
                    }
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcModelReport BuildObj()
                {
                    return new MvcModelReport(_mvcRequests, _isProcessing);
                }

                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, _mvcRequests);
                }
            }
        }
    }
}