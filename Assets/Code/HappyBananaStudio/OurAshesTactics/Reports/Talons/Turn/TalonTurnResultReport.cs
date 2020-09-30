/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Talons.Turn
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonTurnResultReport
        : ITalonTurnResultReport
    {
        // Todo
        private readonly ITalonActionResultReport talonActionResultReport;

        // Todo
        private readonly ITalonTurnInformationReport talonTurnInformationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionResultReport">
        /// </param>
        /// <param name="talonTurnInformationReport">
        /// </param>
        private TalonTurnResultReport(ITalonActionResultReport talonActionResultReport,
            ITalonTurnInformationReport talonTurnInformationReport)
        {
            this.talonActionResultReport = talonActionResultReport;
            this.talonTurnInformationReport = talonTurnInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonActionResultReport GetTalonActionResultReport()
        {
            return this.talonActionResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonTurnInformationReport GetTalonTurnInformationReport()
        {
            return this.talonTurnInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetTalonActionResultReport() +
                "\n\t>" + this.GetTalonTurnInformationReport();
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ITalonActionResultReport talonActionResultReport = null;

            // Todo
            private ITalonTurnInformationReport talonTurnInformationReport = null;

            /// <summary>
            /// Build the report with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public ITalonTurnResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonTurnResultReport(this.talonActionResultReport, this.talonTurnInformationReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the ITalonActionResultReport
            /// </summary>
            /// <param name="talonActionResultReport">
            /// The ITalonActionResultReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonActionResultReport(ITalonActionResultReport talonActionResultReport)
            {
                this.talonActionResultReport = talonActionResultReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonTurnInformationReport
            /// </summary>
            /// <param name="talonTurnInformationReport">
            /// The ITalonTurnInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonTurnInformationReport(ITalonTurnInformationReport talonTurnInformationReport)
            {
                this.talonTurnInformationReport = talonTurnInformationReport;
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
                // Check that talonActionResultReport has been set
                if (this.talonActionResultReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonActionResultReport).Name + " has not been set");
                }
                // Check that talonTurnInformationReport has been set
                if (this.talonTurnInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonTurnInformationReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}