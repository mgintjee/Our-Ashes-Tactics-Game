/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Maps.Game;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Turn;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Impl.Reports.Game
{
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
        private readonly ITalonTurnResultReport talonTurnResultReport;

        private GameActionReportImpl(int actionCounter, IGameMapInformationReport gameMapInformationReport,
            int phaseCounter, ITalonTurnResultReport talonTurnResultReport)
        {
            this.actionCounter = actionCounter;
            this.gameMapInformationReport = gameMapInformationReport;
            this.phaseCounter = phaseCounter;
            this.talonTurnResultReport = talonTurnResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetActionCounter()
        {
            return this.actionCounter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public IGameMapInformationReport GetGameMapInformationReport()
        {
            return this.gameMapInformationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetPhaseCounter()
        {
            return this.phaseCounter;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public ITalonTurnResultReport GetTalonTurnResultReport()
        {
            return this.talonTurnResultReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return this.GetType().Name + ": " +
                "\n\t>Action Counter: " + this.GetActionCounter() +
                "\n\t>" + this.GetGameMapInformationReport() +
                "\n\t>Phase Counter: " + this.GetPhaseCounter() +
                "\n\t>" + this.GetTalonTurnResultReport();
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
            private ITalonTurnResultReport talonTurnResultReport;

            /// <summary>
            /// Build the GameActionReport with the set parameters
            /// </summary>
            /// <returns>
            /// The IGameActionReport
            /// </returns>
            public IGameActionReport Build()
            {
                HashSet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Report
                    return new GameActionReportImpl(this.actionCounter, this.gameMapInformationReport,
                        this.phaseCounter, this.talonTurnResultReport);
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
            /// Set the value of the ITalonTurnResultReport
            /// </summary>
            /// <param name="talonTurnResultReport">
            /// The ITalonTurnResultReport to set
            /// </param>
            /// <returns>
            /// The Builder to continue building with
            /// </returns>
            public Builder SetTalonTurnResultReport(ITalonTurnResultReport talonTurnResultReport)
            {
                this.talonTurnResultReport = talonTurnResultReport;
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
                // Check that talonTurnResultReport has been set
                if (this.talonTurnResultReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonTurnResultReport).Name + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}