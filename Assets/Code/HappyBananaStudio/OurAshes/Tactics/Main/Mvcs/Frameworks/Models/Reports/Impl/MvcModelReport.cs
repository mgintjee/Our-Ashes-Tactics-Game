namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// MvcModel Report Api
    /// </summary>
    public struct MvcModelReport
        : IMvcModelReport
    {
        // Todo
        private readonly IGameBoardReport gameBoardReport;

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
        /// <param name="roeReport"></param>
        /// <param name="rosterReport"></param>
        /// <param name="talonCallSign"></param>
        private MvcModelReport(IGameBoardReport gameBoardReport,
            IRoeReport roeReport, IRosterReport rosterReport, TalonCallSign talonCallSign)
        {
            this.gameBoardReport = gameBoardReport;
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
        TalonCallSign IMvcModelReport.GetActingTalonCallSign()
        {
            return this.talonCallSign;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}={2}," +
                "\n\t>{3}," +
                "\n\t>{4}," +
                "\n\t>{5}",
                this.GetType().Name, typeof(TalonCallSign).Name, this.talonCallSign,
                this.gameBoardReport, this.roeReport, this.rosterReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IGameBoardReport gameBoardReport = null;

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
                    return new MvcModelReport(this.gameBoardReport,
                        this.roeReport, this.rosterReport, this.talonCallSign);
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