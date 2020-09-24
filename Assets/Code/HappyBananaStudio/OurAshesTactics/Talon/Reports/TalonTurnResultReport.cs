/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Enums;
using System;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonTurnResultReport
    {
        #region Private Fields

        // Todo
        private readonly int actionCounter = int.MinValue;

        // Todo
        private readonly MapInformationReport mapInformationReport = null;

        // Todo
        private readonly int phaseCounter = int.MinValue;

        // Todo
        private readonly TalonActionResultReport talonActionResultReport = null;

        // Todo
        private readonly TalonCombatResultReport talonCombatResultReport = null;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="phaseCounter">           </param>
        /// <param name="actionCounter">          </param>
        /// <param name="talonActionResultReport"></param>
        /// <param name="talonCombatResultReport"></param>
        /// <param name="mapInformationReport">   </param>
        private TalonTurnResultReport(int phaseCounter, int actionCounter, TalonActionResultReport talonActionResultReport,
            TalonCombatResultReport talonCombatResultReport, MapInformationReport mapInformationReport)
        {
            this.phaseCounter = phaseCounter;
            this.actionCounter = actionCounter;
            this.talonActionResultReport = talonActionResultReport;
            this.talonCombatResultReport = talonCombatResultReport;
            this.mapInformationReport = mapInformationReport;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetActionCounter()
        {
            return this.actionCounter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public MapInformationReport GetMapInformationReport()
        {
            return this.mapInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public int GetPhaseCounter()
        {
            return this.phaseCounter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>

        public TalonActionResultReport GetTalonActionResultReport()
        {
            return this.talonActionResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public TalonCombatResultReport GetTalonCombatResultReport()
        {
            return this.talonCombatResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string talonCombatResultReportString = (this.GetTalonCombatResultReport() != null)
                ? "\n\t>" + this.GetTalonCombatResultReport()
                : "";
            return this.GetType() + ": " +
                "\n\t>phaseCounter=" + this.GetPhaseCounter() +
                "\n\t>actionCounter=" + this.GetActionCounter() +
                "\n\t>" + this.GetTalonActionResultReport() +
                talonCombatResultReportString +
                "\n\t>" + this.GetMapInformationReport();
        }

        #endregion Public Methods

        #region Public Classes

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            #region Private Fields

            // Todo
            private int actionCounter = int.MinValue;

            // Todo
            private MapInformationReport mapInformationReport = null;

            // Todo
            private int phaseCounter = int.MinValue;

            // Todo
            private TalonActionResultReport talonActionResultReport = null;

            // Todo
            private TalonCombatResultReport talonCombatResultReport = null;

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public TalonTurnResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsValid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new TalonTurnResultReport(this.phaseCounter, this.actionCounter, this.talonActionResultReport,
                        this.talonCombatResultReport, this.mapInformationReport);
                }
                else
                {
                    throw new ArgumentException("Unable to construct " + this.GetType() + ". Invalid Parameters." +
                        string.Join("\n\t>", invalidReasons));
                }
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="actionCounter"></param>
            /// <returns></returns>
            public Builder SetActionCounter(int actionCounter)
            {
                this.actionCounter = actionCounter;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="mapInformationReport"></param>
            /// <returns></returns>
            public Builder SetMapInformationReport(MapInformationReport mapInformationReport)
            {
                this.mapInformationReport = mapInformationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="phaseCounter"></param>
            /// <returns></returns>
            public Builder SetPhaseCounter(int phaseCounter)
            {
                this.phaseCounter = phaseCounter;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonActionResultReport"></param>
            /// <returns></returns>
            public Builder SetTalonActionResultReport(TalonActionResultReport talonActionResultReport)
            {
                this.talonActionResultReport = talonActionResultReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="talonCombatResultReport"></param>
            /// <returns></returns>
            public Builder SetTalonCombatResultReport(TalonCombatResultReport talonCombatResultReport)
            {
                this.talonCombatResultReport = talonCombatResultReport;
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
                // Check that phaseCounter has been set
                if (this.phaseCounter < 0)
                {
                    argumentExceptionSet.Add("phaseCounter=" + this.phaseCounter + " is not valid");
                }
                // Check that actionCounter has been set
                if (this.actionCounter < 0)
                {
                    argumentExceptionSet.Add("actionCounter=" + this.actionCounter + " is not valid");
                }
                // Check that talonActionResultReport has been set
                if (this.talonActionResultReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonActionResultReport) + " has not been set");
                }
                // Check that talonCombatResultReport has been set
                if (this.talonActionResultReport != null &&
                    this.talonActionResultReport.GetTalonActionOrder() != null &&
                    this.talonActionResultReport.GetTalonActionOrder().GetTalonActionType().Equals(TalonActionTypeEnum.Fire) &&
                    this.talonCombatResultReport == null)
                {
                    argumentExceptionSet.Add(typeof(TalonCombatResultReport) + " has not been set");
                }
                // Check that mapInformationReport has been set
                if (this.mapInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(MapInformationReport) + " has not been set");
                }
                return argumentExceptionSet;
            }

            #endregion Private Methods
        }

        #endregion Public Classes
    }
}