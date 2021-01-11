namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct RosterReportImpl
        : IRosterReport
    {
        // Todo
        private readonly ISet<TalonCallSign> activeTalonCallSignSet;

        // Todo
        private readonly IDictionary<TalonCallSign, ITalonReport> talonCallSignReportDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="activeTalonCallSignSet"></param>
        /// <param name="talonCallSignObjectDictionary"></param>
        public RosterReportImpl(ISet<TalonCallSign> activeTalonCallSignSet,
            IDictionary<TalonCallSign, ITalonReport> talonCallSignReportDictionary)
        {
            this.activeTalonCallSignSet = new HashSet<TalonCallSign>(activeTalonCallSignSet);
            this.talonCallSignReportDictionary = new Dictionary<TalonCallSign, ITalonReport>(talonCallSignReportDictionary);
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> IRosterReport.GetActiveTalonCallSignSet()
        {
            return new HashSet<TalonCallSign>(this.activeTalonCallSignSet);
        }

        /// <inheritdoc/>
        IDictionary<TalonCallSign, ITalonReport> IRosterReport.GetTalonCallSignReportDictionary()
        {
            return new Dictionary<TalonCallSign, ITalonReport>(this.talonCallSignReportDictionary);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<TalonCallSign> activeTalonCallSignSet = null;

            // Todo
            private IDictionary<TalonCallSign, ITalonReport> talonCallSignReportDictionary = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IRosterReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new RosterReportImpl(this.activeTalonCallSignSet, this.talonCallSignReportDictionary);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="activeTalonCallSignSet"></param>
            /// <returns></returns>
            public Builder SetActiveTalonCallSignSet(ISet<TalonCallSign> activeTalonCallSignSet)
            {
                this.activeTalonCallSignSet = new HashSet<TalonCallSign>(activeTalonCallSignSet);
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCallSignReportDictionary"></param>
            /// <returns></returns>
            public Builder SetTalonCallSignReportDictionary(IDictionary<TalonCallSign, ITalonReport> talonCallSignReportDictionary)
            {
                this.talonCallSignReportDictionary = new Dictionary<TalonCallSign, ITalonReport>(talonCallSignReportDictionary);
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that activeTalonCallSignSet has been set
                if (this.activeTalonCallSignSet == null)
                {
                    argumentExceptionSet.Add("activeTalonCallSignSet has not been set");
                }
                // Check that talonCallSignReportDictionary has been set
                if (this.talonCallSignReportDictionary == null)
                {
                    argumentExceptionSet.Add("talonCallSignReportDictionary has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}