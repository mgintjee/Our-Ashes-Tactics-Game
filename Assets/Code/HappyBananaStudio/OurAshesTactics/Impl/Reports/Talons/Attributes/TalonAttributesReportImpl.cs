/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using System;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Attributes
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonAttributesReportImpl
        : ITalonAttributesReport
    {
        // Todo
        private readonly IDestructibleReport destructibleReport;

        // Todo
        private readonly IFireableReport fireableReport;

        // Todo
        private readonly IMovableReport movableReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="destructibleReport">
        /// </param>
        /// <param name="fireableReport">
        /// </param>
        /// <param name="movableReport">
        /// </param>
        private TalonAttributesReportImpl(IDestructibleReport destructibleReport, IFireableReport fireableReport, IMovableReport movableReport)
        {
            this.destructibleReport = destructibleReport;
            this.fireableReport = fireableReport;
            this.movableReport = movableReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IDestructibleReport GetDestructibleReport()
        {
            return this.destructibleReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IFireableReport GetFireableReport()
        {
            return this.fireableReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IMovableReport GetMovableReport()
        {
            return this.movableReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetDestructibleReport() +
                "\n\t>" + this.GetFireableReport() +
                "\n\t>" + this.GetMovableReport();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private IDestructibleReport destructibleReport = null;

            // Todo
            private IFireableReport fireableReport = null;

            // Todo
            private IMovableReport movableReport = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonAttributesReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonAttributesReportImpl(this.destructibleReport,
                        this.fireableReport, this.movableReport);
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
            public Builder SetDestructableReport(IDestructibleReport destructableReport)
            {
                this.destructibleReport = destructableReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="fireableReport">
            /// </param>
            /// <returns>
            /// </returns>
            public Builder SetFireableReport(IFireableReport fireableReport)
            {
                this.fireableReport = fireableReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="movableReport">
            /// </param>
            /// <returns>
            /// </returns>
            public Builder SetMovableReport(IMovableReport movableReport)
            {
                this.movableReport = movableReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private HashSet<string> IsValid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that destructibleReport has been set
                if (this.destructibleReport == null)
                {
                    argumentExceptionSet.Add(typeof(IDestructibleReport).Name + "has not been set");
                }
                // Check that fireableReport has been set
                if (this.fireableReport == null)
                {
                    argumentExceptionSet.Add(typeof(IFireableReport).Name + "has not been set");
                }
                // Check that movableReport has been set
                if (this.movableReport == null)
                {
                    argumentExceptionSet.Add(typeof(IMovableReport).Name + "has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}