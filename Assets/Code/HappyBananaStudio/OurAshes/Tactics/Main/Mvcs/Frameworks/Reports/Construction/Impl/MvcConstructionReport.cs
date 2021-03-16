namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Construction.Impl
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Construction.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Configurations.Canvases.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Constructions.Reports.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public struct MvcConstructionReport
        : IMvcConstructionReport
    {
        // Todo
        private readonly SimulationType simulationType;

        // Todo
        private readonly MatchType matchType;

        // Todo
        private readonly int gameBoardLimit;

        // Todo
        private readonly GameBoardShape gameBoardShape;

        // Todo
        private readonly bool mirroredBoard;

        // Todo
        private readonly ISet<IPhalanxReport> phalanxReports;

        // Todo
        private readonly ISet<ITalonConstructionReport> talonConstructionReports;

        // Todo
        private readonly ICanvasConfigurationReport viewConfigurationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="simulationType"></param>
        /// <param name="matchType"></param>
        /// <param name="gameBoardLimit"></param>
        /// <param name="gameBoardShape"></param>
        /// <param name="mirroredBoard"></param>
        /// <param name="phalanxReports"></param>
        /// <param name="talonConstructionReports"></param>
        private MvcConstructionReport(SimulationType simulationType, MatchType matchType,
            int gameBoardLimit, GameBoardShape gameBoardShape, bool mirroredBoard,
            ISet<IPhalanxReport> phalanxReports, ISet<ITalonConstructionReport> talonConstructionReports,
            ICanvasConfigurationReport viewConfigurationReport)
        {
            this.simulationType = simulationType;
            this.matchType = matchType;
            this.gameBoardLimit = gameBoardLimit;
            this.gameBoardShape = gameBoardShape;
            this.mirroredBoard = mirroredBoard;
            this.phalanxReports = phalanxReports;
            this.talonConstructionReports = talonConstructionReports;
            this.viewConfigurationReport = viewConfigurationReport;
        }

        /// <inheritdoc/>
        int IMvcConstructionReport.GetGameBoardLimit()
        {
            return this.gameBoardLimit;
        }

        /// <inheritdoc/>
        GameBoardShape IMvcConstructionReport.GetGameBoardShape()
        {
            return this.gameBoardShape;
        }

        /// <inheritdoc/>
        MatchType IMvcConstructionReport.GetMatchType()
        {
            return this.matchType;
        }

        /// <inheritdoc/>
        bool IMvcConstructionReport.GetMirroredBoard()
        {
            return this.mirroredBoard;
        }

        /// <inheritdoc/>
        ISet<IPhalanxReport> IMvcConstructionReport.GetPhalanxReports()
        {
            return new HashSet<IPhalanxReport>(this.phalanxReports);
        }

        /// <inheritdoc/>
        SimulationType IMvcConstructionReport.GetSimulationType()
        {
            return this.simulationType;
        }

        /// <inheritdoc/>
        ISet<ITalonConstructionReport> IMvcConstructionReport.GetTalonConstructionReports()
        {
            return new HashSet<ITalonConstructionReport>(this.talonConstructionReports);
        }

        /// <inheritdoc/>
        ICanvasConfigurationReport IMvcConstructionReport.GetViewConfigurationReport()
        {
            return this.viewConfigurationReport;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n\t>{1}={2}, {3}={4}" +
                "\n\t>gameBoardLimit={5}, {6}={7}, mirroredBoard={8}" +
                "\n\n\t>[{9}]" +
                "\n\n\t>[{10}]",
                this.GetType().Name, typeof(SimulationType).Name, this.simulationType,
                typeof(MatchType).Name, this.matchType, this.gameBoardLimit,
                typeof(GameBoardShape).Name, this.gameBoardShape, this.mirroredBoard,
                string.Join("\n\t>", this.phalanxReports),
                string.Join("\n\t>", this.talonConstructionReports));
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private SimulationType simulationType = SimulationType.None;

            // Todo
            private MatchType matchType = MatchType.None;

            // Todo
            private int gameBoardLimit = 0;

            // Todo
            private GameBoardShape gameBoardShape = GameBoardShape.None;

            // Todo
            private bool mirroredBoard = true;

            // Todo
            private ISet<IPhalanxReport> phalanxReports = null;

            // Todo
            private ISet<ITalonConstructionReport> talonConstructionReports = null;

            // Todo
            private ICanvasConfigurationReport viewConfigurationReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public IMvcConstructionReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    // Instantiate a new Object
                    return new MvcConstructionReport(this.simulationType, this.matchType, this.gameBoardLimit,
                        this.gameBoardShape, this.mirroredBoard, this.phalanxReports, this.talonConstructionReports,
                        this.viewConfigurationReport);
                }
                else
                {
                    throw ExceptionUtil.Arguments.Build("Unable to construct ?. Invalid Parameters. ?",
                        this.GetType(), string.Join("\n", invalidReasons));
                }
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="simulationType"></param>
            /// <returns></returns>
            public Builder SetSimulationType(SimulationType simulationType)
            {
                this.simulationType = simulationType;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="matchType"></param>
            /// <returns></returns>
            public Builder SetMatchType(MatchType matchType)
            {
                this.matchType = matchType;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="gameBoardLimit"></param>
            /// <returns></returns>
            public Builder SetGameBoardLimit(int gameBoardLimit)
            {
                if (gameBoardLimit > 0)
                {
                    this.gameBoardLimit = gameBoardLimit;
                }
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="gameBoardShape"></param>
            /// <returns></returns>
            public Builder SetGameBoardShape(GameBoardShape gameBoardShape)
            {
                this.gameBoardShape = gameBoardShape;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="mirroredBoard"></param>
            /// <returns></returns>
            public Builder SetMirroredBoard(bool mirroredBoard)
            {
                this.mirroredBoard = mirroredBoard;
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="phalanxReports"></param>
            /// <returns></returns>
            public Builder SetPhalanxReports(ISet<IPhalanxReport> phalanxReports)
            {
                if (phalanxReports != null)
                {
                    this.phalanxReports = new HashSet<IPhalanxReport>(phalanxReports);
                }
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="talonConstructionReports"></param>
            /// <returns></returns>
            public Builder SetTalonConstructionReports(ISet<ITalonConstructionReport> talonConstructionReports)
            {
                if (talonConstructionReports != null)
                {
                    this.talonConstructionReports = new HashSet<ITalonConstructionReport>(talonConstructionReports);
                }
                return this;
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="viewConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetViewConfigurationReport(ICanvasConfigurationReport viewConfigurationReport)
            {
                this.viewConfigurationReport = viewConfigurationReport;
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
                // Check that simulationType has been set
                if (this.simulationType == SimulationType.None)
                {
                    argumentExceptionSet.Add(typeof(SimulationType).Name + " can not be none.");
                }
                // Check that matchType has been set
                if (this.matchType == MatchType.None)
                {
                    argumentExceptionSet.Add(typeof(MatchType).Name + " can not be none.");
                }
                // Check that gameBoardLimit has been set
                if (this.gameBoardLimit < 1)
                {
                    argumentExceptionSet.Add("gameBoardLimit=(" + this.gameBoardLimit + ") is invalid.");
                }
                // Check that gameBoardShape has been set
                if (this.gameBoardShape == GameBoardShape.None)
                {
                    argumentExceptionSet.Add(typeof(GameBoardShape).Name + " can not be none.");
                }
                // Check that phalanxReports has been set
                if (this.phalanxReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(IPhalanxReport).Name + " can not be null.");
                }
                // Check that talonConstructionReports has been set
                if (this.talonConstructionReports == null)
                {
                    argumentExceptionSet.Add("Set: " + typeof(ITalonConstructionReport).Name + " can not be null.");
                }
                // Check that viewConfigurationReport has been set
                if (this.viewConfigurationReport == null && this.simulationType != SimulationType.BlackBox)
                {
                    argumentExceptionSet.Add(typeof(ICanvasConfigurationReport).Name + " can not be null with "
                        + typeof(SimulationType).Name + "=" + this.simulationType);
                }
                return argumentExceptionSet;
            }
        }
    }
}