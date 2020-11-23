namespace HappyBananaStudio.OurAshes.Tactics.Impl.Talons.Reports.Attributes
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonAttributesReportImpl
        : ITalonAttributesReport
    {
        // Todo
        private readonly IDestructibleAttributesReport destructibleAttributesReport;

        // Todo
        private readonly IMountableAttributesReport mountableAttributesReport;

        // Todo
        private readonly IMovableAttributesReport movableAttributesReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructibleReport">
        /// </param>
        /// <param name="fireableReport">
        /// </param>
        /// <param name="movableReport">
        /// </param>
        private TalonAttributesReportImpl(IDestructibleAttributesReport destructibleReport,
            IMountableAttributesReport mountableAttributesReport, IMovableAttributesReport movableReport)
        {
            this.destructibleAttributesReport = destructibleReport;
            this.mountableAttributesReport = mountableAttributesReport;
            this.movableAttributesReport = movableReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.destructibleAttributesReport +
                "\n\t>" + this.mountableAttributesReport +
                "\n\t>" + this.movableAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IDestructibleAttributesReport ITalonAttributesReport.GetDestructibleAttributesReport()
        {
            return this.destructibleAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMountableAttributesReport ITalonAttributesReport.GetMountableAttributesReport()
        {
            return this.mountableAttributesReport;
        }

        IMovableAttributesReport ITalonAttributesReport.GetMovableAttributesReport()
        {
            return this.movableAttributesReport;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IDestructibleAttributesReport destructibleAttributesReport = null;

            // Todo
            private IMountableAttributesReport mountableAttributesReport = null;

            // Todo
            private IMovableAttributesReport movableAttributesReport = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonAttributesReport Build()
            {
                ISet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonAttributesReportImpl(this.destructibleAttributesReport,
                        this.mountableAttributesReport, this.movableAttributesReport);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType().Name + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="destructableReport">
            /// </param>
            /// <returns>
            /// </returns>
            public Builder SetDestructableReport(IDestructibleAttributesReport destructableReport)
            {
                this.destructibleAttributesReport = destructableReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mountableAttributesReport">
            /// </param>
            /// <returns>
            /// </returns>
            public Builder SetMountableReport(IMountableAttributesReport mountableAttributesReport)
            {
                this.mountableAttributesReport = mountableAttributesReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movableReport">
            /// </param>
            /// <returns>
            /// </returns>
            public Builder SetMovableReport(IMovableAttributesReport movableReport)
            {
                this.movableAttributesReport = movableReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsValid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that destructibleAttributesReport has been set
                if (this.destructibleAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(IDestructibleAttributesReport).Name + "has not been set");
                }
                // Check that mountableAttributesReport has been set
                if (this.mountableAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(IMountableAttributesReport).Name + "has not been set");
                }
                // Check that movableAttributesReport has been set
                if (this.movableAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(IMovableAttributesReport).Name + "has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}