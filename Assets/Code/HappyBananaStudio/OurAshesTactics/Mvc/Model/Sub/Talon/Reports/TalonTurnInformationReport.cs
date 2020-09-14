/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports
{
    /// <summary>
    /// Report to display all of the information for a specific Talon
    /// </summary>
    public class TalonTurnInformationReport
    {
        #region Private Fields

        // Todo
        private readonly HashSet<TalonActionOrderReport> possibleTalonActionOrderReportSet = null;

        // Todo
        private readonly TalonInformationReport talonInformationReport = null;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Private constructor to force using the Builder
        /// </summary>
        /// <param name="talonInformationReport">           The TalonInformationReport to set</param>
        /// <param name="possibleTalonActionOrderReportSet">
        /// The Set: TalonActionOrderReport to set
        /// </param>
        private TalonTurnInformationReport(HashSet<TalonActionOrderReport> possibleTalonActionOrderReportSet,
            TalonInformationReport talonInformationReport)
        {
            this.possibleTalonActionOrderReportSet = possibleTalonActionOrderReportSet;
            this.talonInformationReport = talonInformationReport;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public HashSet<TalonActionOrderReport> GetPossibleTalonActionOrderReportSet()
        {
            return this.possibleTalonActionOrderReportSet;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonInformationReport GetTalonInformationReport()
        {
            return this.talonInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int fireActionCount = 0;
            int moveActionCount = 0;
            int waitActionCount = 0;
            foreach (TalonActionOrderReport talonActionOrderReport in this.GetPossibleTalonActionOrderReportSet())
            {
                switch (talonActionOrderReport.GetTalonActionType())
                {
                    case TalonActionTypeEnum.Fire:
                        fireActionCount++;
                        break;

                    case TalonActionTypeEnum.Move:
                        moveActionCount++;
                        break;

                    case TalonActionTypeEnum.Wait:
                        waitActionCount++;
                        break;
                }
            }
            return this.GetType() + ":" +
                "\n\t>" + this.GetTalonInformationReport() +
                "\n\t>possibleTalonActionOrderReportSet=[" +
                TalonActionTypeEnum.Fire + "= " + fireActionCount +
                ", " + TalonActionTypeEnum.Move + "= " + moveActionCount +
                ", " + TalonActionTypeEnum.Wait + "= " + waitActionCount + "]";
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
            private HashSet<TalonActionOrderReport> possibleTalonActionOrderReportSet = null;

            // Todo
            private TalonInformationReport talonInformationReport = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Build the TalonInformationReport with the set parameters
            /// </summary>
            /// <returns>The TalonInformationReport</returns>
            public TalonTurnInformationReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonTurnInformationReport(this.possibleTalonActionOrderReportSet,
                        this.talonInformationReport);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the Set: TalonActionOrderReport
            /// </summary>
            /// <param name="possibleTalonActionOrderReportSet">
            /// The Set: TalonActionOrderReport to set
            /// </param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetPossibleTalonActionOrderReportSet(HashSet<TalonActionOrderReport> possibleTalonActionOrderReportSet)
            {
                this.possibleTalonActionOrderReportSet = possibleTalonActionOrderReportSet;
                return this;
            }

            /// <summary>
            /// Set the value of the TalonInformationReport
            /// </summary>
            /// <param name="talonInformationReport">The TalonInformationReport to set</param>
            /// <returns>The Builder to continue building with</returns>
            public Builder SetTalonInformationReport(TalonInformationReport talonInformationReport)
            {
                this.talonInformationReport = talonInformationReport;
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
                // Check that talonInformationReport has been set
                if (this.talonInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonInformationReport) + " has not been set");
                }
                // Check that possibleTalonActionOrderReportSet has been set
                if (this.possibleTalonActionOrderReportSet == null)
                {
                    argumentExceptionSet.Add("possibleTalonActionOrderReportSet has not been set");
                }
                else
                {
                    // Check that possibleTalonActionOrderReportSet is valid
                    if (this.possibleTalonActionOrderReportSet.Count == 0)
                    {
                        argumentExceptionSet.Add("possibleTalonActionOrderReportSet has is invalid");
                    }
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}