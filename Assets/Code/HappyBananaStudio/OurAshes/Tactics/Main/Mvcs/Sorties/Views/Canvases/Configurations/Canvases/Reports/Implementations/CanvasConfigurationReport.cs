namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Sorties.Views.Canvases.Configurations.Canvases.Reports.Implementations
{
    /*
    /// <summary>
    /// Todo
    /// </summary>
    public struct CanvasConfigurationReport
        : ICanvasConfigurationReport
    {
        // Todo
        private readonly IGridConfigurationReport canvasActionMenuConfigurationReport;

        // Todo
        private readonly IGridConfigurationReport canvasInformationalConfigurationReport;

        // Todo
        private readonly IGridConfigurationReport canvasScoreBoardConfigurationReport;

        // TodoImpleme
        private readonly IGridConfigurationReport canvasSettingMenuConfigurationReport;

        // Todo
        private readonly IGridConfigurationReport canvasTurnScrollerConfigurationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasActionMenuConfigurationReport">   </param>
        /// <param name="canvasInformationalConfigurationReport"></param>
        /// <param name="canvasScoreBoardConfigurationReport">   </param>
        /// <param name="canvasSettingMenuConfigurationReport">  </param>
        /// <param name="canvasTurnScrollerConfigurationReport"> </param>
        private CanvasConfigurationReport(IGridConfigurationReport canvasActionMenuConfigurationReport,
            IGridConfigurationReport canvasInformationalConfigurationReport, IGridConfigurationReport canvasScoreBoardConfigurationReport,
            IGridConfigurationReport canvasSettingMenuConfigurationReport, IGridConfigurationReport canvasTurnScrollerConfigurationReport)
        {
            this.canvasActionMenuConfigurationReport = canvasActionMenuConfigurationReport;
            this.canvasInformationalConfigurationReport = canvasInformationalConfigurationReport;
            this.canvasScoreBoardConfigurationReport = canvasScoreBoardConfigurationReport;
            this.canvasSettingMenuConfigurationReport = canvasSettingMenuConfigurationReport;
            this.canvasTurnScrollerConfigurationReport = canvasTurnScrollerConfigurationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static ICanvasConfigurationReport DefaultViewConfigurationReport()
        {
            return new CanvasConfigurationReport(
                PanelGridConfigurationReportConstants.ActionMenuConfigurationReport(),
                PanelGridConfigurationReportConstants.InformationalConfigurationReport(),
                PanelGridConfigurationReportConstants.ScoreBoardConfigurationReport(),
                PanelGridConfigurationReportConstants.SettingMenuConfigurationReport(),
                PanelGridConfigurationReportConstants.TurnScrollerConfigurationReport());
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\n\t> {1}:{2}" +
                "\n\t> {3}:{4}" +
                "\n\t> {5}:{6}" +
                "\n\t> {7}:{8}" +
                "\n\t> {9}:{10}",
                this.GetType().Name,
                typeof(IPanelActionMenu).Name, this.canvasActionMenuConfigurationReport,
                typeof(IPanelInformational).Name, this.canvasInformationalConfigurationReport,
                typeof(IPanelScoreBoard).Name, this.canvasScoreBoardConfigurationReport,
                typeof(IPanelSettingMenu).Name, this.canvasSettingMenuConfigurationReport,
                typeof(IPanelTurnScroller).Name, this.canvasTurnScrollerConfigurationReport);
        }

        /// <inheritdoc/>
        IGridConfigurationReport ICanvasConfigurationReport.GetActionMenuGridConfigurationReport()
        {
            return this.canvasActionMenuConfigurationReport;
        }

        /// <inheritdoc/>
        IGridConfigurationReport ICanvasConfigurationReport.GetInformationalGridConfigurationReport()
        {
            return this.canvasInformationalConfigurationReport;
        }

        /// <inheritdoc/>
        IGridConfigurationReport ICanvasConfigurationReport.GetScoreBoardGridConfigurationReport()
        {
            return this.canvasScoreBoardConfigurationReport;
        }

        /// <inheritdoc/>
        IGridConfigurationReport ICanvasConfigurationReport.GetSettingMenuGridConfigurationReport()
        {
            return this.canvasSettingMenuConfigurationReport;
        }

        /// <inheritdoc/>
        IGridConfigurationReport ICanvasConfigurationReport.GetTurnScrollerGridConfigurationReport()
        {
            return this.canvasTurnScrollerConfigurationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private IGridConfigurationReport canvasActionMenuConfigurationReport = null;

            // Todo
            private IGridConfigurationReport canvasInformationalConfigurationReport = null;

            // Todo
            private IGridConfigurationReport canvasScoreBoardConfigurationReport = null;

            // Todo
            private IGridConfigurationReport canvasSettingMenuConfigurationReport = null;

            // Todo
            private IGridConfigurationReport canvasTurnScrollerConfigurationReport = null;

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public ICanvasConfigurationReport Build()
            {
                ISet<string> invalidReasons = this.IsInvalid();
                // Check that the set parameters are valid
                if (invalidReasons.Count == 0)
                {
                    return new CanvasConfigurationReport(this.canvasActionMenuConfigurationReport,
                        this.canvasInformationalConfigurationReport, this.canvasScoreBoardConfigurationReport,
                        this.canvasSettingMenuConfigurationReport, this.canvasTurnScrollerConfigurationReport);
                }
                throw ExceptionUtil.Arguments.Build("Unable to construct {}. Invalid Parameters. {}",
                    this.GetType(), string.Join("\n", invalidReasons));
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasActionMenuConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasActionMenuConfigurationReport(IGridConfigurationReport canvasActionMenuConfigurationReport)
            {
                this.canvasActionMenuConfigurationReport = canvasActionMenuConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasInformationalConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasInformationalConfigurationReport(IGridConfigurationReport canvasInformationalConfigurationReport)
            {
                this.canvasInformationalConfigurationReport = canvasInformationalConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasScoreBoardConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasScoreBoardConfigurationReport(IGridConfigurationReport canvasScoreBoardConfigurationReport)
            {
                this.canvasScoreBoardConfigurationReport = canvasScoreBoardConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasSettingMenuConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasSettingMenuConfigurationReport(IGridConfigurationReport canvasSettingMenuConfigurationReport)
            {
                this.canvasSettingMenuConfigurationReport = canvasSettingMenuConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasTurnScrollerConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasTurnScrollerConfigurationReport(IGridConfigurationReport canvasTurnScrollerConfigurationReport)
            {
                this.canvasTurnScrollerConfigurationReport = canvasTurnScrollerConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            private ISet<string> IsInvalid()
            {
                // Default an empty Set: String
                ISet<string> argumentExceptionSet = new HashSet<string>();
                if (this.canvasActionMenuConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelActionMenu).Name + " " + typeof(IGridConfigurationReport).Name + " cannot be null.");
                }
                if (this.canvasInformationalConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelInformational).Name + " " + typeof(IGridConfigurationReport).Name + " cannot be null.");
                }
                if (this.canvasScoreBoardConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelScoreBoard).Name + " " + typeof(IGridConfigurationReport).Name + " cannot be null.");
                }
                if (this.canvasSettingMenuConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelSettingMenu).Name + " " + typeof(IGridConfigurationReport).Name + " cannot be null.");
                }
                if (this.canvasTurnScrollerConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelTurnScroller).Name + " " + typeof(IGridConfigurationReport).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
    */
}