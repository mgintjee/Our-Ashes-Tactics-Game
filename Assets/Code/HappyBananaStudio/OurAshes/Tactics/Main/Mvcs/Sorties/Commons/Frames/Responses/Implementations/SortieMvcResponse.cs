using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Responses.IDs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Frames.Responses.Implementations
{
    /// <summary>
    /// Sortie Model Response Implementation
    /// </summary>
    public class SortieResponse
        : AbstractReport, ISortieResponse
    {
        // Todo
        private readonly IMvcSortieModelReport _mvcSortieModelReport;

        // Todo
        private readonly IMvcRequest _mvcControllerRequest;

        // Todo
        private readonly ISet<IMvcRequest> _mvcControllerRequests;

        // Todo
        private readonly ISortieResponseID _sortieResponseID;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerRequest"> </param>
        /// <param name="mvcControllerRequests"></param>
        /// <param name="sortieResponseID">     </param>
        /// <param name="mvcSortieModelReport"> </param>
        private SortieResponse(IMvcRequest mvcControllerRequest, ISet<IMvcRequest> mvcControllerRequests,
            ISortieResponseID sortieResponseID, IMvcSortieModelReport mvcSortieModelReport)
        {
            _mvcControllerRequest = mvcControllerRequest;
            _mvcControllerRequests = mvcControllerRequests;
            _mvcSortieModelReport = mvcSortieModelReport;
            _sortieResponseID = sortieResponseID;
        }

        /// <inheritdoc/>
        IMvcSortieModelReport ISortieResponse.GetMvcSortieModelReport()
        {
            return _mvcSortieModelReport;
        }

        ISortieResponseID ISortieResponse.GetSortieResponseID()
        {
            return _sortieResponseID;
        }

        /// <inheritdoc/>
        IMvcRequest IMvcResponse.GetMvcRequest()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}, {1}, {2}",
                _sortieResponseID, _mvcSortieModelReport, _mvcControllerRequest);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IMvcSortieModelReport _mvcSortieModelReport = null;

            // Todo
            private IMvcRequest _mvcControllerRequest = null;

            // Todo
            private ISet<IMvcRequest> _mvcControllerRequests = null;

            // Todo
            private ISortieResponseID _sortieResponseID = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ISortieResponse Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new response
                    return new SortieResponse(_mvcControllerRequest, _mvcControllerRequests,
                        _sortieResponseID, _mvcSortieModelReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcSortieModelReport"></param>
            /// <returns></returns>
            public Builder SetMvcSortieModelReport(IMvcSortieModelReport mvcSortieModelReport)
            {
                _mvcSortieModelReport = mvcSortieModelReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcControllerRequest"></param>
            /// <returns></returns>
            public Builder SetMvcControllerRequest(IMvcRequest mvcControllerRequest)
            {
                _mvcControllerRequest = mvcControllerRequest;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcControllerRequests"></param>
            /// <returns></returns>
            public Builder SetMvcControllerRequests(ISet<IMvcRequest> mvcControllerRequests)
            {
                if (mvcControllerRequests != null)
                {
                    _mvcControllerRequests = new HashSet<IMvcRequest>(mvcControllerRequests);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="sortieResponseID"></param>
            /// <returns></returns>
            public Builder SetSortieResponseID(ISortieResponseID sortieResponseID)
            {
                _sortieResponseID = sortieResponseID;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Todo: Add the non-null checks
                return argumentExceptionSet;
            }
        }
    }
}