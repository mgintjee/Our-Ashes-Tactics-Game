namespace HappyBananaStudio.OurAshes.Tactics.Impl.MVCs.GameActions.Reports
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Maps.Games.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.MVCs.GameActions.Reports;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Results;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct GameActionReportImpl
        : IGameActionReport
    {
        // Todo
        private readonly int actionCounter;

        // Todo
        private readonly IGameMapInformationReport gameMapInformationReport;

        // Todo
        private readonly int phaseCounter;

        // Todo
        private readonly ITalonActionResultReport talonActionResultReport;

        private GameActionReportImpl(int actionCounter, IGameMapInformationReport gameMapInformationReport,
            int phaseCounter, ITalonActionResultReport talonActionResultReport)
        {
            this.actionCounter = actionCounter;
            this.gameMapInformationReport = gameMapInformationReport;
            this.phaseCounter = phaseCounter;
            this.talonActionResultReport = talonActionResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                "\n\t>Action Counter: " + this.actionCounter +
                "\n\t>" + this.gameMapInformationReport +
                "\n\t>Phase Counter: " + this.phaseCounter +
                "\n\t>" + this.talonActionResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IGameActionReport.GetActionCounter()
        {
            return this.actionCounter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IGameMapInformationReport IGameActionReport.GetGameMapInformationReport()
        {
            return this.gameMapInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        int IGameActionReport.GetPhaseCounter()
        {
            return this.phaseCounter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ITalonActionResultReport IGameActionReport.GetTalonActionResultReport()
        {
            return this.talonActionResultReport;
        }

        /// <summary>
        /// Builder class for this report
        /// </summary>
        public class Builder
        {
            // Todo
            private int actionCounter;

            // Todo
            private IGameMapInformationReport gameMapInformationReport;

            // Todo
            private int phaseCounter;

            // Todo
            private bool setActionCounter = false;

            // Todo
            private bool setPhaseCounter = false;

            // Todo
            private ITalonActionResultReport talonActionResultReport;

            /// <summary>
            /// Build the GameActionReport with the set parameters
            /// </summary>
            /// <returns>
            /// The report interface
            /// </returns>
            public IGameActionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new GameActionReportImpl(this.actionCounter, this.gameMapInformationReport,
                        this.phaseCounter, this.talonActionResultReport);
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            /// Set the value of the actionCounter
            /// </summary>
            /// <param name="actionCounter">
            /// The actionCounter to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetActionCounter(int actionCounter)
            {
                this.actionCounter = actionCounter;
                this.setActionCounter = true;
                return this;
            }

            /// <summary>
            /// Set the value of the IGameMapInformationReport
            /// </summary>
            /// <param name="gameMapInformationReport">
            /// The IGameMapInformationReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetGameMapInformationReport(IGameMapInformationReport gameMapInformationReport)
            {
                this.gameMapInformationReport = gameMapInformationReport;
                return this;
            }

            /// <summary>
            /// Set the value of the phaseCounter
            /// </summary>
            /// <param name="phaseCounter">
            /// The phaseCounter to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetPhaseCounter(int phaseCounter)
            {
                this.phaseCounter = phaseCounter;
                this.setPhaseCounter = true;
                return this;
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
            /// Todo
            /// </summary>
            /// <returns>
            /// </returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                // Check that actionCounter has been set
                if (!this.setActionCounter)
                {
                    argumentExceptionSet.Add("actionCounter has not been set");
                }
                // Check that gameMapInformationReport has been set
                if (this.gameMapInformationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IGameMapInformationReport).Name + " has not been set");
                }
                // Check that phaseCounter has been set
                if (!this.setPhaseCounter)
                {
                    argumentExceptionSet.Add("setPhaseCounter has not been set");
                }
                // Check that talonActionResultReport has been set
                if (this.talonActionResultReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonActionResultReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}