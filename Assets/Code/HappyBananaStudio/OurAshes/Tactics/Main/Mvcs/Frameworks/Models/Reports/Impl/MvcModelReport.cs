namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.GameBoards.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Phalanxes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// MvcModel Report Impl
    /// </summary>
    public struct MvcModelReport
        : IMvcModelReport
    {
        // Todo
        private readonly IGameBoardReport gameBoardReport;

        // Todo
        private readonly IPhalanxRosterReport phalanxRosterReport;

        // Todo
        private readonly ITalonRosterReport talonrosterReport;

        // Todo
        private readonly IWinConditionReport winConditionReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameBoardReport"></param>
        /// <param name="roeReport"></param>
        /// <param name="rosterReport"></param>
        /// <param name="winConditionReport"></param>
        private MvcModelReport(IGameBoardReport gameBoardReport, IPhalanxRosterReport phalanxRosterReport,
            ITalonRosterReport rosterReport, IWinConditionReport winConditionReport)
        {
            this.gameBoardReport = gameBoardReport;
            this.phalanxRosterReport = phalanxRosterReport;
            this.talonrosterReport = rosterReport;
            this.winConditionReport = winConditionReport;
        }

        /// <inheritdoc/>
        IGameBoardReport IMvcModelReport.GetGameBoardReport()
        {
            return this.gameBoardReport;
        }

        /// <inheritdoc/>
        IPhalanxRosterReport IMvcModelReport.GetPhalanxRosterReport()
        {
            return this.phalanxRosterReport;
        }

        /// <inheritdoc/>
        ITalonRosterReport IMvcModelReport.GetTalonRosterReport()
        {
            return this.talonrosterReport;
        }

        /// <inheritdoc/>
        IWinConditionReport IMvcModelReport.GetWinConditionReport()
        {
            return this.winConditionReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}:" +
                "\n\t>{1}" +
                "\n\t>{2}" +
                "\n\t>{3}" +
                "\n\t>{4}",
                this.GetType().Name, this.gameBoardReport, this.phalanxRosterReport,
                this.talonrosterReport, this.winConditionReport);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IGameBoardReport gameBoardReport = null;

            // Todo
            private IPhalanxRosterReport phalanxRosterReport = null;

            // Todo
            private ITalonRosterReport talonRosterReport = null;

            // Todo
            private IWinConditionReport winConditionReport = null;

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
                    return new MvcModelReport(this.gameBoardReport, this.phalanxRosterReport,
                        this.talonRosterReport, this.winConditionReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                    this.GetType(), string.Join("\n", invalidReasons));
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
            /// <param name="phalanxRosterReport"></param>
            /// <returns></returns>
            public Builder SetPhalanxRosterReport(IPhalanxRosterReport phalanxRosterReport)
            {
                this.phalanxRosterReport = phalanxRosterReport;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="talonRosterReport"></param>
            /// <returns></returns>
            public Builder SetTalonRosterReport(ITalonRosterReport talonRosterReport)
            {
                this.talonRosterReport = talonRosterReport;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="winConditionReport"></param>
            /// <returns></returns>
            public Builder SetWinConditionReport(IWinConditionReport winConditionReport)
            {
                this.winConditionReport = winConditionReport;
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
                    argumentExceptionSet.Add(typeof(IGameBoardReport).Name + " cannot be null.");
                }
                // Check that phalanxRosterReport has been set
                if (this.phalanxRosterReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPhalanxRosterReport).Name + " cannot be null.");
                }
                // Check that rosterReport has been set
                if (this.talonRosterReport == null)
                {
                    argumentExceptionSet.Add(typeof(ITalonRosterReport).Name + " cannot be null.");
                }
                // Check that winConditionReport has been set
                if (this.winConditionReport == null)
                {
                    argumentExceptionSet.Add(typeof(IWinConditionReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
}