/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Talons.Turn
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonTurnInformationReportImpl
        : ITalonTurnInformationReport
    {
        // Todo
        private readonly HashSet<ITalonActionOrderReport> talonActionOrderReportSet;

        // Todo
        private readonly ITalonInformationReport talonInformationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReportSet">
        /// </param>
        /// <param name="talonInformationReport">
        /// </param>
        private TalonTurnInformationReportImpl(HashSet<ITalonActionOrderReport> talonActionOrderReportSet,
            ITalonInformationReport talonInformationReport)
        {
            this.talonActionOrderReportSet = talonActionOrderReportSet;
            this.talonInformationReport = talonInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public HashSet<ITalonActionOrderReport> GetPossibleTalonActionOrderReportSet()
        {
            return new HashSet<ITalonActionOrderReport>(this.talonActionOrderReportSet);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonInformationReport GetTalonInformationReport()
        {
            return this.talonInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetTalonInformationReport() +
                "\n\t>Set: " + typeof(ITalonActionOrderReport).Name + "=[" +
                string.Join("\n\t\t>", this.GetPossibleTalonActionOrderReportSet()) +
                "\n]";
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private HashSet<ITalonActionOrderReport> talonActionOrderReportSet = null;

            // Todo
            private ITalonInformationReport talonInformationReport = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonTurnInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonTurnInformationReportImpl(this.talonActionOrderReportSet, this.talonInformationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Set: ITalonActionOrderReport
            /// </summary>
            /// <param name="talonActionOrderReportSet">
            /// The Set: ITalonActionOrderReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonActionOrderReportSet(HashSet<ITalonActionOrderReport> talonActionOrderReportSet)
            {
                this.talonActionOrderReportSet = talonActionOrderReportSet;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonInformationReport
            /// </summary>
            /// <param name="talonInformationReport">
            /// The ITalonInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonInformationReport(ITalonInformationReport talonInformationReport)
            {
                this.talonInformationReport = talonInformationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private HashSet<string> IsInvalid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that talonActionOrderReportSet has been set
                if (this.talonActionOrderReportSet == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITalonActionOrderReport).Name + " has not been set");
                }
                // Check that talonInformationReport has been set
                if (this.talonInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}