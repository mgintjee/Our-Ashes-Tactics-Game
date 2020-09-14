/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports
{
    /// <summary>
    /// Report to display all of the information for a specific Talon
    /// </summary>
    public class TalonInformationReport
    {
        #region Private Fields

        // Todo
        private readonly TalonAttributesReport talonAttributesReport;

        // Todo
        private readonly TalonIdentificationReport talonIdentificationReport;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="talonAttributesReport">    The TalonAttributesReport to set</param>
        /// <param name="talonIdentificationReport">The TalonIdentificationReport to set</param>
        private TalonInformationReport(TalonAttributesReport talonAttributesReport,
            TalonIdentificationReport talonIdentificationReport)
        {
            this.talonAttributesReport = talonAttributesReport;
            this.talonIdentificationReport = talonIdentificationReport;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonAttributesReport GetTalonAttributesReport()
        {
            return this.talonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonIdentificationReport GetTalonIdentificationReport()
        {
            return this.talonIdentificationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetType() + ":" +
                "\n\t>" + this.GetTalonIdentificationReport() +
                "\n\t>" + this.GetTalonAttributesReport();
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            #region Private Fields

            // Todo
            private TalonAttributesReport talonAttributesReport = null;

            // Todo
            private TalonIdentificationReport talonIdentificationReport = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Build the TalonInformationReport with the set parameters
            /// </summary>
            /// <returns>The TalonInformationReport</returns>
            public TalonInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonInformationReport(this.talonAttributesReport, this.talonIdentificationReport);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the TalonAttributesReport
            /// </summary>
            /// <param name="talonAttributesReport">The TalonAttributesReport to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetTalonAttributesReport(TalonAttributesReport talonAttributesReport)
            {
                this.talonAttributesReport = talonAttributesReport;
                return this;
            }

            /// <summary>
            /// Set the value of the TalonIdentificationReport
            /// </summary>
            /// <param name="talonIdentificationReport">The TalonIdentificationReport to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetTalonIdentifcationReport(TalonIdentificationReport talonIdentificationReport)
            {
                this.talonIdentificationReport = talonIdentificationReport;
                return this;
            }

            #endregion Public Methods

            #region Private Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private HashSet<string> IsValid()
            {
                // Default an empty Set: String
                HashSet<string> argumentExceptionSet = new HashSet<string>();
                // Check that talonAttributesReport has been set
                if (this.talonAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonAttributesReport) + " has not been set");
                }
                // Check that talonIdentificationReport has been set
                if (this.talonIdentificationReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonIdentificationReport) + " has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}