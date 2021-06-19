using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.IDs.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Models.Responses.Implementations
{
    /// <summary>
    /// Sortie Model Response Implementation
    /// </summary>
    public class SortieModelResponse
        : ISortieModelResponse
    {
        // Todo
        private readonly IMvcSortieModelReport _mvcSortieModelReport;

        // Todo
        private readonly IMvcControllerRequest _mvcControllerRequest;

        // Todo
        private readonly ISet<IMvcControllerRequest> _mvcControllerRequests;

        // Todo
        private readonly ISortieResponseID _sortieResponseID;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControllerRequest"> </param>
        /// <param name="mvcControllerRequests"></param>
        /// <param name="sortieResponseID">     </param>
        /// <param name="mvcSortieModelReport"> </param>
        private SortieModelResponse(IMvcControllerRequest mvcControllerRequest, ISet<IMvcControllerRequest> mvcControllerRequests,
            ISortieResponseID sortieResponseID, IMvcSortieModelReport mvcSortieModelReport)
        {
            _mvcControllerRequest = mvcControllerRequest;
            _mvcControllerRequests = mvcControllerRequests;
            _mvcSortieModelReport = mvcSortieModelReport;
            _sortieResponseID = sortieResponseID;
        }

        /// <inheritdoc/>
        ISet<IMvcControllerRequest> IMvcModelResponse.GetControllerRequests()
        {
            return new HashSet<IMvcControllerRequest>(_mvcControllerRequests);
        }

        /// <inheritdoc/>
        IMvcSortieModelReport ISortieModelResponse.GetMvcSortieModelReport()
        {
            return _mvcSortieModelReport;
        }

        /// <inheritdoc/>
        Optional<IMvcControllerRequest> IMvcModelResponse.GetMvcControllerRequest()
        {
            return Optional<IMvcControllerRequest>.Of(_mvcControllerRequest);
        }

        /// <inheritdoc/>
        ISortieResponseID ISortieModelResponse.SortieResponseID()
        {
            return _sortieResponseID;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IMvcSortieModelReport _mvcSortieModelReport = null;

            // Todo
            private IMvcControllerRequest _mvcControllerRequest = null;

            // Todo
            private ISet<IMvcControllerRequest> _mvcControllerRequests = null;

            // Todo
            private ISortieResponseID _sortieResponseID = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ISortieModelResponse Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new response
                    return new SortieModelResponse(_mvcControllerRequest, _mvcControllerRequests,
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
            public Builder SetMvcControllerRequest(IMvcControllerRequest mvcControllerRequest)
            {
                _mvcControllerRequest = mvcControllerRequest;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mvcControllerRequests"></param>
            /// <returns></returns>
            public Builder SetMvcControllerRequests(ISet<IMvcControllerRequest> mvcControllerRequests)
            {
                if (mvcControllerRequests != null)
                {
                    _mvcControllerRequests = new HashSet<IMvcControllerRequest>(mvcControllerRequests);
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