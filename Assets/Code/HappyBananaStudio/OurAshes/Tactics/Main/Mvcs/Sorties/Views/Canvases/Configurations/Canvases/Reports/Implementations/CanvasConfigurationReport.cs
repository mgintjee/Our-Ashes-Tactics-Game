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
        private readonly ICanvasGridMeasurements canvasActionMenuConfigurationReport;

        // Todo
        private readonly ICanvasGridMeasurements canvasInformationalConfigurationReport;

        // Todo
        private readonly ICanvasGridMeasurements canvasScoreBoardConfigurationReport;

        // TodoImpleme
        private readonly ICanvasGridMeasurements canvasSettingMenuConfigurationReport;

        // Todo
        private readonly ICanvasGridMeasurements canvasTurnScrollerConfigurationReport;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasActionMenuConfigurationReport">   </param>
        /// <param name="canvasInformationalConfigurationReport"></param>
        /// <param name="canvasScoreBoardConfigurationReport">   </param>
        /// <param name="canvasSettingMenuConfigurationReport">  </param>
        /// <param name="canvasTurnScrollerConfigurationReport"> </param>
        private CanvasConfigurationReport(ICanvasGridMeasurements canvasActionMenuConfigurationReport,
            ICanvasGridMeasurements canvasInformationalConfigurationReport, ICanvasGridMeasurements canvasScoreBoardConfigurationReport,
            ICanvasGridMeasurements canvasSettingMenuConfigurationReport, ICanvasGridMeasurements canvasTurnScrollerConfigurationReport)
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
                PanelCanvasGridMeasurementsConstants.ActionMenuConfigurationReport(),
                PanelCanvasGridMeasurementsConstants.InformationalConfigurationReport(),
                PanelCanvasGridMeasurementsConstants.ScoreBoardConfigurationReport(),
                PanelCanvasGridMeasurementsConstants.SettingMenuConfigurationReport(),
                PanelCanvasGridMeasurementsConstants.TurnScrollerConfigurationReport());
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
        ICanvasGridMeasurements ICanvasConfigurationReport.GetActionMenuCanvasGridMeasurements()
        {
            return this.canvasActionMenuConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasGridMeasurements ICanvasConfigurationReport.GetInformationalCanvasGridMeasurements()
        {
            return this.canvasInformationalConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasGridMeasurements ICanvasConfigurationReport.GetScoreBoardCanvasGridMeasurements()
        {
            return this.canvasScoreBoardConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasGridMeasurements ICanvasConfigurationReport.GetSettingMenuCanvasGridMeasurements()
        {
            return this.canvasSettingMenuConfigurationReport;
        }

        /// <inheritdoc/>
        ICanvasGridMeasurements ICanvasConfigurationReport.GetTurnScrollerCanvasGridMeasurements()
        {
            return this.canvasTurnScrollerConfigurationReport;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            // Todo
            private ICanvasGridMeasurements canvasActionMenuConfigurationReport = null;

            // Todo
            private ICanvasGridMeasurements canvasInformationalConfigurationReport = null;

            // Todo
            private ICanvasGridMeasurements canvasScoreBoardConfigurationReport = null;

            // Todo
            private ICanvasGridMeasurements canvasSettingMenuConfigurationReport = null;

            // Todo
            private ICanvasGridMeasurements canvasTurnScrollerConfigurationReport = null;

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
            public Builder SetCanvasActionMenuConfigurationReport(ICanvasGridMeasurements canvasActionMenuConfigurationReport)
            {
                this.canvasActionMenuConfigurationReport = canvasActionMenuConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasInformationalConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasInformationalConfigurationReport(ICanvasGridMeasurements canvasInformationalConfigurationReport)
            {
                this.canvasInformationalConfigurationReport = canvasInformationalConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasScoreBoardConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasScoreBoardConfigurationReport(ICanvasGridMeasurements canvasScoreBoardConfigurationReport)
            {
                this.canvasScoreBoardConfigurationReport = canvasScoreBoardConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasSettingMenuConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasSettingMenuConfigurationReport(ICanvasGridMeasurements canvasSettingMenuConfigurationReport)
            {
                this.canvasSettingMenuConfigurationReport = canvasSettingMenuConfigurationReport;
                return this;
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="canvasTurnScrollerConfigurationReport"></param>
            /// <returns></returns>
            public Builder SetCanvasTurnScrollerConfigurationReport(ICanvasGridMeasurements canvasTurnScrollerConfigurationReport)
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
                    argumentExceptionSet.Add(typeof(IPanelActionMenu).Name + " " + typeof(ICanvasGridMeasurements).Name + " cannot be null.");
                }
                if (this.canvasInformationalConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelInformational).Name + " " + typeof(ICanvasGridMeasurements).Name + " cannot be null.");
                }
                if (this.canvasScoreBoardConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelScoreBoard).Name + " " + typeof(ICanvasGridMeasurements).Name + " cannot be null.");
                }
                if (this.canvasSettingMenuConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelSettingMenu).Name + " " + typeof(ICanvasGridMeasurements).Name + " cannot be null.");
                }
                if (this.canvasTurnScrollerConfigurationReport == null)
                {
                    argumentExceptionSet.Add(typeof(IPanelTurnScroller).Name + " " + typeof(ICanvasGridMeasurements).Name + " cannot be null.");
                }
                return argumentExceptionSet;
            }
        }
    }
    */
}