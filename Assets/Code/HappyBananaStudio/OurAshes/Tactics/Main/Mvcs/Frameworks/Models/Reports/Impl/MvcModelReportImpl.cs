namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// MvcModel Report Api
    /// </summary>
    public struct MvcModelReportImpl
        : IMvcModelReport
    {
        // Todo
        private readonly IGameBoardReport gameBoardReport;

        // Todo
        private readonly int actionCount;

        // Todo
        private readonly int turnCount;

        // Todo
        private readonly IRoeReport roeReport;

        // Todo
        private readonly IRosterReport rosterReport;

        // Todo
        private readonly TalonCallSign talonCallSign;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardReport"></param>
        /// <param name="actionCount"></param>
        /// <param name="turnCount"></param>
        /// <param name="roeReport"></param>
        /// <param name="rosterReport"></param>
        /// <param name="talonCallSign"></param>
        private MvcModelReportImpl(IGameBoardReport gameBoardReport, int actionCount,
            int turnCount, IRoeReport roeReport, IRosterReport rosterReport, TalonCallSign talonCallSign)
        {
            this.gameBoardReport = gameBoardReport;
            this.actionCount = actionCount;
            this.turnCount = turnCount;
            this.roeReport = roeReport;
            this.rosterReport = rosterReport;
            this.talonCallSign = talonCallSign;
        }

        /// <inheritdoc/>
        IGameBoardReport IMvcModelReport.GetGameBoardReport()
        {
            return this.gameBoardReport;
        }

        /// <inheritdoc/>
        int IMvcModelReport.GetActionCount()
        {
            return this.actionCount;
        }

        /// <inheritdoc/>
        IRoeReport IMvcModelReport.GetRoeReport()
        {
            return this.roeReport;
        }

        /// <inheritdoc/>
        IRosterReport IMvcModelReport.GetRosterReport()
        {
            return this.rosterReport;
        }

        /// <inheritdoc/>
        int IMvcModelReport.GetTurnCount()
        {
            return this.turnCount;
        }

        /// <inheritdoc/>
        TalonCallSign IMvcModelReport.GetActingTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IGameBoardReport gameBoardReport = null;

            // Todo
            private int actionCount = int.MinValue;

            // Todo
            private int turnCount = int.MinValue;

            // Todo
            private IRoeReport roeReport = null;

            // Todo
            private IRosterReport rosterReport = null;

            // Todo
            private TalonCallSign talonCallSign = TalonCallSign.None;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcModelReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MvcModelReportImpl(this.gameBoardReport, this.actionCount,
                        this.turnCount, this.roeReport, this.rosterReport, this.talonCallSign);
                }
                else
                {
                    throw ExceptionUtil.Argument.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="gameBoardReport"></param>
            /// <returns></returns>
            public Builder SetGameBoardReport(IGameBoardReport gameBoardReport)
            {
                this.gameBoardReport = gameBoardReport;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="phaseActionCounter"></param>
            /// <returns></returns>
            public Builder SetActionCount(int phaseActionCounter)
            {
                this.actionCount = phaseActionCounter;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="totalActionCounter"></param>
            /// <returns></returns>
            public Builder SetTurnCount(int totalActionCounter)
            {
                this.turnCount = totalActionCounter;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="talonCallSign"></param>
            /// <returns></returns>
            public Builder SetTalonCallSign(TalonCallSign talonCallSign)
            {
                this.talonCallSign = talonCallSign;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="roeReport"></param>
            /// <returns></returns>
            public Builder SetRoeReport(IRoeReport roeReport)
            {
                this.roeReport = roeReport;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="rosterReport"></param>
            /// <returns></returns>
            public Builder SetRosterReport(IRosterReport rosterReport)
            {
                this.rosterReport = rosterReport;
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
                // Check that gameBoardReport has been set
                if (this.gameBoardReport == null)
                {
                    argumentExceptionSet.Add(typeof(IGameBoardReport) + " has not been set");
                }
                // Check that actionCount has been set
                if (this.actionCount == int.MinValue)
                {
                    argumentExceptionSet.Add("actionCount has not been set");
                }
                // Check that turnCount has been set
                if (this.turnCount == int.MinValue)
                {
                    argumentExceptionSet.Add("turnCount has not been set");
                }
                // Check that roeReport has been set
                if (this.roeReport == null)
                {
                    argumentExceptionSet.Add(typeof(IRoeReport) + " has not been set");
                }
                // Check that rosterReport has been set
                if (this.rosterReport == null)
                {
                    argumentExceptionSet.Add(typeof(IRosterReport) + " has not been set");
                }
                // Check that talonCallSign has been set
                if (this.talonCallSign == TalonCallSign.None)
                {
                    argumentExceptionSet.Add(typeof(TalonCallSign) + " has not been set");
                }
                return argumentExceptionSet;
            }
        }
    }
}