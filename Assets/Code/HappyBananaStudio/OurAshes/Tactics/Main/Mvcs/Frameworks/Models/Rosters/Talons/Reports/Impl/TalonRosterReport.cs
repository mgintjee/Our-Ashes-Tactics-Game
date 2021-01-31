namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonRosterReport
        : ITalonRosterReport
    {
        // Todo
        private readonly ISet<TalonCallSign> activeTalonCallSignSet;

        // Todo
        private readonly IDictionary<TalonCallSign, ITalonReport> talonCallSignReportDictionary;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="activeTalonCallSignSet"></param>
        /// <param name="talonCallSignReportDictionary"></param>
        public TalonRosterReport(ISet<TalonCallSign> activeTalonCallSignSet,
            IDictionary<TalonCallSign, ITalonReport> talonCallSignReportDictionary)
        {
            this.activeTalonCallSignSet = new HashSet<TalonCallSign>(activeTalonCallSignSet);
            this.talonCallSignReportDictionary = new Dictionary<TalonCallSign, ITalonReport>(talonCallSignReportDictionary);
        }

        /// <inheritdoc/>
        ISet<TalonCallSign> ITalonRosterReport.GetActiveTalonCallSignSet()
        {
            return new HashSet<TalonCallSign>(this.activeTalonCallSignSet);
        }

        /// <inheritdoc/>
        IDictionary<TalonCallSign, ITalonReport> ITalonRosterReport.GetTalonCallSignReportDictionary()
        {
            return new Dictionary<TalonCallSign, ITalonReport>(this.talonCallSignReportDictionary);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Active {1}=[{2}], " +
                "\n\t>[" +
                "\n\t>{3}]",
                this.GetType().Name, typeof(TalonCallSign).Name,
                string.Join(", ", this.activeTalonCallSignSet),
                string.Join("\n\t>", this.talonCallSignReportDictionary.Values));
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
            public ITalonRosterReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new TalonRosterReport(this.activeTalonCallSignSet, this.talonCallSignReportDictionary);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
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
            public Builder SetTalonCallSignReportDictionary(
                IDictionary<TalonCallSign, ITalonReport> talonCallSignReportDictionary)
            {
                if (talonCallSignReportDictionary != null)
                {
                    this.talonCallSignReportDictionary = new Dictionary<TalonCallSign, ITalonReport>(
                        talonCallSignReportDictionary);
                }
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
                    argumentExceptionSet.Add("activeTalonCallSignSet cannot be null.");
                }
                // Check that talonCallSignReportDictionary has been set
                if (this.talonCallSignReportDictionary == null)
                {
                    argumentExceptionSet.Add("talonCallSignReportDictionary cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}