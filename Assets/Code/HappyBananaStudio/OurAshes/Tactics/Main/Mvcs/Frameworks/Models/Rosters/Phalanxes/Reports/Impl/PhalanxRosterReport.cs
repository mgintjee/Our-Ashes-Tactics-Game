namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct PhalanxRosterReport
        : IPhalanxRosterReport
    {
        // Todo
        private readonly ISet<IPhalanxReport> phalanxReports;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phalanxReports"></param>
        private PhalanxRosterReport(ISet<IPhalanxReport> phalanxReports)
        {
            this.phalanxReports = phalanxReports;
        }

        /// <inheritdoc/>
        ISet<IPhalanxReport> IPhalanxRosterReport.GetPhalanxReports()
        {
            return new HashSet<IPhalanxReport>(this.phalanxReports);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:" +
                "\n\t>phalanxReports=[{1}]",
                this.GetType().Name, string.Join(", ", this.phalanxReports));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ISet<IPhalanxReport> phalanxReports = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IPhalanxRosterReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new PhalanxRosterReport(this.phalanxReports);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="phalanxReports"></param>
            /// <returns></returns>
            public Builder SetPhalanxReports(ISet<IPhalanxReport> phalanxReports)
            {
                if (phalanxReports != null)
                {
                    this.phalanxReports = phalanxReports;
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
                // Check that phalanxReports has been set
                if (this.phalanxReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IPhalanxReport).Name + " can not be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}