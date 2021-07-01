using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Engagements.Types.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Phalanxes.CallSigns.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Phalanxes.Reports.Interfaces;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Commons.Engagements.Reports.Implementations
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct EngagementReport
        : IEngagementReport
    {
        // Todo
        private readonly EngagementType _formationType;

        // Todo
        private readonly ISet<PhalanxCallSign> _activePhalanxCallSigns;

        // Todo
        private readonly ISet<PhalanxCallSign> _allPhalanxCallSigns;

        // Todo
        private readonly ISet<IPhalanxReport> _phalanxReports;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="formationType">         </param>
        /// <param name="activePhalanxCallSigns"></param>
        /// <param name="allPhalanxCallSigns">   </param>
        /// <param name="phalanxReports">        </param>
        private EngagementReport(EngagementType formationType, ISet<PhalanxCallSign> activePhalanxCallSigns,
            ISet<PhalanxCallSign> allPhalanxCallSigns, ISet<IPhalanxReport> phalanxReports)
        {
            _formationType = formationType;
            _activePhalanxCallSigns = activePhalanxCallSigns;
            _allPhalanxCallSigns = allPhalanxCallSigns;
            _phalanxReports = phalanxReports;
        }

        /// <inheritdoc/>
        ISet<PhalanxCallSign> IEngagementReport.GetActivePhalanxCallSigns()
        {
            return new HashSet<PhalanxCallSign>(_activePhalanxCallSigns);
        }

        /// <inheritdoc/>
        ISet<PhalanxCallSign> IEngagementReport.GetAllPhalanxCallSigns()
        {
            return new HashSet<PhalanxCallSign>(_allPhalanxCallSigns);
        }

        /// <inheritdoc/>
        EngagementType IEngagementReport.GetEngagementType()
        {
            return _formationType;
        }

        /// <inheritdoc/>
        Optional<IPhalanxReport> IEngagementReport.GetPhalanxReport(PhalanxCallSign callSign)
        {
            foreach (IPhalanxReport phalanxReport in _phalanxReports)
            {
                if (phalanxReport.GetPhalanxCallSign() == callSign)
                {
                    return Optional<IPhalanxReport>.Of(phalanxReport);
                }
            }
            return Optional<IPhalanxReport>.Empty();
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private EngagementType _formationType = EngagementType.None;

            // Todo
            private ISet<PhalanxCallSign> _activePhalanxCallSigns = null;

            // Todo
            private ISet<PhalanxCallSign> _allPhalanxCallSigns = null;

            // Todo
            private ISet<IPhalanxReport> _phalanxReports = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IEngagementReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new construction
                    return new EngagementReport(_formationType, _activePhalanxCallSigns,
                        _allPhalanxCallSigns, _phalanxReports);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="formationType"></param>
            /// <returns></returns>
            public Builder SetEngagementType(EngagementType formationType)
            {
                _formationType = formationType;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="activePhalanxCallSigns"></param>
            /// <returns></returns>
            public Builder SetActivePhalanxCallSigns(ISet<PhalanxCallSign> activePhalanxCallSigns)
            {
                if (activePhalanxCallSigns != null)
                {
                    _activePhalanxCallSigns = new HashSet<PhalanxCallSign>(activePhalanxCallSigns);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="allPhalanxCallSigns"></param>
            /// <returns></returns>
            public Builder SetAllPhalanxCallSigns(ISet<PhalanxCallSign> allPhalanxCallSigns)
            {
                if (allPhalanxCallSigns != null)
                {
                    _allPhalanxCallSigns = new HashSet<PhalanxCallSign>(allPhalanxCallSigns);
                }
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phalanxReports"></param>
            /// <returns></returns>
            public Builder SetPhalanxReports(ISet<IPhalanxReport> phalanxReports)
            {
                if (phalanxReports != null)
                {
                    _phalanxReports = new HashSet<IPhalanxReport>(phalanxReports);
                }
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
                // Check that _formationType has been set
                if (_formationType == EngagementType.None)
                {
                    argumentExceptionSet.Add(typeof(EngagementType).Name + " cannot be none.");
                }
                // Check that _activePhalanxCallSigns has been set
                if (_activePhalanxCallSigns == null)
                {
                    argumentExceptionSet.Add("Active Set: " + typeof(PhalanxCallSign).Name + " cannot be null.");
                }
                // Check that _allPhalanxCallSigns has been set
                if (_allPhalanxCallSigns == null)
                {
                    argumentExceptionSet.Add("All Set: " + typeof(PhalanxCallSign).Name + " cannot be null.");
                }
                // Check that _phalanxReports has been set
                if (_phalanxReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IPhalanxReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}