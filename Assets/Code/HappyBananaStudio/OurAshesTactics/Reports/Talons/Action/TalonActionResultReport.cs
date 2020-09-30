/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Attributes;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Combat;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Reports.Talons.Action
{
    /// <summary>
    /// Todo
    /// </summary>
    public struct TalonActionResultReport
        : ITalonActionResultReport
    {
        // Todo
        private readonly ITalonActionOrderReport talonActionOrderReport;

        // Todo
        private readonly ITalonAttributesReport talonAttributesReport;

        // Todo
        private readonly ITalonCombatResultReport talonCombatResultReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <param name="talonAttributesReport">
        /// </param>
        private TalonActionResultReport(ITalonActionOrderReport talonActionOrderReport,
            ITalonAttributesReport talonAttributesReport)
        {
            this.talonActionOrderReport = talonActionOrderReport;
            this.talonAttributesReport = talonAttributesReport;
            this.talonCombatResultReport = null;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        /// <param name="talonAttributesReport">
        /// </param>
        /// <param name="talonCombatOrderReport">
        /// </param>
        private TalonActionResultReport(ITalonActionOrderReport talonActionOrderReport,
            ITalonAttributesReport talonAttributesReport, ITalonCombatResultReport talonCombatResultReport)
        {
            this.talonActionOrderReport = talonActionOrderReport;
            this.talonAttributesReport = talonAttributesReport;
            this.talonCombatResultReport = talonCombatResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonActionOrderReport GetTalonActionOrder()
        {
            return this.talonActionOrderReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonAttributesReport GetTalonAttributesReport()
        {
            return this.talonAttributesReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonCombatResultReport GetTalonCombatResultReport()
        {
            return this.talonCombatResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ":" +
                "\n\t>" + this.GetTalonActionOrder() +
                "\n\t>" + this.GetTalonAttributesReport() +
                ((this.GetTalonCombatResultReport() != null)
                ? "\n\t>" + this.GetTalonCombatResultReport()
                : "");
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private ITalonActionOrderReport talonActionOrderReport = null;

            // Todo
            private ITalonAttributesReport talonAttributesReport = null;

            // Todo
            private ITalonCombatResultReport talonCombatResultReport = null;

            /// <summary>
            /// Build the TalonActionResultReport with the set parameters
            /// </summary>
            /// <returns>
            /// The ITalonActionResultReport
            /// </returns>
            public ITalonActionResultReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    if (this.talonCombatResultReport != null)
                    {
                        // Instantiate a new Report
                        return new TalonActionResultReport(this.talonActionOrderReport,
                            this.talonAttributesReport, this.talonCombatResultReport);
                    }
                    else
                    {
                        // Instantiate a new Report
                        return new TalonActionResultReport(this.talonActionOrderReport, this.talonAttributesReport);
                    }
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the ITalonActionOrderReport
            /// </summary>
            /// <param name="talonActionOrderReport">
            /// The ITalonActionOrderReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
            {
                this.talonActionOrderReport = talonActionOrderReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonAttributesReport
            /// </summary>
            /// <param name="talonAttributesReport">
            /// The ITalonAttributesReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonAttributesReport(ITalonAttributesReport talonAttributesReport)
            {
                this.talonAttributesReport = talonAttributesReport;
                return this;
            }

            /// <summary>
            /// Set the value of the ITalonCombatResultReport
            /// </summary>
            /// <param name="talonCombatResultReport">
            /// The ITalonCombatResultReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonCombatResultReport(ITalonCombatResultReport talonCombatResultReport)
            {
                this.talonCombatResultReport = talonCombatResultReport;
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
                // Check that talonActionOrderReport has been set
                if (this.talonActionOrderReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonActionOrderReport).Name + " has not been set");
                }
                // Check that the target
                else if (this.talonActionOrderReport.GetActionType() == ActionTypeEnum.Fire)
                {
                    // Check that talonCombatResultReport has been set
                    if (this.talonCombatResultReport == null)
                    {
                        argumentExceptionSet.Add(typeof(ITalonCombatResultReport).Name + " has not been set");
                    }
                }
                // Check that talonAttributesReport has been set
                if (this.talonAttributesReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonAttributesReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}